using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tea.GraCh.icons
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            label1.Text = "Версія: 0.(9)";
            pictureBox1.Image = new Bitmap(Properties.Resources.ГрАч, pictureBox1.Size);
            GC.Collect();
        }
    }
}
