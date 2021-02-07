using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;
using System.Diagnostics;
using Tea.GraCh.Properties;
using System.Runtime.Hosting;
using System.Reflection;



namespace Tea.GraCh
{
    public partial class Main : Form
    {
        // l - List
        // g - Graph
        // x - XDocument (Linq)
        // XDocument is used for creating Xmls, XmlDocument - for reading here
        private string[] holidays = new string[7];
        private RedactG _RedactG = new RedactG(); //fix
        public Main()
        {
            InitializeComponent();
            holidays = Tools.hday_init();
            if (Tools.is_graph) UpdGraphInit();
            if (Tools.is_holiday(DateTime.Now.DayOfWeek)) label1.Location = new Point(46,label1.Location.Y);
            Start((int)numericUpDown1.Value);
            pictureBox1.Image = new Bitmap(Resources.ГрАч, pictureBox1.Size);
            GC.Collect();
        }

        public void UpdateGraf()
        {
            XmlDocument gDoc = new XmlDocument();
            XmlDocument lDoc = new XmlDocument();
            gDoc.Load(Tools.gPath);
            lDoc.Load(Tools.lPath);
            int gDocInt = gDoc.DocumentElement.ChildNodes.Count;
            int[] updst = new int[gDocInt];
            for (int k = 1; k < gDocInt + 1; k++)
            {
                foreach (XmlNode node in lDoc.DocumentElement.SelectNodes($"group{k}/*"))
                {
                    if (gDoc.DocumentElement.SelectSingleNode($"group{k}").LastChild.InnerText == node.InnerText)
                    {
                        updst[k - 1] = int.Parse(node.SelectSingleNode("@id").Value) + 1;
                        break;
                    }
                }
            }
            _RedactG.CreateGraph(updst);
        }
        public void UpdGraphInit()
        {

            XmlDocument gDoc = new XmlDocument();
            gDoc.Load(Tools.gPath);
            XmlNode dateNode = gDoc.DocumentElement.SelectSingleNode("date");
            string month = DateTime.Now.Month.ToString();
            if (dateNode.InnerText != month)
            {
                UpdateGraf();
                dateNode.InnerText = month;
                gDoc.Save(Tools.gPath); //
                new GLook().CallExcelFunc();
                MessageBox.Show("Графік оновлено!", "Інфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void clear_empty() //BugFix
        {
            if (Tools.is_graph)
            {
                XmlDocument gDoc = new XmlDocument();
                gDoc.Load(Tools.gPath);
                foreach (XmlNode node in gDoc.DocumentElement)
                    if (node.ChildNodes.Count == 0)
                    {
                        gDoc.DocumentElement.RemoveChild(node);
                        gDoc.Save(Tools.gPath);
                    }
            }
            if (Tools.is_list)
            {
                XmlDocument lDoc = new XmlDocument();
                lDoc.Load(Tools.lPath); //
                foreach (XmlNode node in lDoc.DocumentElement)
                    if (node.ChildNodes.Count == 0)
                    {
                        lDoc.DocumentElement.RemoveChild(node);
                        lDoc.Save(Tools.lPath);
                    }
            }
        }

        private void Start(int group)
        {
            DateTime now = DateTime.Now;

            clear_empty();

            if (Tools.is_graph)
            {

                if (Tools.is_holiday(now.DayOfWeek))
                {
                    label1.Text = "Сьогодні:";
                    textBox1.Text = "Вихідний день";
                }
                else
                {
                    XDocument xDoc = XDocument.Load(Tools.gPath);
                    try
                    {
                        foreach (XNode node in xDoc.Root.Elements($"group{group}"))
                        {
                            textBox1.Text = node.XPathSelectElement($"unit[@day='{now.Day}']").Value;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        File.Delete(Tools.gPath);
                        File.Delete(Tools.dPath);
                        File.Delete(Tools.lPath);
                        MessageBox.Show("Файл пошкоджено, графік було видалено", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _RedactG.ShowDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int group = (int)numericUpDown1.Value;
                if (Tools.is_graph)
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(Tools.gPath);
                    if (numericUpDown1.Value < xml.DocumentElement.ChildNodes.Count)
                    {
                        Start(group);
                    }
                    else { numericUpDown1.Value--; }
                }
                else { numericUpDown1.Value--; }
            }
            catch
            {
                //do_nothing
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Tools.is_graph)
            {
                new GLook().Show();
            }
            else
            {
                MessageBox.Show("Не створено графіку чергових", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Main_Activated(object sender, EventArgs e)
        {
            Start((int)numericUpDown1.Value);
            if (File.Exists("ГраЧ.pdf")) File.Delete("ГраЧ.pdf");
            holidays = Tools.hday_init();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(Resources.ГрАч, pictureBox1.Size);
        }

        private void інфоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new icons.About().Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var fs = new FileStream("ГраЧ.pdf", FileMode.Create, FileAccess.Write))
            {
                fs.Write(Resources.Tutorial, 0, Resources.Tutorial.Length);
                fs.Close();
                Process.Start("ГраЧ.pdf");
            }
        }
    }
}
