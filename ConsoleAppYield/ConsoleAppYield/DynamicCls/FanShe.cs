using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleAppYield.DynamicCls
{
    public class FanShe
    {
        public void DataTableToT()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Num", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Phone", Type.GetType("System.String")));

            DataRow dr = dt.NewRow();
            dr["Name"] = "zhangshuai";
            dr["Num"] = "18";
            dr["Phone"] = "112233";
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1["Name"] = "zhangshuai";
            dr1["Num"] = "19";
            dr1["Phone"] = "112233";
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["Name"] = "zhangshuai";
            dr2["Num"] = "20";
            dr2["Phone"] = "112233";
            dt.Rows.Add(dr2);

            List<StudentModel> stuList = TableToList2<StudentModel>(dt).ToList();
        }

        private IList<T> TableToList<T>(DataTable dt) where T:new()
        {
            // 定义集合    
            IList<T> ts = new List<T>();

            // 获得此模型的类型   
            //Type type = typeof(T);
            string tempName = "";

            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性      
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;  // 检查DataTable是否包含此列    

                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter      
                        if (!pi.CanWrite) continue;

                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                ts.Add(t);
            }
            return ts;     
        }
        private IList<T> TableToList2<T>(DataTable dt) where T : new()
        {
            IList<T> ts = new List<T>();

            //Type tt = typeof(T);

            foreach (DataRow row in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] infos = t.GetType().GetProperties();
                foreach (var property in infos)
                {
                    string propertyname = property.Name;
                    if (dt.Columns.Contains(propertyname))
                    {
                        if (!property.CanWrite)
                        {
                            continue;
                        }
                        object value = row[propertyname];
                        if (value != DBNull.Value)
                            property.SetValue(t, value, null);
                    }
                   
                }
                ts.Add(t);
            }
            return ts; 
        }
    }

    public class StudentModel
    {
        public string Name { get; set; }
        public string Num { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }

        public List<string> details { get; set; }
    }

    public class StudentModelItem
    {
        public List<StudentModel> data { get; set; }
    }
}
