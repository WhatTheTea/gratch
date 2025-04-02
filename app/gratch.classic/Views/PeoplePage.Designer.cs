namespace gratch.classic.Views;

partial class PeoplePage
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.tableLayoutPanel1 = new TableLayoutPanel();
        this.tableLayoutPanel2 = new TableLayoutPanel();
        this.removeGroupButton = new Button();
        this.groupsComboBox = new ComboBox();
        this.label1 = new Label();
        this.addGroupButton = new Button();
        this.tableLayoutPanel3 = new TableLayoutPanel();
        this.groupBox1 = new GroupBox();
        this.flowLayoutPanel1 = new FlowLayoutPanel();
        this.personAddButton = new Button();
        this.personUpButton = new Button();
        this.personDownButton = new Button();
        this.personRemoveButton = new Button();
        this.peopleListBox = new ListBox();
        this.tableLayoutPanel1.SuspendLayout();
        this.tableLayoutPanel2.SuspendLayout();
        this.tableLayoutPanel3.SuspendLayout();
        this.groupBox1.SuspendLayout();
        this.flowLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.ColumnCount = 1;
        this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
        this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
        this.tableLayoutPanel1.Dock = DockStyle.Fill;
        this.tableLayoutPanel1.Location = new Point(0, 0);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 2;
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel1.Size = new Size(572, 431);
        this.tableLayoutPanel1.TabIndex = 0;
        // 
        // tableLayoutPanel2
        // 
        this.tableLayoutPanel2.ColumnCount = 4;
        this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 64F));
        this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
        this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
        this.tableLayoutPanel2.Controls.Add(this.removeGroupButton, 3, 0);
        this.tableLayoutPanel2.Controls.Add(this.groupsComboBox, 1, 0);
        this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
        this.tableLayoutPanel2.Controls.Add(this.addGroupButton, 2, 0);
        this.tableLayoutPanel2.Dock = DockStyle.Fill;
        this.tableLayoutPanel2.Location = new Point(3, 3);
        this.tableLayoutPanel2.Name = "tableLayoutPanel2";
        this.tableLayoutPanel2.RowCount = 1;
        this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel2.Size = new Size(566, 34);
        this.tableLayoutPanel2.TabIndex = 1;
        // 
        // removeGroupButton
        // 
        this.removeGroupButton.Dock = DockStyle.Fill;
        this.removeGroupButton.Location = new Point(534, 3);
        this.removeGroupButton.Name = "removeGroupButton";
        this.removeGroupButton.Size = new Size(29, 28);
        this.removeGroupButton.TabIndex = 3;
        this.removeGroupButton.Text = "-";
        this.removeGroupButton.UseVisualStyleBackColor = true;
        // 
        // groupsComboBox
        // 
        this.groupsComboBox.Dock = DockStyle.Fill;
        this.groupsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        this.groupsComboBox.FormattingEnabled = true;
        this.groupsComboBox.Location = new Point(69, 5);
        this.groupsComboBox.Margin = new Padding(5);
        this.groupsComboBox.Name = "groupsComboBox";
        this.groupsComboBox.Size = new Size(422, 23);
        this.groupsComboBox.TabIndex = 0;
        // 
        // label1
        // 
        this.label1.Anchor = AnchorStyles.None;
        this.label1.AutoSize = true;
        this.label1.Location = new Point(10, 9);
        this.label1.Name = "label1";
        this.label1.Size = new Size(43, 15);
        this.label1.TabIndex = 1;
        this.label1.Text = "Group:";
        // 
        // addGroupButton
        // 
        this.addGroupButton.Dock = DockStyle.Fill;
        this.addGroupButton.Location = new Point(499, 3);
        this.addGroupButton.Name = "addGroupButton";
        this.addGroupButton.Size = new Size(29, 28);
        this.addGroupButton.TabIndex = 2;
        this.addGroupButton.Text = "+";
        this.addGroupButton.UseVisualStyleBackColor = true;
        // 
        // tableLayoutPanel3
        // 
        this.tableLayoutPanel3.ColumnCount = 2;
        this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        this.tableLayoutPanel3.Controls.Add(this.groupBox1, 1, 0);
        this.tableLayoutPanel3.Controls.Add(this.peopleListBox, 0, 0);
        this.tableLayoutPanel3.Dock = DockStyle.Fill;
        this.tableLayoutPanel3.Location = new Point(3, 43);
        this.tableLayoutPanel3.Name = "tableLayoutPanel3";
        this.tableLayoutPanel3.RowCount = 1;
        this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel3.Size = new Size(566, 385);
        this.tableLayoutPanel3.TabIndex = 2;
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.flowLayoutPanel1);
        this.groupBox1.Dock = DockStyle.Fill;
        this.groupBox1.Location = new Point(419, 3);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new Size(144, 379);
        this.groupBox1.TabIndex = 1;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "People";
        // 
        // flowLayoutPanel1
        // 
        this.flowLayoutPanel1.Controls.Add(this.personAddButton);
        this.flowLayoutPanel1.Controls.Add(this.personUpButton);
        this.flowLayoutPanel1.Controls.Add(this.personDownButton);
        this.flowLayoutPanel1.Controls.Add(this.personRemoveButton);
        this.flowLayoutPanel1.Dock = DockStyle.Fill;
        this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        this.flowLayoutPanel1.Location = new Point(3, 19);
        this.flowLayoutPanel1.Name = "flowLayoutPanel1";
        this.flowLayoutPanel1.Size = new Size(138, 357);
        this.flowLayoutPanel1.TabIndex = 0;
        // 
        // personAddButton
        // 
        this.personAddButton.Location = new Point(3, 3);
        this.personAddButton.Name = "personAddButton";
        this.personAddButton.Size = new Size(132, 23);
        this.personAddButton.TabIndex = 0;
        this.personAddButton.Text = "Add Person";
        this.personAddButton.UseVisualStyleBackColor = true;
        // 
        // personUpButton
        // 
        this.personUpButton.Location = new Point(3, 32);
        this.personUpButton.Name = "personUpButton";
        this.personUpButton.Size = new Size(132, 23);
        this.personUpButton.TabIndex = 1;
        this.personUpButton.Text = "Move Up";
        this.personUpButton.UseVisualStyleBackColor = true;
        // 
        // personDownButton
        // 
        this.personDownButton.Location = new Point(3, 61);
        this.personDownButton.Name = "personDownButton";
        this.personDownButton.Size = new Size(132, 23);
        this.personDownButton.TabIndex = 2;
        this.personDownButton.Text = "Move Down";
        this.personDownButton.UseVisualStyleBackColor = true;
        // 
        // personRemoveButton
        // 
        this.personRemoveButton.Location = new Point(3, 90);
        this.personRemoveButton.Name = "personRemoveButton";
        this.personRemoveButton.Size = new Size(132, 23);
        this.personRemoveButton.TabIndex = 3;
        this.personRemoveButton.Text = "Remove Person";
        this.personRemoveButton.UseVisualStyleBackColor = true;
        // 
        // peopleListBox
        // 
        this.peopleListBox.Dock = DockStyle.Fill;
        this.peopleListBox.FormattingEnabled = true;
        this.peopleListBox.ItemHeight = 15;
        this.peopleListBox.Location = new Point(12, 12);
        this.peopleListBox.Margin = new Padding(12);
        this.peopleListBox.Name = "peopleListBox";
        this.peopleListBox.Size = new Size(392, 361);
        this.peopleListBox.TabIndex = 2;
        // 
        // PeoplePage
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.Controls.Add(this.tableLayoutPanel1);
        this.Name = "PeoplePage";
        this.Size = new Size(572, 431);
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel2.ResumeLayout(false);
        this.tableLayoutPanel2.PerformLayout();
        this.tableLayoutPanel3.ResumeLayout(false);
        this.groupBox1.ResumeLayout(false);
        this.flowLayoutPanel1.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private ComboBox groupsComboBox;
    private TableLayoutPanel tableLayoutPanel2;
    private Label label1;
    private Button addGroupButton;
    private Button removeGroupButton;
    private TableLayoutPanel tableLayoutPanel3;
    private GroupBox groupBox1;
    private FlowLayoutPanel flowLayoutPanel1;
    private Button personAddButton;
    private Button personUpButton;
    private Button personDownButton;
    private Button personRemoveButton;
    private ListBox peopleListBox;
}
