namespace gratch.classic.Controls;

partial class CreatePersonDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.cancelButton = new Button();
        this.createButton = new Button();
        this.label1 = new Label();
        this.nameTextBox = new TextBox();
        this.SuspendLayout();
        // 
        // cancelButton
        // 
        this.cancelButton.CausesValidation = false;
        this.cancelButton.Location = new Point(156, 56);
        this.cancelButton.Name = "cancelButton";
        this.cancelButton.Size = new Size(75, 23);
        this.cancelButton.TabIndex = 0;
        this.cancelButton.Text = "Cancel";
        this.cancelButton.UseVisualStyleBackColor = true;
        this.cancelButton.Click += this.cancelButton_Click;
        // 
        // createButton
        // 
        this.createButton.Location = new Point(237, 56);
        this.createButton.Name = "createButton";
        this.createButton.Size = new Size(75, 23);
        this.createButton.TabIndex = 1;
        this.createButton.Text = "Create";
        this.createButton.UseVisualStyleBackColor = true;
        this.createButton.Click += this.createButton_Click;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new Point(12, 9);
        this.label1.Name = "label1";
        this.label1.Size = new Size(134, 15);
        this.label1.TabIndex = 2;
        this.label1.Text = "Enter new person name:";
        // 
        // nameTextBox
        // 
        this.nameTextBox.Location = new Point(12, 27);
        this.nameTextBox.Name = "nameTextBox";
        this.nameTextBox.PlaceholderText = "Name should not be empty";
        this.nameTextBox.Size = new Size(300, 23);
        this.nameTextBox.TabIndex = 3;
        // 
        // CreatePersonDialog
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(324, 86);
        this.Controls.Add(this.nameTextBox);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.createButton);
        this.Controls.Add(this.cancelButton);
        this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CreatePersonDialog";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "New Person";
        this.TopMost = true;
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Button cancelButton;
    private Button createButton;
    private Label label1;
    private TextBox nameTextBox;
}