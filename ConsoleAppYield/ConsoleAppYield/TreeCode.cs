using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield
{
    public class TreeCode
    {
        public  void   GetData()
        {
            List<Bill> list = new List<Bill>();   //添加一些测式数据
            list.Add(new Bill("a1","A","B", Convert.ToDateTime("2017-01-12 14:17:51.307"),"1"));
            list.Add(new Bill("cd1", "C", "D", Convert.ToDateTime("2017-01-12 14:18:51.307"), "1"));
            list.Add(new Bill("a2", "A", "C", Convert.ToDateTime("2017-02-12 15:17:52.307"), "2"));
            list.Add(new Bill("a3", "A", "D", Convert.ToDateTime("2017-03-12 16:17:53.307"), "3"));
            list.Add(new Bill("a4", "B", "E", Convert.ToDateTime("2017-04-13 14:17:54.307"), "1"));
            list.Add(new Bill("a5", "B", "F", Convert.ToDateTime("2017-05-13 15:17:55.307"), "1"));
            list.Add(new Bill("a6", "C", "M", Convert.ToDateTime("2017-06-15 14:17:56.307"), "2"));
            list.Add(new Bill("a7", "D", "N", Convert.ToDateTime("2017-07-15 14:17:57.307"), "3"));
            list.Add(new Bill("a8", "E", "Q", Convert.ToDateTime("2017-08-14 14:17:58.307"), "1"));
            list.Add(new Bill("a8", "F", "Q", Convert.ToDateTime("2017-09-15 14:17:59.307"), "1"));
            list.Add(new Bill("a9", "Q", "A", Convert.ToDateTime("2017-10-16 15:17:50.307"), "1"));
            list.Add(new Bill("a10", "A", "B", Convert.ToDateTime("2017-11-17 14:17:44.307"), "1"));

            List<BillDto> billRe = new List<BillDto>();
            Bill model = list.First(); 
            //model.isUsed = true;
            SetDtoByBill(model, true, billRe);

            for (int i = 1; i <= 1; i++)
            {
                List<Bill> groupBillList = list.Where(n => n.Group == i.ToString() && n.isUsed == false).ToList();
                ForeachBill(groupBillList, model.FormCode, billRe);
                while (groupBillList.Any(n => n.isUsed == false))
                {
                    List<Bill> groupBillList2 = groupBillList.Where(n => n.Group == i.ToString() && n.isUsed == false).ToList();
                    SetDtoByBill(groupBillList2[0], true, billRe);
                    ForeachBill(groupBillList2, groupBillList2[0].FormCode, billRe);
                }

            }

           


            foreach (var item in billRe)
            {
                Console.WriteLine(item.Code);
            }
        }

        public void ForeachBill(List<Bill> distinctBillList, string fromCode, List<BillDto> billRe)
        {
            //Bill model = distinctBillList.First();
            if (distinctBillList.Any(n => n.isUsed == false && n.FormCode == fromCode)) 
            {
               

                List<Bill> toCodeBill = distinctBillList.Where(n => n.isUsed==false && n.FormCode == fromCode).ToList();


                toCodeBill.ForEach(delegate (Bill b)
                {
                    if(b.ToCode=="F")
                    {

                    }
                    if (!b.isUsed)
                    {
                        b.isUsed = true;
                        //distinctBillList.Where(n => b.InvNo == n.InvNo).FirstOrDefault().isUsed = true;
                        SetDtoByBill(b, false, billRe);

                        ForeachBill(distinctBillList, b.ToCode, billRe);
                    }
                   
                  
                });

            }
            else
            {
                return;
            }
        }

        public void SetDtoByBill(Bill model, bool isRoot, List<BillDto> billRe)
        {
            BillDto billDto = new BillDto();
            if (isRoot)
            {
                billDto.Code = model.FormCode;
                billDto.NodeId = Guid.NewGuid().ToString();
                billDto.NodeParentId = "0";
                billDto.Level = 1;
                billDto.date = model.Date;
                billDto.Symbol = model.Group;

            }
            else
            {
                BillDto tempBill = null;

                //判断是否存在同一组，时间的先后顺序，找父节点
                if (billRe.Any(n => n.Symbol == model.Group))
                {
                    tempBill = billRe.Where(n => n.Code == model.FormCode && n.date <= model.Date).OrderByDescending(n => n.date).FirstOrDefault();
                }
                else
                {
                    tempBill = billRe.Where(n => n.Code == model.FormCode && n.date <= model.Date).OrderBy(n => n.date).FirstOrDefault();
                }

                //判断是否存在同一组，且是同一节点的值；

               

                billDto.Code = model.ToCode;
                billDto.NodeId = Guid.NewGuid().ToString();
                billDto.date = model.Date;
                billDto.NodeParentId = tempBill.NodeId;
                billDto.Level = tempBill.Level + 1;
                billDto.Symbol = model.Group;
            }

            billRe.Add(billDto);
        }
    }


    public class Bill
    {
        public Bill(string no, string from,string to,DateTime dt,string group)
        {
            this.InvNo = no;
            this.FormCode = from;
            this.ToCode = to;
            this.Date = dt;
            this.Group = group;
        }

        public string InvNo { get; set; }

        public string FormCode { get; set; }

        public string ToCode { get; set; }

        public DateTime Date { get; set; }

        public string Group { get; set; }

        public bool isUsed { get; set; }
    }

    public class BillDto
    {
        public string Code { get; set; }

        public DateTime date { get; set; }

        public int Level { get; set; }

        public string NodeId { get; set; }

        public string NodeParentId { get; set; }

        public string Symbol { get; set; }
    }
}
