using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Tea.GraCh
{
    public partial class Punish2 : Form
    {
        string[] holidays = new string[7];
        readonly string group = null;
        readonly int? index = null;
        readonly int? dinm = null;

        readonly DateTime now = DateTime.Now;
        XmlNode BadUnit = null;
        public Punish2(string Grp, string Unit, int Index)
        {
            InitializeComponent();
            holidays = Tools.hday_init();
            Text = Grp + " -> " + Unit;
            group = Grp;
            index = Index;
            dinm = DateTime.DaysInMonth(now.Year, now.Month);

            dateTimePicker1.Value = Convert.ToDateTime($"{index}.{now.Month}.{now.Year}"); ;
            DayCheck();
            dateTimePicker1.MaxDate = Convert.ToDateTime($"{dinm}.{now.Month}.{now.Year}");
            dateTimePicker1.MinDate = Convert.ToDateTime($"{index}.{now.Month}.{now.Year}");

        }
        void DayCheck()
        {
            var gDoc = new XmlDocument();
            gDoc.Load(Tools.gPath);
            BadUnit = gDoc.DocumentElement.SelectSingleNode($"//{group}/unit[@day='{index}']");
            for (int notholiday = dateTimePicker1.Value.Day; Tools.is_holiday(dateTimePicker1.Value.DayOfWeek); notholiday++)
            {
                if (notholiday > dinm)
                {
                    for (notholiday--; Tools.is_holiday(Convert.ToDateTime($"{notholiday},{now.Month},{now.Year}").DayOfWeek); notholiday--) ;
                }
                dateTimePicker1.Value = Convert.ToDateTime($"{notholiday}.{now.Month}.{now.Year}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            insertUnit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DayCheck();
        }

        private int insertUnit()
        {
            if (Tools.is_graph) File.SetAttributes(Tools.gPath, FileAttributes.Normal);
            var gDoc = new XmlDocument();
            gDoc.Load(Tools.gPath);
            try
            {
                ////INSERT////
                XmlDocument gDoc_old = new XmlDocument();
                gDoc_old.Load(Tools.gPath);
                ////Zone under construction ////
                /*
                if (int.Parse(BadUnit.SelectSingleNode("@day").InnerText) + 1 !=
               int.Parse(BadUnit.NextSibling.SelectSingleNode("@day").InnerText))
                {
                    holidayLeap += 2;
                }

                XmlNode LoopUnit = gDoc.DocumentElement.SelectSingleNode($"//{group}/unit[@day='{index + i}']");
                    if (int.Parse(BadUnit.SelectSingleNode("@day").InnerText) + i !=
                   int.Parse(LoopUnit.NextSibling.SelectSingleNode("@day").InnerText))
                    {
                        holidayLeap += 1;
                    }
                */
                ///Duplication////
                int BadUnit_Day = int.Parse(BadUnit.Attributes.GetNamedItem("day").InnerText);
                int chosenDay = dateTimePicker1.Value.Day - (int)index;
                for (int i = 0, k = 1; k <= chosenDay; i++, k++)
                {
                    if (Tools.is_holiday(DateTime.Parse($"{BadUnit_Day + i},{now.Month},{now.Year}").DayOfWeek))
                    {
                        chosenDay--;
                    }
                    else
                    {
                        XDocument xgDoc = XDocument.Load(Tools.gPath);
                        XElement xUnit = new XElement("unit",
                            new XAttribute("day", BadUnit_Day + i),
                            BadUnit.InnerText
                            );
                        xgDoc.Root.XPathSelectElement($"//{group}/unit[@day='{index}']")
                            .AddAfterSelf(xUnit);
                        xgDoc.Save(Tools.gPath);
                    }
                }

                //Sort
                gDoc.Load(Tools.gPath);
                XmlNode GroupNode = gDoc.DocumentElement.SelectSingleNode($"{group}");
                XmlNode GroupNode_copy = gDoc_old.DocumentElement.SelectSingleNode($"{group}");
                for (int i = 1; i <= GroupNode.ChildNodes.Count; i++)
                {
                    if (i > GroupNode_copy.ChildNodes.Count)
                    {
                        GroupNode.RemoveChild(GroupNode.LastChild);
                        i--;
                    }
                }
                /*for (int i = 0; i < dateTimePicker1.Value.Day; i++)
                {
                    GroupNode.RemoveChild(GroupNode.LastChild);
                }*/
                gDoc.Save(Tools.gPath);

                if (GroupNode.ChildNodes.Count == GroupNode_copy.ChildNodes.Count)
                {
                    for (int i = 1; i <= GroupNode.ChildNodes.Count; i++)
                    {
                        GroupNode.SelectSingleNode($"//unit[{i}]/@day").InnerText =
                            GroupNode_copy.SelectSingleNode($"//unit[{i}]/@day").InnerText;
                    }
                    gDoc.Save(Tools.gPath);
                }
                else
                {
                    MessageBox.Show("Призначення штрафу не вдалося (1)", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (Tools.is_graph) File.SetAttributes(Tools.gPath, FileAttributes.Hidden);
                    return 1;
                }
                gDoc.Save(Tools.gPath);
                MessageBox.Show("Штраф успішно призначено!", "Інфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch
            {
                MessageBox.Show("Призначення штрафу не вдалося (2)", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Tools.is_graph) File.SetAttributes(Tools.gPath, FileAttributes.Hidden);
                return 2;
            }
            if (Tools.is_graph) File.SetAttributes(Tools.gPath, FileAttributes.Hidden);
            return 0;
        }

        private void Punish2_Leave(object sender, EventArgs e) => GC.Collect();
    }
}
