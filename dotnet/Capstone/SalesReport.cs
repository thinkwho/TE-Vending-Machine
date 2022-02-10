using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class SalesReport
    {

        private const string PreviousReport = @"..\..\..\SalesReports\PreviousReportPath.txt";
        private string SalesReportFile = Path.Combine(@"..\..\..\SalesReports\", $"SalesReport{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.txt");

        public string ReferenceFilePath { get; private set; }
        public decimal SalesTotal { get; private set; }

        public void CreateSalesReport(List<VendingMachineItem> vendings)
        {

            try
            {
                if (!File.Exists(PreviousReport))
                {
                    using (StreamReader streamReader = new StreamReader(@"C:\Users\Student\workspace\orange-mod1-capstone-team1\dotnet\Capstone\SalesReports\SalesReportReference.txt"))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(SalesReportFile))
                        {
                            using (StreamWriter sw = new StreamWriter(@"..\..\..\SalesReports\PreviousReportPath.txt"))
                            {
                                sw.WriteLine(SalesReportFile);

                                decimal totalSalesForSalesReport = 0;
                                int oldQuantity = 0;
                                string[] nameQuantity = null;
                                int totalQuantityForSalesReport = 0;
                                foreach (VendingMachineItem item in vendings)
                                {
                                    string line = streamReader.ReadLine();
                                    if (line.Contains("|"))
                                    {
                                        nameQuantity = line.Split("|");
                                        oldQuantity = int.Parse(nameQuantity[1]);
                                        totalQuantityForSalesReport = oldQuantity + item.TotalSoldPerStock;
                                        streamWriter.WriteLine($"{nameQuantity[0]}|{totalQuantityForSalesReport}");
                                        totalSalesForSalesReport += item.TotalSalesPerStock;
                                    }
                                }
                                streamWriter.WriteLine();
                                streamWriter.WriteLine($"{totalSalesForSalesReport:C2}");
                                sw.WriteLine(totalSalesForSalesReport);
                            }
                        }
                    }

                }
                else
                {
                    using (StreamReader streamReader = new StreamReader(PreviousReport))
                    {
                        ReferenceFilePath = streamReader.ReadLine();
                        SalesTotal = decimal.Parse(streamReader.ReadLine());
                    }

                    using (StreamReader sr = new StreamReader(ReferenceFilePath))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(SalesReportFile))
                        {
                            using (StreamWriter sw = new StreamWriter(PreviousReport))
                            {
                                sw.WriteLine(SalesReportFile);

                                decimal totalSalesForSalesReport = 0;
                                int oldQuantity = 0;
                                string[] nameQuantity = null;
                                int totalQuantityForSalesReport = 0;
                                foreach (VendingMachineItem item in vendings)
                                {
                                    string line = sr.ReadLine();
                                    if (line.Contains("|"))
                                    {
                                        nameQuantity = line.Split("|");
                                        oldQuantity = int.Parse(nameQuantity[1]);
                                        totalQuantityForSalesReport = oldQuantity + item.TotalSoldPerStock;
                                        streamWriter.WriteLine($"{nameQuantity[0]}|{totalQuantityForSalesReport}");
                                        totalSalesForSalesReport += item.TotalSalesPerStock;
                                    }
                                }
                                SalesTotal += totalSalesForSalesReport;
                                streamWriter.WriteLine();
                                streamWriter.WriteLine($"{SalesTotal:C2}");
                                sw.WriteLine(SalesTotal);
                            }
                        }
                    }

                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public static void ExportSalesReportCreate()
        {
            SalesReport salesReport = new SalesReport();
            salesReport.CreateSalesReport(VendingMachineItem.vendingMachineItemsProprerties);
        }
    }
}
