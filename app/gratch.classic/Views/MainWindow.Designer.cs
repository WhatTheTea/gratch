namespace gratch.classic;

partial class MainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.PeopleTabPage = new TabPage();
        this.ScheduleTabPage = new TabPage();
        this.HomeTabPage = new TabPage();
        this.homePage1 = new Views.HomePage();
        this.MainTabControl = new TabControl();
        this.schedulePage1 = new Views.SchedulePage();
        this.peoplePage1 = new Views.PeoplePage();
        this.PeopleTabPage.SuspendLayout();
        this.ScheduleTabPage.SuspendLayout();
        this.HomeTabPage.SuspendLayout();
        this.MainTabControl.SuspendLayout();
        this.SuspendLayout();
        // 
        // PeopleTabPage
        // 
        this.PeopleTabPage.Controls.Add(this.peoplePage1);
        this.PeopleTabPage.Location = new Point(4, 24);
        this.PeopleTabPage.Name = "PeopleTabPage";
        this.PeopleTabPage.Padding = new Padding(3);
        this.PeopleTabPage.Size = new Size(476, 253);
        this.PeopleTabPage.TabIndex = 2;
        this.PeopleTabPage.Text = "People";
        this.PeopleTabPage.UseVisualStyleBackColor = true;
        // 
        // ScheduleTabPage
        // 
        this.ScheduleTabPage.Controls.Add(this.schedulePage1);
        this.ScheduleTabPage.Location = new Point(4, 24);
        this.ScheduleTabPage.Name = "ScheduleTabPage";
        this.ScheduleTabPage.Padding = new Padding(3);
        this.ScheduleTabPage.Size = new Size(476, 253);
        this.ScheduleTabPage.TabIndex = 1;
        this.ScheduleTabPage.Text = "Schedule";
        this.ScheduleTabPage.UseVisualStyleBackColor = true;
        // 
        // HomeTabPage
        // 
        this.HomeTabPage.Controls.Add(this.homePage1);
        this.HomeTabPage.Location = new Point(4, 24);
        this.HomeTabPage.Name = "HomeTabPage";
        this.HomeTabPage.Padding = new Padding(3);
        this.HomeTabPage.Size = new Size(476, 253);
        this.HomeTabPage.TabIndex = 0;
        this.HomeTabPage.Text = "Home";
        this.HomeTabPage.UseVisualStyleBackColor = true;
        // 
        // homePage1
        // 
        this.homePage1.Dock = DockStyle.Fill;
        this.homePage1.Location = new Point(3, 3);
        this.homePage1.Name = "homePage1";
        this.homePage1.Size = new Size(470, 247);
        this.homePage1.TabIndex = 0;
        // 
        // MainTabControl
        // 
        this.MainTabControl.Controls.Add(this.HomeTabPage);
        this.MainTabControl.Controls.Add(this.ScheduleTabPage);
        this.MainTabControl.Controls.Add(this.PeopleTabPage);
        this.MainTabControl.Dock = DockStyle.Fill;
        this.MainTabControl.Location = new Point(0, 0);
        this.MainTabControl.Name = "MainTabControl";
        this.MainTabControl.SelectedIndex = 0;
        this.MainTabControl.Size = new Size(484, 281);
        this.MainTabControl.TabIndex = 0;
        // 
        // schedulePage1
        // 
        this.schedulePage1.Dock = DockStyle.Fill;
        this.schedulePage1.Location = new Point(3, 3);
        this.schedulePage1.Name = "schedulePage1";
        this.schedulePage1.Size = new Size(470, 247);
        this.schedulePage1.TabIndex = 0;
        // 
        // peoplePage1
        // 
        this.peoplePage1.Dock = DockStyle.Fill;
        this.peoplePage1.Location = new Point(3, 3);
        this.peoplePage1.Name = "peoplePage1";
        this.peoplePage1.Size = new Size(470, 247);
        this.peoplePage1.TabIndex = 0;
        // 
        // MainWindow
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(484, 281);
        this.Controls.Add(this.MainTabControl);
        this.MinimumSize = new Size(500, 320);
        this.Name = "MainWindow";
        this.Text = "gratch classic";
        this.PeopleTabPage.ResumeLayout(false);
        this.ScheduleTabPage.ResumeLayout(false);
        this.HomeTabPage.ResumeLayout(false);
        this.MainTabControl.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion

    private TabPage PeopleTabPage;
    private TabPage ScheduleTabPage;
    private TabPage HomeTabPage;
    private TabControl MainTabControl;
    private Views.HomePage homePage1;
    private Views.PeoplePage peoplePage1;
    private Views.SchedulePage schedulePage1;
}
