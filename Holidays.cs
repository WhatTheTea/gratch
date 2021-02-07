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
    public partial class Holidays : Form
    {
        private readonly string[] Days =
        {
            "Понеділок",
            "Вівторок",
            "Середа",
            "Четвер",
            "П'ятниця",
            "Субота",
            "Неділя"
        };
        public Holidays()
        {
            InitializeComponent();
            if (!Tools.is_days) CreateFile();
            LoadFileToList();
        }

        public void CreateFile(bool?[] is_hday = null)
        {
            XDocument xDays = new XDocument();
            XElement rootElement = new XElement("days");
            for (DayOfWeek it = DayOfWeek.Monday; ; it++)
            {
                if (it == (DayOfWeek)7) it = 0;
                rootElement.Add(new XElement($"{it}", is_hday == null ? false : is_hday[(int)it]));
                if (it == (DayOfWeek)0) break;
            }
            xDays.Add(rootElement);
            //xDays.Save(Tools.dPath);
            Tools.SaveHidden(Tools.dPath, xDays);
            if (Tools.is_graph) new RedactG().CreateGraph();
        }
        void LoadFileToList()
        {
            XDocument xDays = XDocument.Load(Tools.dPath);
            checkedListBox1.Items.Clear();
            for (int i = 0; i < 7; i++)
            {
                checkedListBox1.Items.Add(Days[i], bool.Parse(xDays.XPathSelectElement($"*/" +
                    $"{(i + 1 != 7 ? (DayOfWeek)(i + 1) : (DayOfWeek)0)}").Value));
            }
        }
        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            bool?[] is_hday = new bool?[7];
            for (int i = 1, item = 0; i < 7; i++, item++)
            {
                is_hday[i] = checkedListBox1.GetItemChecked(item);
            }
            is_hday[0] = checkedListBox1.GetItemChecked(6);
            File.Delete(Tools.dPath);
            CreateFile(is_hday);
        }

        private void Holidays_Leave(object sender, EventArgs e) => GC.Collect();
    }
}
