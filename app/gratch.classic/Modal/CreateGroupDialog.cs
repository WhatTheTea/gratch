using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ReactiveUI.SourceGenerators;

using gratch.Models;

namespace gratch.classic.Controls;

[IViewFor<Person>]
public partial class CreateGroupDialog : DialogWithResult
{
    public CreateGroupDialog()
    {
        this.InitializeComponent();
        this.nameTextBox.Validating += OnNameValidating;
    }

    private static void OnNameValidating(object? sender, CancelEventArgs e)
    {
        if (!(sender is TextBox nameBox && Group.Validate.Name(nameBox.Text)))
        {
            e.Cancel = true;
        }
    }

    private void createButton_Click(object sender, EventArgs e)
    {
        string result = this.nameTextBox.Text;
        this.SetResult(result);
    }

    private void cancelButton_Click(object sender, EventArgs e) => this.Cancel();

    protected override void OnClosing(CancelEventArgs e)
    {
        this.nameTextBox.Validating -= OnNameValidating;
        base.OnClosing(e);
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        this.nameTextBox.Focus();
    }
}
