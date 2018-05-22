using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleAppYield.DynamicCls
{
    //(1)索引器的索引值(Index)类型不受限制

    //(2)索引器允许重载

    //(3)索引器不是一个变量

    //索引器和属性的不同点

    //(1)属性以名称来标识，索引器以函数形式标识

    //(2)索引器可以被重载，属性不可以

    //(3)索引器不能声明为static，属性可以
    public class Suoyinqi
    {
        public void Test()
        {
            Indexer1 index1 = new Indexer1();
            index1[0] = "aaa";

            Indexer2 index2 = new Indexer2();
            index2["aaa"] = "aaa";

            Indexer3 index3 = new Indexer3();
            index3["aaa"] = 1;
            string value= index3[1];

            Indexer4 index4 = new Indexer4();
            index4["zhangshuai", "001"] = "22";
            string age = index4["zhangshuai", "001"];
        }
    }

    public class Indexer1
    {
        private string[] name = new string[2];
        public string this[int index]
        {
            get
            {
                if (index < 2)
                {
                    return name[index];
                }
                return null;
            }
            set
            {
                if (index < 2)
                {
                    name[index] = value;
                }
            }
        }
    }

    public class Indexer2
    {
        private Hashtable name = new Hashtable();

        [IndexerNameAttribute("RenameIndex")]
        public string this[string index]
        {
            get
            {
                return name[index].ToString();
            }
            set
            {
                name.Add(index, value);
            }
        }
    }

    public class Indexer5
    {
        private Hashtable name = new Hashtable();

        [IndexerName("RenameIndex")]
        public object this[string index]
        {
            get
            {
                return name[index];
            }
            set
            {
                name.Add(index, value);
            }
        }
    }

    /// <summary>
    /// 重载索引器
    /// </summary>
    public class Indexer3
    {
        private Hashtable name = new Hashtable();

        //通过Key得到value;
        public string this[int index]
        {
            get
            {
                return name[index].ToString();
            }
            set
            {
                name.Add(index, value);
            }
        }

        //通过Value得到Key
        public int this[string index]
        {
            get
            {
                foreach (DictionaryEntry item in name)
                {
                    if(item.Value.ToString()==index)
                    {
                        return Convert.ToInt32(item.Key);
                    }
                }
                return -1;
            }
            set
            {
                name.Add(value, index);
            }
        }
    }

    /// <summary>
    /// 多参索引器
    /// </summary>
    public class Indexer4
    {
        private ArrayList aList = new ArrayList();

        public string this[string name, string num]
        {
            get
            {
                foreach (EnterpriseInfo item in aList)
                {
                    if (item.Name==name && item.Num==num)
                    {
                        return item.Age;
                    }
                }
                return null;
            }
            set
            {
                aList.Add(new EnterpriseInfo(name, num, value));
            }
        }

        /// <summary>
        /// 获取名称相同的记录
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ArrayList this[string name]
        {
            get
            {
                ArrayList aaList = new ArrayList();
                foreach (EnterpriseInfo item in aList)
                {
                    if (item.Name == name)
                    {
                        aaList.Add(item);
                    }
                }
                return aaList;
            }
        }
    }

    public class EnterpriseInfo
    {
        public string Name { get; set; }
        public string Num { get; set; }
        public string Age { get; set; }

        public  EnterpriseInfo()
        {

        }

        public EnterpriseInfo(string name,string num,string age)
        {
            this.Name = name;
            this.Num = num;
            this.Age = age;
        }
    }

}
