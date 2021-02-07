using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using NPOI.SS.Formula.Functions;
using System.Diagnostics.Eventing.Reader;

namespace Tea.GraCh
{
    public partial class RedactG : Form
    {
        private static DateTime now => DateTime.Now;
        private string[] holidays = new string[7];
        private int _UnitId = 1, maxUnit = 0;

        public RedactG()
        {
            InitializeComponent();
            holidays = Tools.hday_init();
            Start();
            button4.Image = new Bitmap(Properties.Resources.trash, new Size(18, 17));
        }
        public void CreateGraph(int[] global_UnitId = null)
        {
            XDocument xgDoc = new XDocument(new XElement($"groups"));
            XmlDocument lDoc = new XmlDocument();
            int group = 1;
            int dayinmon_now = DateTime.DaysInMonth(now.Year, now.Month);
            lDoc.Load(Tools.lPath);
            for (int k = 0; k < lDoc.DocumentElement.ChildNodes.Count; k++, group++)
            {
                xgDoc.Root.Add(new XElement($"group{group}"));
                for (int i = 1, UnitId = global_UnitId == null ? 1 : global_UnitId[k]; i <= dayinmon_now; i++, UnitId++)
                {
                    foreach (XmlNode node in lDoc.DocumentElement.SelectNodes($"group{group}"))
                    {
                        if (node.ChildNodes.Count > 0)
                        {
                            if (node.SelectSingleNode($"unit[@id='{UnitId}']") != null)
                            {
                                if (!Tools.is_holiday(Tools.dayweek(i)))
                                {
                                    XmlNode unit = node.SelectSingleNode($"unit[{UnitId}]");
                                    XElement xUnit = new XElement("unit",
                                        new XAttribute("day", i),
                                        unit.InnerText
                                        );
                                    xgDoc.Root.Element($"group{group}").Add(xUnit);
                                }
                                else
                                {
                                    UnitId--;
                                }
                            }
                            else
                            {
                                UnitId = 0; i--;
                            }
                        }
                    }
                }
            }
            xgDoc.Root.Add(new XElement("date", now.Month));
            group = (int)numericUpDown1.Value;
            Tools.SaveHidden(Tools.gPath, xgDoc);
        }
        public void ImportGraph(StreamReader list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            XDocument xlDoc;
            XElement UnitElem, GroupElem;
            XmlDocument lDoc = new XmlDocument();
            int group = (int)numericUpDown1.Value;
            for (; !list.EndOfStream;)
            {
                string unit = list.ReadLine();
                if (Tools.is_list)
                {
                    var xlDoc_copy = new XmlDocument();
                    xlDoc_copy.Load(Tools.lPath);
                    xlDoc = XDocument.Load(Tools.lPath);
                    UnitElem = new XElement(
                        new XElement("unit",
                        new XAttribute("id", _UnitId++),
                        unit
                        ));
                    GroupElem = new XElement($"group{group}");
                    bool is_new_grp = true;
                    foreach (XmlNode node in xlDoc_copy.DocumentElement.ChildNodes)
                    {
                        if (node.ChildNodes.Count > 0 && node.LocalName == $"group{group}")
                        {
                            is_new_grp = false;
                        }
                    }
                    if (is_new_grp)
                    {
                        xlDoc.Root.Add(GroupElem);
                    }
                    xlDoc.Root.Element($"group{group}").Add(UnitElem);
                    listBox1.Items.Add(unit);

                    Tools.SaveHidden(Tools.lPath, xlDoc);
                    CreateGraph();
                }
                else
                {
                    xlDoc = new XDocument(new XElement($"units",
                        new XElement($"group{group}",
                        new XElement("unit",
                        new XAttribute("id", _UnitId++),
                        unit))));
                    xlDoc.Save(Tools.lPath);
                    listBox1.Items.Add(unit);
                }
                lDoc.Load(Tools.lPath);
                foreach (XmlNode node in lDoc.DocumentElement.ChildNodes)
                {
                    maxUnit = node.ChildNodes.Count;
                    for (int i = 1; i <= maxUnit; i++)
                    {
                        if (node.ChildNodes.Count > 0)
                        {
                            if (node.LocalName == $"group{group}")
                            {
                                node.SelectSingleNode($"unit[{i}]/@id").InnerText = i.ToString();
                            }
                        }
                    }
                }
                _UnitId = maxUnit + 1;
                Tools.SaveHidden(Tools.lPath, lDoc);
            }
        }

