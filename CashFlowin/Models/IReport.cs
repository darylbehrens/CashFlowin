using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using CashFlowin.Models;
using OfficeOpenXml;

namespace CashFlowin.Web.Models
{
 

    public enum ReportType
    {
        All,
        Yearly,
        Monthly,
        Weekly
    }

    public static class ReportGenerator
    {
        public const int INITIALCOLUMNCOUNT = 2;
        public const int INITIALROWCOUNT = 3;
        public static Dictionary<string, int> IncomeLocations { get; set; } = new();
        public static Dictionary<string, int> ExpenseLocations { get; set; } = new();
        public static int columncount { get; set; }
        public static int rowcount { get; set; } = INITIALROWCOUNT;


        public static int TotalIncomeRow => INITIALROWCOUNT + IncomeLocations.Count;
        public static int TotalExpenseCount => INITIALROWCOUNT + IncomeLocations.Count + ExpenseLocations.Count + 2;


        public static void SaveReport(FileInfo file, ReportType type, Date startDate, List<DatedNamedDecimalItem> items, decimal startValue)
        {
            if (File.Exists(file.FullName))
            {
                file.Delete();
            }


            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage package = new(file);
            var weeklyWs = package.Workbook.Worksheets.Add("Weekly");
            var yearlyWorrksheet = package.Workbook.Worksheets.Add("Yearly");
            var monthlyWorksheet = package.Workbook.Worksheets.Add("Monthly");
            CreateHeaders(items, package);

            MonthlyReport(startDate, package, items, startValue);
            WeeklyReport(startDate, DayOfWeek.Friday, package, items, startValue);
            YearlyReport(startDate, package, items, startValue);

            package.Save();
        }

        private static void CreateHeaders(List<DatedNamedDecimalItem> items, ExcelPackage package)
        {
            IncomeLocations = new();
            ExpenseLocations = new();
            var income = items.Where(x => x.Item.Value > 0).Select(x => x.Item.Name).Distinct();
            var expense = items.Where(x => x.Item.Value <= 0).Select(x => x.Item.Name).Distinct();

            foreach (var ws in package.Workbook.Worksheets)
            {
                foreach (var incomeItem in income)
                {
                    ws.Cells[rowcount, 1].Value = incomeItem;
                    IncomeLocations.TryAdd(incomeItem, rowcount);
                    rowcount++;
                }

                rowcount+=2;


                foreach (var expenseItem in expense)
                {
                    ws.Cells[rowcount, 1].Value = expenseItem;
                    ExpenseLocations.TryAdd(expenseItem, rowcount);
                    rowcount++;
                }
                rowcount = INITIALROWCOUNT;
            }

            
        }

        private static void MonthlyReport(Date startDate, ExcelPackage package, List<DatedNamedDecimalItem> items, decimal startValue)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
           
            var ws = package.Workbook.Worksheets["Monthly"];
            columncount = INITIALCOLUMNCOUNT;

            foreach (var Dates in items.OrderBy(x => x.Date.Value).GroupBy(x => $"{x.Date.Value.Month}-{x.Date.Value.Year}"))
            {
                CreateItems(Dates, ws, startValue);
            }
        }

        private static void WeeklyReport(Date startDate, DayOfWeek weekstart,  ExcelPackage package, List<DatedNamedDecimalItem> items, decimal startValue)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var ws = package.Workbook.Worksheets["Weekly"];
            columncount = INITIALCOLUMNCOUNT;

            foreach (var Dates in items.OrderBy(x => x.Date.Value)
                .GroupBy(x => x.Date.StartOfWeek(DayOfWeek.Friday).Value))
            {
                CreateItems<DateTime>(Dates, ws, startValue);
            }

            ws.Row(1).Style.Numberformat.Format = "MM-dd-yyyy";
        }

        private static void YearlyReport(Date startDate, ExcelPackage package, List<DatedNamedDecimalItem> items, decimal startValue)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var ws = package.Workbook.Worksheets["Yearly"];
            columncount = INITIALCOLUMNCOUNT;

            foreach (var Dates in items.OrderBy(x => x.Date.Value)
                .GroupBy(x => x.Date.Value.Year))
            {
                CreateItems(Dates, ws, startValue);
            }
        }

        private static void CreateItems<T>(IGrouping<T,DatedNamedDecimalItem> Dates, ExcelWorksheet ws,decimal startValue)
        {
            var zip = new Dictionary<string, decimal>();
            decimal value = 0M;
            // Zip Em
            foreach (var i in Dates)
            {
                if (!zip.TryGetValue(i.Item.Name, out value))
                {
                    zip.Add(i.Item.Name, i.Item.Value);
                }
                else
                {
                    zip[i.Item.Name] = zip[i.Item.Name] + i.Item.Value;
                }
            }

            ws.Cells[1, columncount].Value = Dates.Key;
            ws.Cells[2, columncount].Formula = columncount == INITIALCOLUMNCOUNT ? startValue.ToString() : $"{ws.Cells[TotalExpenseCount + 2, columncount - 1]}";
            foreach (var i in zip)
            {
                int index = i.Value > 0 ? IncomeLocations[i.Key] : ExpenseLocations[i.Key];
                ws.Cells[index, columncount].Value = i.Value;
            }
            startValue = startValue + Dates.Sum(x => x.Item.Value);

            ws.Cells[TotalIncomeRow, columncount].Formula = $"SUM({ws.Cells[3, columncount].Address}:{ws.Cells[TotalIncomeRow - 1, columncount].Address})";
            ws.Cells[TotalExpenseCount, columncount].Formula = $"SUM({ws.Cells[TotalIncomeRow + 2, columncount].Address}:{ws.Cells[TotalExpenseCount - 1, columncount].Address})";
            ws.Cells[TotalExpenseCount+1, columncount].Formula = $"SUM({ws.Cells[TotalIncomeRow, columncount].Address},{ws.Cells[TotalExpenseCount, columncount].Address})";
            ws.Cells[TotalExpenseCount + 2, columncount].Formula = $"SUM({ws.Cells[2, columncount].Address},{ws.Cells[TotalExpenseCount+1, columncount].Address})";

            columncount++;
        }
    }
}
