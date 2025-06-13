namespace gratch.classic.Views;

partial class HomePage
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
        this.calendar = new MonthCalendar();
        this.scheduleListView = new ListView();
        this.label2 = new Label();
        this.label3 = new Label();
        this.tableLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.ColumnCount = 2;
        this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.calendar, 0, 2);
        this.tableLayoutPanel1.Controls.Add(this.scheduleListView, 1, 2);
        this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
        this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
        this.tableLayoutPanel1.Dock = DockStyle.Fill;
        this.tableLayoutPanel1.Location = new Point(0, 0);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 3;
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
        this.tableLayoutPanel1.Size = new Size(508, 261);
        this.tableLayoutPanel1.TabIndex = 0;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.label1.Location = new Point(10, 10);
        this.label1.Margin = new Padding(10);
        this.label1.Name = "label1";
        this.label1.Size = new Size(142, 19);
        this.label1.TabIndex = 0;
        this.label1.Text = "gratch classic v0.1.0";
        // 
        // calendar
        // 
        this.calendar.Dock = DockStyle.Fill;
        this.calendar.Location = new Point(9, 69);
        this.calendar.Name = "calendar";
        this.calendar.TabIndex = 1;
        // 
        // scheduleListView
        // 
        this.scheduleListView.Alignment = ListViewAlignment.Default;
        this.scheduleListView.Dock = DockStyle.Fill;
        this.scheduleListView.FullRowSelect = true;
        this.scheduleListView.Location = new Point(227, 69);
        this.scheduleListView.Margin = new Padding(24, 9, 24, 24);
        this.scheduleListView.Name = "scheduleListView";
        this.scheduleListView.Size = new Size(257, 168);
        this.scheduleListView.TabIndex = 2;
        this.scheduleListView.UseCompatibleStateImageBehavior = false;
        this.scheduleListView.View = View.Tile;
        // 
        // label2
        // 
        this.label2.Anchor = AnchorStyles.Left;
        this.label2.AutoSize = true;
        this.label2.Location = new Point(24, 42);
        this.label2.Margin = new Padding(24, 0, 3, 0);
        this.label2.Name = "label2";
        this.label2.Size = new Size(54, 15);
        this.label2.TabIndex = 3;
        this.label2.Text = "Calendar";
        // 
        // label3
        // 
        this.label3.Anchor = AnchorStyles.Left;
        this.label3.AutoSize = true;
        this.label3.Location = new Point(227, 42);
        this.label3.Margin = new Padding(24, 0, 3, 0);
        this.label3.Name = "label3";
        this.label3.Size = new Size(141, 15);
        this.label3.TabIndex = 4;
        this.label3.Text = "Schedule for selected day";
        // 
        // HomePage
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.Controls.Add(this.tableLayoutPanel1);
        this.Name = "HomePage";
        this.Size = new Size(508, 261);
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Label label1;
    private MonthCalendar calendar;
    private ListView scheduleListView;
    private Label label2;
    private Label label3;
}
