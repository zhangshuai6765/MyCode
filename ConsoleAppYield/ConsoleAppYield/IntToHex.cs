using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleAppYield
{
    public class IntToHex
    {
        private static readonly ThreadLocal<Random> appRandom = new ThreadLocal<Random>(() => new Random());

        public static int GetRandomNumber()
        {
            return appRandom.Value.Next();
        }


        public string IntToHex2(int SerialNum, string hex)
        {
            int hexLen = hex.Length;

            string result = hex.Substring((SerialNum % hexLen), 1);

            while (SerialNum != 0)
            {
                string val1 = hex.Substring(((SerialNum / hexLen) % hexLen), 1);

                SerialNum = SerialNum / hexLen;
                if (SerialNum != 0)
                {
                    result = val1 + result;
                }
            }

            return result.ToString();
        }

        public string SetEncryption(int length,string token)
        {
            Random rd = new Random();
            char[] constant = token.ToCharArray();
            int tokenLen = constant.Length;
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(tokenLen);
            for (int i = 0; i < length; i++)
            {
                //newRandom.Append(constant[rd.Next(tokenLen)]);
                newRandom.Append(constant[appRandom.Value.Next(tokenLen)]);
            }
            return newRandom.ToString();
        }
    }
}
