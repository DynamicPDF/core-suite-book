using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;
using System;
using System.Data.SqlClient;
using System.IO;

namespace ChapterExamples.Chapters.ChapterTwentyEight
{
    public class PlaceHolderExample
    {
        public static string CONNECTION = "Data Source=JAMESWINDOWSPC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void CreateReport(string resourcePath, string outputPath)
        {            
            DocumentLayout docLayout = new DocumentLayout(resourcePath + "employee-image-example.dlex");
            PlaceHolder placeHolder = (PlaceHolder)docLayout.GetLayoutElementById("Placeholder1");
            placeHolder.LaidOut += PlaceHolder1_LaidOut;
            string sql = "SELECT FirstName, LastName, EmployeeID FROM Employees";
            SqlConnection connection = new SqlConnection(CONNECTION);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("Employees", new DataReaderReportData(connection, reader));
            
            Document doc = docLayout.Layout(layoutData);
            doc.Draw(outputPath + "employee-image-example-output.pdf");
        }

         private static void PlaceHolder1_LaidOut(object sender, PlaceHolderLaidOutEventArgs e)
        {
            string empID = e.LayoutWriter.Data["EmployeeID"].ToString();
            
            string query = "SELECT Photo FROM Employees where EmployeeID=" + empID;

            using (SqlConnection connection = new SqlConnection(CONNECTION))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    byte[] photoData = (byte[])reader["Photo"];
                    byte[] imageData = new byte[photoData.Length - 78];
                    Array.Copy(photoData, 78, imageData, 0, imageData.Length);

                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        float x = e.ContentArea.X;
                        float y = e.ContentArea.Y;
                        ceTe.DynamicPDF.PageElements.Image image = new ceTe.DynamicPDF.PageElements.Image((Stream)ms, x, y, 1);
                        image.SetBounds(e.ContentArea.Height, e.ContentArea.Width);
                        e.ContentArea.Add(image);

                    }
                }
            }
        }
    }
}
