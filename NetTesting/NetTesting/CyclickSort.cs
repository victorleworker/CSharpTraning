using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTesting
{
    public class MyReverseChar
    {
        public int index { get; set; }
        public char c { get; set; }
        public MyReverseChar(int index, char c)
        {
            this.index = index;
            this.c = c;
        }
    }


    class CyclickSort
    {
        public string inputValue { get; set; }
        public int intOrder { get; set; }
        char[] input, output;

        public List<MyReverseChar> reverseList = new List<MyReverseChar>();
        public CyclickSort(string inputValue, int intOrder)
        {
            this.intOrder = intOrder;
            this.inputValue = inputValue ?? throw new ArgumentNullException(nameof(inputValue));
            input = inputValue.ToCharArray();
            output = Sorting(input, this.intOrder);
        }

        public string getReverse()
        {
            List<MyReverseChar> MyListTemp1 = reverseList.OrderBy(x => x.index).ToList();
            string reveseResult = "";
            foreach (MyReverseChar item in MyListTemp1)
            {
                reveseResult = reveseResult + item.c.ToString();
            }
            return reveseResult;
        }

        public char[] GetOutput()
        {
            return output;
        }

        public char[] Sorting(char[] input, int order)
        {
            List<char> InputList = input.ToList<char>();
            int currentOffset = 0;
            List<char> InputListBuild = new List<char>();
            while (InputList.Count > 0)
            {
                currentOffset = currentOffset + order - 1;
                while (currentOffset > (InputList.Count() - 1))
                {

                    currentOffset = currentOffset - InputList.Count();
                }

                InputListBuild.Add(InputList[currentOffset]);
                InputList.RemoveAt(currentOffset);
            }
            return InputListBuild.ToArray();
        }

        public void CaculateReverseValue(string strValue, int intOrder)
        {
            this.inputValue = strValue;
            this.intOrder = intOrder;
            List<char> InputList = strValue.ToList();

            List<MyReverseChar> InputListBuild = new List<MyReverseChar>();

            for (int i = 0; i < InputList.Count; i++)
            {
                InputListBuild.Add(new NetTesting.MyReverseChar(i, ' '));
            }

            int currentOffset = 0;

            while (InputList.Count > 0)
            {
                currentOffset = currentOffset + intOrder - 1;
                while (currentOffset > (InputListBuild.Count - 1))
                {
                    currentOffset = currentOffset - InputListBuild.Count();
                }
                int oldcurrentOffset = currentOffset;
                int ncurrentOffset = InputListBuild[currentOffset].index;
                MyReverseChar ml = new MyReverseChar(ncurrentOffset, InputList[0]);
                InputListBuild.RemoveAt(oldcurrentOffset);
                reverseList.Add(ml);
                InputList.RemoveAt(0);
            }
        }
    }
}
