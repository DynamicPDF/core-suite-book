using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;
using ChapterExamples.Chapters.ChapterTwentyEight.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using static ChapterExamples.Chapters.ChapterTwentyEight.Data.EmployeeTerritory;

namespace ChapterExamples.Chapters.ChapterTwentyEight
{
    public class SubreportExample
    {
        public static void CreateReport(string resourcePath, string outputPath)
        {
            UsingSql(resourcePath, outputPath);
            UsingJson(resourcePath, outputPath);
            UsingBusinessObjects(resourcePath, outputPath);
            UsingJsonDb(resourcePath, outputPath);
        }

        public static void UsingJson(string resourcePath, string outputPath)
        {
            string data = File.ReadAllText(resourcePath + "employees-by-id.json");
            var jsonData = JsonConvert.DeserializeObject(data);
            DocumentLayout layoutReport = new DocumentLayout(resourcePath + "employees-by-id.dlex");
            LayoutData layoutData = new LayoutData(jsonData);
            Document document = layoutReport.Layout(layoutData);
            document.Draw(outputPath + "subreport-json-output.pdf");
        }

        public static void UsingBusinessObjects(string resourcePath, string outputPath)
        {
            DocumentLayout layoutReport = new DocumentLayout(resourcePath + "employees-by-id.dlex");
            LayoutData layoutData = new LayoutData();
            List<Employee> employeesData = EmployeeTerritory.GetEmployeesTerritory();
            layoutData.Add("Employees", employeesData);
            Document document = layoutReport.Layout(layoutData);
            document.Draw(resourcePath + "subreport-dataobject-output.pdf");
        }

        public static void UsingSql(string resourcePath, string outputPath)
        {
            string connectionString = "Data Source=JAMESWINDOWSPC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "Select Employees.EmployeeID, LastName, FirstName , " +
                "Territories.TerritoryID, Territories.TerritoryDescription " +
                "from Employees, Territories, EmployeeTerritories " +
                "where Employees.EmployeeID = EmployeeTerritories.EmployeeID " +
                "and EmployeeTerritories.TerritoryID = Territories.TerritoryID";

            Document doc = null;

            using (connection)
            {

                DocumentLayout layoutReport = new DocumentLayout(resourcePath + "employees-by-id.dlex");
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                LayoutData layoutData = new LayoutData();
                layoutData.Add("Employees", new DataReaderReportData(connection, reader));
                doc = layoutReport.Layout(layoutData);
            }

            doc.Draw(outputPath + "subreport-sql-output.pdf");
        }


    public static void UsingJsonDb(string resourcePath, string outputPath)
        {
            string connection = "Data Source=JAMESWINDOWSPC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string sql = "Select Employees.EmployeeID, LastName, FirstName , Territories.TerritoryID," + 
                "Territories.TerritoryDescription from Employees, Territories, EmployeeTerritories " +
                "where Employees.EmployeeID = EmployeeTerritories.EmployeeID " +
                "and EmployeeTerritories.TerritoryID = Territories.TerritoryID " +
                "for JSON auto, root('Employees')";
            using (var conn = new SqlConnection(connection))
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var jsonResult = new StringBuilder();
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        jsonResult.Append("[]");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            jsonResult.Append(reader.GetValue(0).ToString());
                        }
                    }

                    var jsonData = JsonConvert.DeserializeObject(jsonResult.ToString());
                    DocumentLayout layoutReport = new DocumentLayout(resourcePath + "employees-by-id.dlex");
                    LayoutData layoutData = new LayoutData(jsonData);
                    Document document = layoutReport.Layout(layoutData);
                    document.Draw(resourcePath + "subreport-sql-output.pdf");
                }
            }
        }

    }
}
