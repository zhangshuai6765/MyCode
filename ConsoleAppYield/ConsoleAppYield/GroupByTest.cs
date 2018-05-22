using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield
{
    public class GroupByTest
    {
        public static void GroupBy()
        {
            var empList = new List<Employee>
            {
        new Employee {ID = 1, FName = "John", Age = 23, Sex = 'M'},
        new Employee {ID = 2, FName = "Mary", Age = 25, Sex = 'F'},
        new Employee {ID = 3, FName = "Amber", Age = 23, Sex = 'M'},
        new Employee {ID = 4, FName = "Kathy", Age = 25, Sex = 'F'},
        new Employee {ID = 5, FName = "Lena", Age = 27, Sex = 'F'},
        new Employee {ID = 6, FName = "Bill", Age = 28, Sex = 'M'},
        new Employee {ID = 7, FName = "Celina", Age = 27, Sex = 'F'},
        new Employee {ID = 8, FName = "John", Age = 28, Sex = 'M'}
            };

            var QueryWithLamda = empList.GroupBy(x => new { x.Age, x.Sex })
            .Select(g => new { g.Key, Count = g.Count() });
        }
    }
    public class Employee
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }
    }
}
