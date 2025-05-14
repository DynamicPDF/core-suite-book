using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;
using System.Data.SqlClient;

namespace ChapterExamples.Chapters.ChapterTwentyEight
{
    public class SubreportEventExample
    {
        public static void CreateReport(string resourcePath, string outputPath)
        {
            DocumentLayout docLayout = new DocumentLayout(resourcePath + "employees-by-id.dlex");
            docLayout.ReportDataRequired += ReportDataRequired;
            LayoutData layoutData = new();
            Document doc = docLayout.Layout(layoutData);
            doc.Draw(outputPath + "subreportexample-output.pdf");
        }

        private static string CONNECTION = "Data Source=JAMESWINDOWSPC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static string SQL1 = "Select Employees.EmployeeID, LastName, FirstName , Territories.TerritoryID from Employees, Territories, EmployeeTerritories where Employees.EmployeeID = EmployeeTerritories.EmployeeID and EmployeeTerritories.TerritoryID = Territories.TerritoryID";

        private static string SQL2 = "Select EmployeeID, Territories.TerritoryID, TerritoryDescription from Territories, EmployeeTerritories where EmployeeTerritories.TerritoryID = Territories.TerritoryID and EmployeeTerritories.EmployeeID = ";

        private static void ReportDataRequired(object sender, ReportDataRequiredEventArgs args)
        {
            if (args.ElementId == "Report1")
            {

                SqlConnection connection = new SqlConnection(CONNECTION);
                SqlCommand command = new SqlCommand(SQL1, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                args.ReportData = new DataReaderReportData(connection, reader);
            }
            else if (args.ElementId == "Subreport1")
            {
                string sqlString = SQL2 + args.Data["EmployeeID"];

                SqlConnection connection = new SqlConnection(CONNECTION);
                SqlCommand command = new SqlCommand(sqlString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                args.ReportData = new DataReaderReportData(connection, reader);
            }
        }
    }
}
