using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield
{
    public class DistinctTest
    {
        public static void Distinct()
        {
            List<User> list = new List<User>();   //添加一些测式数据
            list.Add(new User(1, "张三", Convert.ToDateTime("2017-09-15 14:17:54.307"),10));
            list.Add(new User(1, "李三", Convert.ToDateTime("2017-09-10 14:17:54.307"),11));
            list.Add(new User(1, "小伟", Convert.ToDateTime("2017-09-12 14:17:54.307"),9));
            list.Add(new User(1, "李三", Convert.ToDateTime("2017-09-12 14:17:54.307"),12));
            list.Add(new User(2, "李四", Convert.ToDateTime("2017-09-12 14:17:54.307"),13));
            list.Add(new User(2, "李武", Convert.ToDateTime("2017-09-12 14:17:54.307"),14));

            var query = list.Distinct(new UserComparer());   //去重复

            foreach (var item in query)
            {
                Console.WriteLine(item.Id + "," + item.Name + "," + item.Age);   //输出Distinct之后的结果
            }
        }
    }

    public class User
    {
        public User(int id, string name,DateTime bron,int age)
        {
            Id = id;
            Name = name;
            Bron = bron;
            Age = age;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Bron { get; set; }

        public int Age { get; set; }
    }

    public class UserComparer : IEqualityComparer<User>
    {
        #region IEqualityComparer<User> 成员
        public bool Equals(User x, User y)
        {
            if (x.Id == y.Id && x.Name == y.Name && x.Bron < y.Bron)       //分别对属性进行比较
                return true;
            else
                return false;
        }

        public int GetHashCode(User obj)
        {
            return 0;
        }
        #endregion
    }
}
