#define MSBOX
#undef MSBOX

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using System.IO;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Formula.Functions;

namespace Tea.GraCh
{
    public partial class GLook : Form
    {
        private string[] holidays = new string[7];
        private readonly string[] Days =
        {
            "Нд",
            "Пн",
            "Вт",
            "Ср",
            "Чт",
            "Пт",
            "Сб"
        };
        public GLook()
        {
            InitializeComponent();
            holidays = Tools.hday_init();
            DateTime now = DateTime.Now;
            label2.Text = "Сьогодні: " + now.ToShortDateString();
            if (Tools.is_graph)
            {
                Start((int)numericUpDown1.Value);
                ForDay();
            }
        }
        public void Start(int group)
        {
            XmlDocument gDoc = new XmlDocument();
            gDoc.Load(Tools.gPath);
            foreach (XmlNode node in gDoc.DocumentElement.ChildNodes)
            {
                if (node.ChildNodes.Count > 0)
                {
                    if (node.Name == $"group{group}")
                    {
                        foreach (XmlNode unit in node.ChildNodes)
                        {
                            if (Int32.Parse(unit.Attributes.GetNamedItem("day").InnerText) < 10)
                            {
                                listBox1.Items.Add("  0" + unit.Attributes.GetNamedItem("day").InnerText +
                                    " |    " + unit.InnerText);
                            }
                            else
                            {
                                listBox1.Items.Add($"  {unit.Attributes.GetNamedItem("day").InnerText}" + " |    "
                                    + unit.InnerText);
                            }
                        }
                    }
                }
            }
        }
        private void ForDay()
        {
            DateTime now = DateTime.Now;
            int dinm = DateTime.DaysInMonth(now.Year, now.Month);
            dateTimePicker1.MaxDate = Convert.ToDateTime($"{dinm}.{now.Month}.{now.Year}");
            dateTimePicker1.MinDate = Convert.ToDateTime($"1.{now.Month}.{now.Year}");
            XmlDocument graph = new XmlDocument();
            graph.Load(Tools.gPath);

            for (int notholiday = dateTimePicker1.Value.Day; Tools.is_holiday(dateTimePicker1.Value.DayOfWeek); notholiday++)
            {
                if (notholiday > dinm)
                {
                    for (notholiday--; Tools.is_holiday(Convert.ToDateTime($"{notholiday},{now.Month},{now.Year}").DayOfWeek); notholiday--);
                }
                dateTimePicker1.Value = Convert.ToDateTime($"{notholiday}.{now.Month}.{now.Year}");
            } // Доработать, шоб красиво было, не с единички, а в обратную сторону. 
              // Сделал :>
            foreach (XmlNode node in graph.DocumentElement)
            {
                if (node.Name.StartsWith("group"))
                {
                    TreeNode grp = new TreeNode(node.Name);
                    grp.Nodes.Add("Черговий: " + node.SelectSingleNode($"unit[@day='{dateTimePicker1.Value.Day}']").InnerText);
                    treeView1.Nodes.Add(grp);
                }
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (Tools.is_graph)
            {
                XmlDocument gDoc = new XmlDocument();
                gDoc.Load(Tools.gPath);
                if (numericUpDown1.Value < gDoc.DocumentElement.ChildNodes.Count)
                {
                    Start((int)numericUpDown1.Value);
                }
                else { numericUpDown1.Value--; }
            }
        }

        private void GLook_Activated(object sender, EventArgs e)
        {
            if (Tools.is_graph)
            {
                listBox1.Items.Clear();
                Start((int)numericUpDown1.Value);
                treeView1.Nodes.Clear();
                ForDay();
            }
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            ForDay();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int naturalIndex = listBox1.SelectedIndex + 1;
            XmlDocument gDoc = new XmlDocument();
            gDoc.Load(Tools.gPath);
            XmlNode BadUnit = gDoc.DocumentElement.SelectSingleNode($"group{numericUpDown1.Value}/unit[{naturalIndex}]");
            int index = int.Parse(BadUnit.SelectSingleNode("@day").InnerText);
            new Punish2(BadUnit.ParentNode.LocalName, BadUnit.InnerText, index).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new RedactG().CreateGraph();
            listBox1.Items.Clear();
            Start((int)numericUpDown1.Value);
            treeView1.Nodes.Clear();
            ForDay();
            //if (File.Exists($@"{CD}\studs.xml")) File.SetAttributes($@"{CD}\studs.xml", FileAttributes.Hidden);
            //if (File.Exists($@"{CD}\grafik.xml")) File.SetAttributes($@"{CD}\grafik.xml", FileAttributes.Hidden);
        }

        public void ExcelCreator(int grp, IWorkbook book)
        {
            //int grp = (int)numericUpDown1.Value;
            int dayinmon = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            XmlDocument lDoc = new XmlDocument();
            lDoc.Load(Tools.lPath);
            int unitCount = lDoc.DocumentElement.SelectSingleNode($"group{grp}").ChildNodes.Count;
            //Excel
            //Создание воркбука происходит в вызывающей функции.
            ISheet sht = book.CreateSheet($"ГраЧ | Група {grp}");
            //Styles
            var HolidayStyle = Tools.StyleGenerator(book, IndexedColors.Grey25Percent.Index, FillPattern.SolidForeground);
            var EmptyStyle = Tools.StyleGenerator(book, IndexedColors.White.Index, FillPattern.NoFill);
            var UnitStyle = Tools.StyleGenerator(book, IndexedColors.LightGreen.Index, FillPattern.SolidForeground);
            var TopStyle = Tools.StyleGenerator(book, IndexedColors.Grey25Percent.Index, FillPattern.ThinBackwardDiagonals);
            var DutyStyle = Tools.StyleGenerator(book, IndexedColors.SkyBlue.Index, FillPattern.SolidForeground);
            //CellDraw
            IRow row = sht.CreateRow(0);
            ICell cell;

            for (int i = 0; i <= unitCount; i++)
            {
                row = sht.CreateRow(i);
                for (int c = 0; c <= dayinmon; c++)
                {
                    row.CreateCell(c);
                    row.GetCell(c).CellStyle = EmptyStyle;
                }
            }

            //CellFill
            sht.SetColumnWidth(0, 10000);
            row.HeightInPoints = 25;
            for (int i = 1, cellvalue = 1; i <= dayinmon; i++, cellvalue++)
            {
                DayOfWeek dof = Convert.ToDateTime($"{i}." +
                    $"{DateTime.Now.Month}.{DateTime.Now.Year}").DayOfWeek;
                row = sht.GetRow(0);
                cell = row.GetCell(i);
                sht.SetColumnWidth(i, 1370);
                cell.CellStyle = TopStyle;
                if (Tools.is_holiday(dof))
                {
                    cell.CellStyle = HolidayStyle;
                    for (int k = 1; k <= unitCount; k++)
                    {
                        sht.GetRow(k).GetCell(i).CellStyle = HolidayStyle;
                    }
                }

                cell.SetCellValue(cellvalue + " " + Days[(int)(DateTime.Parse($"{cellvalue},{DateTime.Now.Month},{DateTime.Now.Year}").DayOfWeek)]);              //Привет
            }

            row.GetCell(0).SetCellValue(@"Ім'я\Число");
            row.GetCell(0).CellStyle = TopStyle;

            for (int rm = 1; rm <= unitCount; rm++)
            {
                row = sht.GetRow(rm);
                row.HeightInPoints = 20;
                cell = row.GetCell(0);
                cell.SetCellValue(
                lDoc.DocumentElement.SelectSingleNode($"//group{grp}/unit[{rm}]").InnerText);
                cell.CellStyle = UnitStyle;
            }

            //DutyCheck
            XmlDocument gDoc = new XmlDocument();
            gDoc.Load(Tools.gPath);
            string dof_copy;
            for (int i = 1, j = 1; j <= dayinmon; i++, j++)
            {
                if (i > unitCount) i = 1;
                row = sht.GetRow(i);
                for (int d = 1; d <= dayinmon; d++)
                {
                    dof_copy = $"{d}.{DateTime.Now.Month}.{DateTime.Now.Year}";
                    cell = row.GetCell(d);
                    if (cell == null || cell.CellType == CellType.Blank)
                    {
                        DayOfWeek dof = Convert.ToDateTime(dof_copy).DayOfWeek;
                        if (!Tools.is_holiday(dof))
                        {
                            string dStr = gDoc.DocumentElement
                                .SelectSingleNode($"//group{grp}/unit[@day='{d}']").InnerText;
                            string iStr = lDoc.DocumentElement
                                .SelectSingleNode($"//group{grp}/unit[{i}]").InnerText;
                            if (dStr == iStr)
                            {
                                //cell.SetCellValue($"{i}|{j}|{d}");
                                cell.CellStyle = DutyStyle;
                            }
                        }
                    }
                }
            }
        }

        public void CallExcelFunc()
        {
            XmlDocument lDoc = new XmlDocument();
            lDoc.Load(Tools.lPath);
            IWorkbook book = new XSSFWorkbook();
            for (int grp = 1; grp <= lDoc.DocumentElement.ChildNodes.Count; grp++) ExcelCreator(grp, book);
            book.Write(File.Create("ГраЧ - Версія для друку.xlsx"));
            book.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CallExcelFunc();
            try
            {
                Process.Start("ГраЧ - Версія для друку.xlsx");
            }
            catch
            {
                //do nothing
            }
            finally
            {
#if (MSBOX)
            MessageBox.Show("Файл створено", "Інфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif
            }
        }

        private void GLook_Leave(object sender, EventArgs e) => GC.Collect();
    }
}
