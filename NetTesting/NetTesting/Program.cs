using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //task1 basic
            BankHousingLoan bhl = new BankHousingLoan(90, 500000, 4.65, 30);
            Console.WriteLine("Task1 1----------");
            Console.WriteLine("Loan:90% of property,RM 500,000,fixed interest rateL: 4.65% per annum, over a period of 30 years=>the monthly repayment:");
            Console.WriteLine(bhl.CaculateRM());

            //task 1 advance 1
            bhl.SetMonthlyRepayment(2000);
            Console.WriteLine("Task1 Advance 1-----------");
            Console.WriteLine("Loan:90% of property,RM 500,000 ,fixed interest rateL: 4.65% per annum,monthly repayment:2000=>loan period (in years):");
            Console.WriteLine(bhl.CaculateYear());
            //task1 advance 2
            bhl.SetMonthlyRepayment(2000);
            Console.WriteLine("Task1 Advance 2----------");
            Console.WriteLine("Loan:90% of property,fixed interest rateL: 4.65% per annum, over a period of 30 years,monthly repayment:2000=>the loan amount to borrow : ");
            Console.WriteLine(bhl.CaculateNumber());

            //task 2 basic
            Console.WriteLine("*******************************************************************************************************");
            Console.WriteLine("Task2 Basic1----------");
            try
            {
                DigitAlgorithm da = new DigitAlgorithm(543215432154321);
                Console.WriteLine("the value is: " + da.GetValue());
                Console.WriteLine("The check digit is: " + da.GetCheckDigit().ToString());
                Console.WriteLine("The generated reference number is: " + da.GetReferenceNumber().ToString());

                Console.WriteLine("Task2 Basic2----------");
                Console.WriteLine(" check digits evenly distributed between 101 to 999");
                List<DigitList> dl= da.CheckDigitBetween101To999();
                foreach (DigitList item in dl)
                {
                    Console.WriteLine($"Number of {item.index} is: {item.value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }

            //task 3 basic
            Console.WriteLine("*******************************************************************************************************");
            Console.WriteLine("Task3 Basic1-------------");
                    
            try
            {
                CyclickSort cs = new CyclickSort("0123456789ABCDEF", 11);
                Console.WriteLine($"The output of {cs.inputValue}, if the order is {cs.intOrder}:");
                Console.WriteLine(new string( cs.GetOutput()));
                Console.WriteLine("Task3 Advance 1-----------");
                cs.CaculateReverseValue("d nntobmeanhnld ftcitao.Laluw lyteuhtoohevet iGa rs llUnai coBn o  oayg. p no .oddf .ityio gntire d. LoKrRiouyiG", 13);
                Console.WriteLine($"the original message of \"{cs.inputValue}\", if the order is {cs.intOrder}:");
                Console.WriteLine(cs.getReverse());            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
