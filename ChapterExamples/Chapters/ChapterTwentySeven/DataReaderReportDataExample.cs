using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;
using System.Data.SqlClient;

namespace ChapterExamples.Chapters.ChapterTwentySeven
{
    public class DataReaderReportDataExample
    {
        public static void CreateReport(string resourcePath, string outputPath)
        {
            string connectionString = "Data Source=JAMESWINDOWSPC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);

            Document doc = null;

            using (connection)
            {

                DocumentLayout layoutReport = new DocumentLayout(resourcePath + "report-data-example.dlex");
                SqlCommand command = new SqlCommand(SQL, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                LayoutData layoutData = new LayoutData();
                layoutData.Add("Orders", new DataReaderReportData(connection, reader));
                doc = layoutReport.Layout(layoutData);
            }

            doc.Draw(outputPath + "datareaderreportexample-output.pdf");
        }

        private static string SQL = "SELECT Orders.OrderID as OrderID, CONVERT(VARCHAR, OrderDate, 107) as OrderDate, CONVERT(DECIMAL(10,2), Details.UnitPrice) As UnitPrice, Details.Quantity, CONVERT(DECIMAL(10,2), Details.Discount) As Discount, Details.ProductID, Products.ProductName FROM Orders, [Order Details] as Details, Products WHERE Orders.OrderID = Details.OrderID AND Details.ProductID = Products.ProductID";
    }
}
