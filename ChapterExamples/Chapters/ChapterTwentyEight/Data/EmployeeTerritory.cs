using ChapterExamples.Utility;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ChapterExamples.Chapters.ChapterTwentyEight.Data
{
    public class EmployeeTerritory
    {

        public class Employee
        {
            public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<Territory> Territories { get; set; }
        }

        public class Territory
        {

            public int TerritoryID { get; set; }
            public string TerritoryDescription { get; set; }       
        }

        public class Root
        {
            public List<Employee> Employees { get; set; }
        }

        public static List<Employee> GetEmployeesTerritory()
        {
            string jsonFilePath = FileUtility.GetPath("../ChapterExamples/resources/ch28/employees-by-id.json");
            string jsonData = File.ReadAllText(jsonFilePath);
            var employeeData = JsonConvert.DeserializeObject<EmployeeTerritory.Root>(jsonData);
            return employeeData.Employees;
        }

    }
}