        private void Start()
        {
            int group = (int)numericUpDown1.Value;
            listBox1.Items.Clear();
            if (Tools.is_list)
            {
                XDocument xlDoc = XDocument.Load(Tools.lPath);
                XmlDocument lDoc = new XmlDocument();
                lDoc.Load(Tools.lPath);
                foreach (XmlNode node in lDoc.DocumentElement.ChildNodes)
                {
                    if (node.ChildNodes.Count > 0)
                    {
                        if (node.LocalName == $"group{group}")
                        {
                            foreach (XElement unit in xlDoc.Root.XPathSelectElements($"//group{group}/unit"))
                            {
                                listBox1.Items.Add(unit.Value);
                                maxUnit++;
                            }
                        }
                    }
                }
                _UnitId += maxUnit;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 1)
            {
                int group = (int)numericUpDown1.Value;
                XDocument xlDoc;
                XElement UnitElem, GroupElem;
                XmlDocument lDoc_copy = new XmlDocument();
                if (Tools.is_list)
                {
                    xlDoc = XDocument.Load(Tools.lPath);
                    UnitElem = new XElement(
                        new XElement("unit",
                        new XAttribute("id", _UnitId++),
                        textBox1.Text
                        ));
                    GroupElem = new XElement($"group{group}");
                    var lDoc = new XmlDocument();
                    bool is_new_grp = true;
                    lDoc.Load(Tools.lPath);
                    foreach (XmlNode node in lDoc.DocumentElement.ChildNodes)
                    {
                        if (node.ChildNodes.Count > 0)
                        {
                            if (node.LocalName == $"group{group}")
                            {
                                is_new_grp = false;
                            }
                        }
                    }
                    if (is_new_grp) xlDoc.Root.Add(GroupElem);

                    xlDoc.Root.Element($"group{group}").Add(UnitElem);
                    listBox1.Items.Add(textBox1.Text);
                    Tools.SaveHidden(Tools.lPath, xlDoc);
                    CreateGraph();
                }
                else
                {
                    xlDoc = new XDocument(new XElement($"units",
                        new XElement($"group{group}",
                        new XElement("unit",
                        new XAttribute("id", _UnitId++),
                        textBox1.Text))));
                    Tools.SaveHidden(Tools.lPath, xlDoc);
                    listBox1.Items.Add(textBox1.Text);
                    CreateGraph();
                }

                lDoc_copy.Load(Tools.lPath);
                foreach (XmlNode node in lDoc_copy.DocumentElement.ChildNodes)
                {
                    maxUnit = node.ChildNodes.Count;
                    for (int i = 1; i <= maxUnit; i++)
                    {
                        if (node.ChildNodes.Count > 0)
                        {
                            if (node.LocalName == $"group{group}")
                            {
                                node.SelectSingleNode($"unit[{i}]/@id").InnerText = i.ToString();
                            }
                        }
                    }
                }
                _UnitId = maxUnit + 1;
                Tools.SaveHidden(Tools.lPath, lDoc_copy);
            }
            else
            {
                MessageBox.Show("Ім'я не може бути менше 2 символів", "Помилка",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Clear();

            if (Tools.is_graph)
            {
                XmlDocument gDoc = new XmlDocument();
                gDoc.Load(Tools.gPath);
                numericUpDown1.Maximum = gDoc.DocumentElement.ChildNodes.Count;
            }
            else
            {
                numericUpDown1.Maximum = 2;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button2_Click(sender, e);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            int unitid = listBox1.SelectedIndex;
            if (unitid >= 0)
            {
                XmlDocument lDoc = new XmlDocument();
                int group = (int)numericUpDown1.Value;
                lDoc.Load(Tools.lPath);
                foreach (XmlNode node in lDoc.DocumentElement.ChildNodes)
                {
                    if (node.ChildNodes.Count > 0)
                    {
                        if (node.LocalName == $"group{group}")
                        {
                            XmlNode unit = node.SelectSingleNode($"unit[@id='{unitid + 1}']");
                            node.RemoveChild(unit);
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                            maxUnit = node.ChildNodes.Count;
                            for (int i = 1; i <= maxUnit; i++)
                            {
                                node.SelectSingleNode($"unit[{i}]/@id").InnerText
                                    = i.ToString();
                            }
                            _UnitId = maxUnit + 1;
                        }
                    }
                }

                Tools.SaveHidden(Tools.lPath, lDoc);
                if (Tools.is_graph) File.Delete(Tools.gPath);
                CreateGraph();
            }
            else { MessageBox.Show("Виберіть елемент", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (listBox1.Items.Count == 0 && Tools.is_graph && Tools.is_list)
            {
                xmlDoc.Load(Tools.lPath);
                xmlDoc.DocumentElement.RemoveChild(
                    xmlDoc.DocumentElement.SelectSingleNode($"group{numericUpDown1.Value}"));
                xmlDoc.Save(Tools.lPath);
                xmlDoc.Load(Tools.gPath);
                xmlDoc.DocumentElement.RemoveChild(
                    xmlDoc.DocumentElement.SelectSingleNode($"group{numericUpDown1.Value}"));
                xmlDoc.Save(Tools.gPath);
                RefreshGroups(); //Если чё, сюды
            }
            xmlDoc.Load(Tools.gPath);
            numericUpDown1.Maximum = xmlDoc.DocumentElement.ChildNodes.Count;
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                button1_Click(sender, e);
            }
        }
        // <IMPORT>
        private void button3_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            StreamReader impTxt = new StreamReader(openFileDialog1.FileName, Encoding.Default); //Опасный дефолт, в случае краказябр - сюды
            XmlDocument gDoc = new XmlDocument();
            //MessageBox.Show(impTxt.ReadToEnd());
            ImportGraph(impTxt);
            CreateGraph();
            gDoc.Load(Tools.gPath);
            numericUpDown1.Maximum = gDoc.DocumentElement.ChildNodes.Count;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Tools.is_list) File.Delete(Tools.lPath);
            if (Tools.is_graph) File.Delete(Tools.gPath);
            if (Tools.is_days) File.Delete(Tools.dPath);
            _UnitId = 1;
            maxUnit = 0;
            Start();
            numericUpDown1.Value = 1;
            MessageBox.Show("Графік успішно видалено", "Інфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // </IMPORT>
        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            XmlDocument gDoc = new XmlDocument();
            if (Tools.is_graph)
            {
                gDoc.Load(Tools.gPath);
                numericUpDown1.Maximum = gDoc.DocumentElement.ChildNodes.Count;
            }
            else numericUpDown1.Maximum = 2;

            int group = (int)numericUpDown1.Value;
            listBox1.Items.Clear();
            if (!Tools.is_list)
            {
                if (numericUpDown1.Value == 1)
                {
                    MessageBox.Show("Треба створити список учнів", "Інфо",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                numericUpDown1.Value = 1;
            }
            else
            {
                XDocument xlDoc = XDocument.Load(Tools.lPath);
                var lDoc = new XmlDocument();
                lDoc.Load(Tools.lPath);
                _UnitId = 1;
                maxUnit = 0;
                foreach (XmlNode node in lDoc.DocumentElement.ChildNodes)
                {
                    if (node.ChildNodes.Count > 0)
                    {
                        if (node.LocalName == $"group{group}")
                        {
                            foreach (XElement it in xlDoc.Root.XPathSelectElements($"group{group}/unit"))
                            {
                                listBox1.Items.Add(it.Value);
                                maxUnit++;
                            }
                        }
                    }
                }
                _UnitId += maxUnit;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Holidays().ShowDialog();
        }

        private void RedactG_Activated(object sender, EventArgs e)
        {
            holidays = Tools.hday_init();
        }

        private void RedactG_Leave(object sender, EventArgs e) => GC.Collect();

        private void RefreshGroups()
        {
            XDocument xlDoc = XDocument.Load(Tools.lPath);
            int i = 1;
            foreach (XElement xEl in xlDoc.Root.Elements())
            {
                xEl.Name = $"group{i}";
                i++;
            }
            xlDoc.Save(Tools.lPath);
            if (Tools.is_graph) File.Delete(Tools.lPath);
            CreateGraph();
            Start();
        }
    }
}