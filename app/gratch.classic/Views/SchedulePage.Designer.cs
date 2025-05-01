namespace gratch.classic.Views;

partial class SchedulePage
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
        this.label1 = new Label();
        this.groupsComboBox = new ComboBox();
        this.scheduleDataGrid = new DataGridView();
        this.tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.scheduleDataGrid).BeginInit();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.ColumnCount = 2;
        this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 94F));
        this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.groupsComboBox, 1, 0);
        this.tableLayoutPanel1.Controls.Add(this.scheduleDataGrid, 0, 1);
        this.tableLayoutPanel1.Dock = DockStyle.Fill;
        this.tableLayoutPanel1.Location = new Point(0, 0);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 2;
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        this.tableLayoutPanel1.Size = new Size(468, 389);
        this.tableLayoutPanel1.TabIndex = 0;
        // 
        // label1
        // 
        this.label1.Anchor = AnchorStyles.Left;
        this.label1.AutoSize = true;
        this.label1.Location = new Point(10, 12);
        this.label1.Margin = new Padding(10, 0, 3, 0);
        this.label1.Name = "label1";
        this.label1.Size = new Size(76, 15);
        this.label1.TabIndex = 0;
        this.label1.Text = "Schedule for:";
        // 
        // groupsComboBox
        // 
        this.groupsComboBox.Dock = DockStyle.Fill;
        this.groupsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        this.groupsComboBox.FormattingEnabled = true;
        this.groupsComboBox.Location = new Point(104, 10);
        this.groupsComboBox.Margin = new Padding(10);
        this.groupsComboBox.Name = "groupsComboBox";
        this.groupsComboBox.Size = new Size(354, 23);
        this.groupsComboBox.TabIndex = 1;
        // 
        // scheduleDataGrid
        // 
        this.scheduleDataGrid.AllowUserToAddRows = false;
        this.scheduleDataGrid.AllowUserToDeleteRows = false;
        this.scheduleDataGrid.AllowUserToResizeColumns = false;
        this.scheduleDataGrid.AllowUserToResizeRows = false;
        this.scheduleDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
        this.scheduleDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
        this.scheduleDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.tableLayoutPanel1.SetColumnSpan(this.scheduleDataGrid, 2);
        this.scheduleDataGrid.Dock = DockStyle.Fill;
        this.scheduleDataGrid.Location = new Point(12, 52);
        this.scheduleDataGrid.Margin = new Padding(12);
        this.scheduleDataGrid.Name = "scheduleDataGrid";
        this.scheduleDataGrid.ReadOnly = true;
        this.scheduleDataGrid.ShowEditingIcon = false;
        this.scheduleDataGrid.Size = new Size(444, 325);
        this.scheduleDataGrid.TabIndex = 2;
        // 
        // SchedulePage
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.Controls.Add(this.tableLayoutPanel1);
        this.Name = "SchedulePage";
        this.Size = new Size(468, 389);
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.scheduleDataGrid).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Label label1;
    private ComboBox groupsComboBox;
    private DataGridView scheduleDataGrid;
}
