using System.Xml.Linq;
using System.IO;
using System.Xml;
using System;
using NPOI.SS.UserModel;

namespace Tea.GraCh
{
    public class Tools
    {
        //Тексты и були
        public static readonly string gPath = $@"{Environment.CurrentDirectory}//graph.xml";
        public static readonly string lPath = $@"{Environment.CurrentDirectory}//list.xml";
        public static readonly string dPath = $@"{Environment.CurrentDirectory}//days.xml";
        public static bool is_graph => File.Exists(gPath);
        public static bool is_list => File.Exists(lPath);
        public static bool is_days => File.Exists(dPath);
        //Сохраняет файл с аттрибутом "Скрытый"
        public static void SaveHidden(string path, XDocument doc)
        {
            if (File.Exists(path)) File.SetAttributes(path, FileAttributes.Normal);
            doc.Save(path);
            if (File.Exists(path)) File.SetAttributes(path, FileAttributes.Hidden);
        }
        public static void SaveHidden(string path, XmlDocument doc)
        {
            if (File.Exists(path)) File.SetAttributes(path, FileAttributes.Normal);
            doc.Save(path);
            if (File.Exists(path)) File.SetAttributes(path, FileAttributes.Hidden);
        }
        //Обновляет список выходных
        public static string[] hday_init()
        {
            string[] holidays = new string[7];

            if (!is_days) new Holidays().CreateFile();
            XDocument xDays = XDocument.Load(dPath);
            int iter = 0;
            foreach (XElement element in xDays.Root.Elements())
            {
                if (bool.Parse(element.Value))
                {
                    iter++;
                    holidays[iter] = element.Name.ToString();
                }
            }
            return holidays;
        }
        //Если day выходной, возвращает true
        public static bool is_holiday(DayOfWeek day)
        {
            foreach (string item in hday_init())
            {
                if (day.ToString() == item) return true;
            }
            return false;
        }
        //Возвращает день недели notnow текущего месяца
        public static DayOfWeek dayweek(int notnow)
        {
            DateTime now = DateTime.Now;
            DateTime date = new DateTime(now.Year, now.Month, notnow);
            return date.DayOfWeek;
        }
        //Генератор тонких клеточек
        public static ICellStyle StyleGenerator(IWorkbook book, short color, FillPattern pattern)
        {
            var style = book.CreateCellStyle();
            style.FillForegroundColor = color;
            style.FillPattern = pattern;

            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderTop = BorderStyle.Thin;
            return style;
        }
    }
}