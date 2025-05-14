using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;
using System.Data;
using System.Data.SqlClient;

namespace ChapterExamples.Chapters.ChapterTwentySeven
{
    public class DataTableReportDataExample
    {
        public static void CreateReport(string resourcePath, string outputPath)
        {
            string connectionString = "Data Source=JAMESWINDOWSPC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string query = "SELECT * FROM Customers";

            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            DocumentLayout docLayout = new(resourcePath + "table-data-example.dlex");
            LayoutData layoutData = new LayoutData();
            DataTableReportData data = new DataTableReportData(dataTable);
            layoutData.Add("Customers", data);
            Document doc = docLayout.Layout(layoutData);

            doc.Draw(outputPath + "datatablereportexample-output.pdf");
        }
    }
}
