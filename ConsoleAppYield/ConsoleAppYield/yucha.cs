using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield
{
    public class yucha
    {
        public static void Test()
        {
           

            List<string> list2 = new List<string>();
            //list2.Add("4");
            list2.Add("3");
            list2.Add("9");
            list2.Add("5");

            List<string> list5 = new List<string>();
            list5.Add("5");

            List<string> list3 = new List<string>();
            list3.Add("4");
            list3.Add("1");
            list3.Add("2");

            List<string> list4 = new List<string>();
            list4.Add("5");
            list4.Add("1");

            List<string> list1 = new List<string>();
            list1.Add("1");
            list1.Add("2");
            list1.Add("3");
            list1.Add("5");
            list1.Add("9");

            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            dic.Add("abc", list1); // 12359
            dic.Add("bcd", list2); //39
            dic.Add("efg", list3); //124
            dic.Add("hij", list4); //15
            dic.Add("klm", list5); //5

            Dictionary<string, string> groupKey = new Dictionary<string, string>();
            List<string> minusKeys = new List<string>();
            foreach (var item in dic)
            {
                if (minusKeys.Any(n => n == item.Key))
                    continue;
                foreach (var item2 in dic)
                {
                    if (item.Key == item2.Key)
                        continue;
                    if (minusKeys.Any(n => n == item.Key))
                        continue;
                    List<string> JiaoList = item.Value.Intersect(item2.Value).ToList();


                    if (item.Value.Except(JiaoList).ToList().Count == 0 || item2.Value.Except(JiaoList).ToList().Count == 0)
                    {
                        if (item.Value.Count >= item2.Value.Count)
                        {
                            minusKeys.Add(item2.Key);
                            string value = string.Empty;
                            if(groupKey.Any(n => n.Key == item2.Key))
                            {
                                value = groupKey[item2.Key];
                                groupKey.Remove(item2.Key);
                            }
                            if (groupKey.Any(n => n.Key == item.Key))
                            {
                                value = string.Empty;
                                value = groupKey[item.Key];
                                value += "," + item2.Key;
                                groupKey.Remove(item.Key);
                                groupKey.Add(item.Key, value);
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(value))
                                    value = item2.Key;
                                value = item.Key + "," + value;
                                groupKey.Add(item.Key, value);
                            }
                        }
                        else
                        {
                            minusKeys.Add(item.Key);
                            string value = string.Empty;
                            if(groupKey.Any(n=>n.Key==item.Key))
                            {
                                value = groupKey[item.Key];
                                groupKey.Remove(item.Key);
                            }
                            if(groupKey.Any(n=>n.Key==item2.Key))
                            {
                                value = string.Empty;
                                value = groupKey[item2.Key];
                                value += "," + item.Key;
                                groupKey.Remove(item2.Key);
                                groupKey.Add(item2.Key, value);
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(value))
                                    value = item.Key;
                                value = item2.Key + "," + value;
                                groupKey.Add(item2.Key, value);
                            }
                        } 
                    }
                    else
                        continue;
                }
            }
            foreach (var item in minusKeys)
            {

            }
        }
    }
}
