using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleAppYield.Testc
{
   public class WhereTest<U, T>
        where T : new()
        where U : new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
       public static T AConvertToB(U u)
       //where T : new()
       //where U : new()
       {
           T t = new T();
           //U u = new U();
           PropertyInfo[] infoT = t.GetType().GetProperties();
           List<PropertyInfo> TList = infoT.ToList();
           PropertyInfo[] infoU = u.GetType().GetProperties();

           //Type type = u.GetType(); 
           //object obj = Activator.CreateInstance(type);

           foreach (var property in infoU)
           {
               string propertyname = property.Name;

               if (TList.Exists(p => p.Name == propertyname))
               {
                   object propertyValue=property.GetValue(u, null);
                   PropertyInfo pi = TList.Find(p => p.Name == propertyname);
                   pi.SetValue(t, propertyValue, null);
               }
           }

           return t;
       }
    }
}
