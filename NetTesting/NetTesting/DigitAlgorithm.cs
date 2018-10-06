using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTesting
{
    public class DigitAlgorithm
    {
        private string strValue;
        private List<string> lvalue;
        private int intChunkSize = 3;
        private int intCheckDigit = 0;
        private string strReferenceNumber = "";
        public DigitAlgorithm(long lValue)
        {
            if (lValue >= 0)
            {
                this.strValue = lValue.ToString();
                this.intCheckDigit = CaculaterCheckDigit(strValue);
                strReferenceNumber = this.strValue + this.intCheckDigit.ToString();
            }
            else
            {
                throw new ArgumentException("Number is not negative");
            }

        }

        public string GetReferenceNumber()
        {
            return strReferenceNumber;
        }
        public int GetCheckDigit()
        {
            return intCheckDigit;
        }
        public string GetValue()
        {
            return strValue;
        }

        private int CaculaterCheckDigit(string strValue)
        {
            lvalue = new List<string>();
            for (int i = 0; i < strValue.Length; i += intChunkSize)
            {
                if (i + intChunkSize > strValue.Length)
                {
                    lvalue.Add(strValue.Substring(i));
                }
                else
                    lvalue.Add(strValue.Substring(i, intChunkSize));
            }

            int SumA = 0;
            int SumB = 0;
            int SumC = 0;

            Multiply(ref SumA, ref SumB, ref SumC);

            int S = SumA + SumB + SumC;
            return SumOfStringNumber(S.ToString());
        }

        private void Multiply(ref int SumA, ref int SumB, ref int SumC)
        {
            foreach (string item in lvalue)
            {
                int itemA = 0;
                try
                {
                    itemA = (Convert.ToInt16(item[0].ToString()) * 3);
                }
                catch (Exception) { }


                int itemB = 0;
                try
                {
                    itemB = (Convert.ToInt16(item[1].ToString()) * 5);
                }
                catch (Exception) { }

                int itemC = 0;

                try
                {
                    itemC = (Convert.ToInt16(item[2].ToString()) * 7);
                }
                catch (Exception) { }

                SumA += itemA;
                SumB += itemB;
                SumC += itemC;
            }
        }

        public int SumOfStringNumber(string strNumber)
        {
            if (IsCheckNumber(strNumber))
            {
                int intSum = 0;
                foreach (char citem in strNumber)
                {
                    intSum += Convert.ToInt32(citem.ToString());
                }

                if (intSum.ToString().Length == 1)
                {
                    return intSum;
                }
                else
                {
                    return SumOfStringNumber(intSum.ToString());
                }
            }
            else
            {
                throw new ArgumentException("string is not number");
            }

        }
        public bool IsCheckNumber(string strNumber)
        {
            if (strNumber.All(char.IsDigit))
            {

                return true;
            }
            else
            {
                return false;
            }
        }


        public List<DigitList> CheckDigitBetween101To999()
        {
            List<int> lCheckDigit = new List<int>();
            for (int i = 101; i <= 999; i++)
            {
                string strValue = i.ToString();
                int intCheckDigit = CaculaterCheckDigit(strValue);
                lCheckDigit.Add(intCheckDigit);
            }

            List<DigitList> dl = new List<DigitList>();

            for (int i = 0; i < 10; i++)
            {
                dl.Add(new DigitList(i, lCheckDigit.Count(x => x == i)));
            }
            dl.OrderBy(x => x.index);
            return dl;
        }
    }

    public class DigitList
    {
        public int index { get; set; }
        public int value { get; set; }

        public DigitList(int index, int value)
        {
            this.index = index;
            this.value = value;
        }
    }

}
