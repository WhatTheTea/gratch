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
        this.button2 = new Button();
        this.comboBox1 = new ComboBox();
        this.label1 = new Label();
        this.button1 = new Button();
        this.tableLayoutPanel3 = new TableLayoutPanel();
        this.listView1 = new ListView();
        this.groupBox1 = new GroupBox();
        this.flowLayoutPanel1 = new FlowLayoutPanel();
        this.personAddButton = new Button();
        this.personUpButton = new Button();
        this.personDownButton = new Button();
        this.personRemoveButton = new Button();
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
        this.tableLayoutPanel2.Controls.Add(this.button2, 3, 0);
        this.tableLayoutPanel2.Controls.Add(this.comboBox1, 1, 0);
        this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
        this.tableLayoutPanel2.Controls.Add(this.button1, 2, 0);
        this.tableLayoutPanel2.Dock = DockStyle.Fill;
        this.tableLayoutPanel2.Location = new Point(3, 3);
        this.tableLayoutPanel2.Name = "tableLayoutPanel2";
        this.tableLayoutPanel2.RowCount = 1;
        this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel2.Size = new Size(566, 34);
        this.tableLayoutPanel2.TabIndex = 1;
        // 
        // button2
        // 
        this.button2.Dock = DockStyle.Fill;
        this.button2.Location = new Point(534, 3);
        this.button2.Name = "button2";
        this.button2.Size = new Size(29, 28);
        this.button2.TabIndex = 3;
        this.button2.Text = "-";
        this.button2.UseVisualStyleBackColor = true;
        // 
        // comboBox1
        // 
        this.comboBox1.Dock = DockStyle.Fill;
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new Point(69, 5);
        this.comboBox1.Margin = new Padding(5);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new Size(422, 23);
        this.comboBox1.TabIndex = 0;
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
        // button1
        // 
        this.button1.Dock = DockStyle.Fill;
        this.button1.Location = new Point(499, 3);
        this.button1.Name = "button1";
        this.button1.Size = new Size(29, 28);
        this.button1.TabIndex = 2;
        this.button1.Text = "+";
        this.button1.UseVisualStyleBackColor = true;
        // 
        // tableLayoutPanel3
        // 
        this.tableLayoutPanel3.ColumnCount = 2;
        this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        this.tableLayoutPanel3.Controls.Add(this.listView1, 0, 0);
        this.tableLayoutPanel3.Controls.Add(this.groupBox1, 1, 0);
        this.tableLayoutPanel3.Dock = DockStyle.Fill;
        this.tableLayoutPanel3.Location = new Point(3, 43);
        this.tableLayoutPanel3.Name = "tableLayoutPanel3";
        this.tableLayoutPanel3.RowCount = 1;
        this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel3.Size = new Size(566, 385);
        this.tableLayoutPanel3.TabIndex = 2;
        // 
        // listView1
        // 
        this.listView1.Dock = DockStyle.Fill;
        this.listView1.Location = new Point(12, 12);
        this.listView1.Margin = new Padding(12);
        this.listView1.Name = "listView1";
        this.listView1.Size = new Size(392, 361);
        this.listView1.TabIndex = 0;
        this.listView1.UseCompatibleStateImageBehavior = false;
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
    private ComboBox comboBox1;
    private TableLayoutPanel tableLayoutPanel2;
    private Label label1;
    private Button button1;
    private Button button2;
    private TableLayoutPanel tableLayoutPanel3;
    private ListView listView1;
    private GroupBox groupBox1;
    private FlowLayoutPanel flowLayoutPanel1;
    private Button personAddButton;
    private Button personUpButton;
    private Button personDownButton;
    private Button personRemoveButton;
}
