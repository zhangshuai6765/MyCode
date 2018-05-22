using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield
{
    public class Sender
    {
        private string IntToHex(int SerialNum, string hex)
        {
            int hexLen = hex.Length;

            string result = hex.Substring((SerialNum % hexLen), 1);

            while (SerialNum != 0)
            {
                string val = hex.Substring(((SerialNum / hexLen) % hexLen), 1);

                SerialNum = SerialNum / hexLen;
                if (SerialNum != 0)
                {
                    result = val + result;
                }
            }

            return result;
        }
    }
}
