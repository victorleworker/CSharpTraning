using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTesting
{
    class BankHousingLoan
    {
        private double dAPercent { get; set; }
        private double dRM { get; set; }
        private double dFixInterest { get; set; }
        private int dYear { get; set; }
        private double dMonthlyRepayment { get; set; }
        public void SetMonthlyRepayment(double MonthlyRepayment)
        {
            this.dMonthlyRepayment = MonthlyRepayment;
        }
        public void SetRM(double rm)
        {
            this.dRM = rm;
        }
        public BankHousingLoan()
        {

        }

        public BankHousingLoan(double fAPercent, double fRM, double fFixInterest, int fYear,double dDM=0)
        {
            this.dAPercent = fAPercent;
            this.dRM = fRM;
            this.dFixInterest = fFixInterest;
            this.dYear = fYear;
            this.dMonthlyRepayment = dDM;
        }

        public double CaculateRM()
        {          
            double dP = (dAPercent / 100) * dRM;
            double dr = (dFixInterest / 100) / 12;

            double dTop = dr * Math.Pow((1 + dr), dYear * 12);
            double dbelow = Math.Pow((1 + dr), dYear * 12) - 1;
            return dP * (dTop / dbelow);
        }
        public double CaculateYear()
        {
            double dP = (dAPercent / 100) * dRM;
            double dr = (dFixInterest / 100) / 12;
            double dnumber = this.dMonthlyRepayment / (this.dMonthlyRepayment-dP*dr);
            double dbase = 1 + dr;
            this.dYear=(int) Math.Log(dnumber, dbase)/12;
            return this.dYear;
        }
        public double CaculateNumber()
        {
            double dP = (dAPercent / 100) * dRM;
            double dr = (dFixInterest / 100) / 12;

            double dTop = dr * Math.Pow((1 + dr), dYear * 12);
            double dbelow = Math.Pow((1 + dr), dYear * 12) - 1;
            this.dRM = (this.dMonthlyRepayment * dbelow) / (dTop*(dAPercent/100));
            return this.dRM;
        }

    }
}
