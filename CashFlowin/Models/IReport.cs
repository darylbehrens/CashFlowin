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
        public static void SaveReport(FileInfo file, ReportType type, Date startDate, List<DatedNamedDecimalItem> items, decimal startValue)
        {
            if (File.Exists(file.FullName))
            {
                file.Delete();
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage package = new(file);
            MonthlyReport(startDate, package, items,startValue);
            //var ws = package.Workbook.Worksheets.Add("TEST");
            //var rowcount = 2;


            //// Create List Of Expenses
            //var income = items.Where(x => x.Item.Value > 0).Select(x => x.Item.Name).Distinct();
            //var expense = items.Where(x => x.Item.Value <= 0).Select(x => x.Item.Name).Distinct();
            //Dictionary<string, int> ExpenseLocation = new();
            //Dictionary<string, int> IncomeLocation = new();

            //foreach (var incomeItem in income)
            //{
            //    ws.Cells[rowcount, 1].Value = incomeItem;
            //    IncomeLocation.Add(incomeItem, rowcount);
            //    rowcount++;

            //}

            //rowcount++;

            //foreach (var expenseItem in expense)
            //{
            //    ws.Cells[rowcount, 1].Value = expenseItem; 
            //    ExpenseLocation.Add(expenseItem, rowcount);
            //    rowcount++;
            //}

            //var columncount = 2;

            //foreach (var item in items.OrderBy(x => x.Date.Value).GroupBy(x => x.Date.Value))
            //{
            //    ws.Cells[1, columncount].Value = item.Key;
            //    foreach (var i in item.Select(x => x.Item))
            //    {
            //        int index = i.Value > 0 ? IncomeLocation[i.Name] : ExpenseLocation[i.Name];
            //        ws.Cells[index, columncount].Value = i.Value;
            //    }
            //    columncount++;
            //}
            package.Save();
        }

        private static void MonthlyReport(Date startDate, ExcelPackage package, List<DatedNamedDecimalItem> items, decimal startValue)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
           
            var ws = package.Workbook.Worksheets.Add("TEST");
            var rowcount = 3;


            // Create List Of Expenses
            var income = items.Where(x => x.Item.Value > 0).Select(x => x.Item.Name).Distinct();
            var expense = items.Where(x => x.Item.Value <= 0).Select(x => x.Item.Name).Distinct();
            Dictionary<string, int> ExpenseLocation = new();
            Dictionary<string, int> IncomeLocation = new();

            foreach (var incomeItem in income)
            {
                ws.Cells[rowcount, 1].Value = incomeItem;
                IncomeLocation.Add(incomeItem, rowcount);
                rowcount++;

            }

            rowcount++;

            foreach (var expenseItem in expense)
            {
                ws.Cells[rowcount, 1].Value = expenseItem;
                ExpenseLocation.Add(expenseItem, rowcount);
                rowcount++;
            }

            var columncount = 2;

            foreach (var Dates in items.OrderBy(x => x.Date.Value).GroupBy(x => $"{x.Date.Value.Month}-{x.Date.Value.Year}"))
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
                ws.Cells[2, columncount].Value = startValue;
                foreach (var i in zip)
                {
                    int index = i.Value > 0 ? IncomeLocation[i.Key] : ExpenseLocation[i.Key];
                    ws.Cells[index, columncount].Value = i.Value;
                }
                startValue = startValue + Dates.Sum(x => x.Item.Value);
                columncount++;
            }
        }

        private static void WeeklyReport(Date startDate, DayOfWeek weekstart, ExcelPackage package, List<DatedNamedDecimalItem> items, decimal startValue)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var ws = package.Workbook.Worksheets.Add("TEST");
            var rowcount = 3;


            // Create List Of Expenses
            var income = items.Where(x => x.Item.Value > 0).Select(x => x.Item.Name).Distinct();
            var expense = items.Where(x => x.Item.Value <= 0).Select(x => x.Item.Name).Distinct();
            Dictionary<string, int> ExpenseLocation = new();
            Dictionary<string, int> IncomeLocation = new();

            foreach (var incomeItem in income)
            {
                ws.Cells[rowcount, 1].Value = incomeItem;
                IncomeLocation.Add(incomeItem, rowcount);
                rowcount++;

            }

            rowcount++;

            foreach (var expenseItem in expense)
            {
                ws.Cells[rowcount, 1].Value = expenseItem;
                ExpenseLocation.Add(expenseItem, rowcount);
                rowcount++;
            }

            var columncount = 2;

            foreach (var Dates in items.OrderBy(x => x.Date.Value).GroupBy(x => $"{x.Date.Value.Month}-{x.Date.Value.Year}"))
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
                ws.Cells[2, columncount].Value = startValue;
                foreach (var i in zip)
                {
                    int index = i.Value > 0 ? IncomeLocation[i.Key] : ExpenseLocation[i.Key];
                    ws.Cells[index, columncount].Value = i.Value;
                }
                startValue = startValue + Dates.Sum(x => x.Item.Value);
                columncount++;
            }
        }
    }


}
