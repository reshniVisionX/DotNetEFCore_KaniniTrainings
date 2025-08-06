using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    class Insurance
    {
        private string insuranceNo;
        private string insuranceName;
        private double amountCovered;

                
        public Insurance(string insuranceNo, string insuranceName, double amountCovered)
        {
            this.insuranceNo = insuranceNo;
            this.insuranceName = insuranceName;
            this.amountCovered = amountCovered;
        }

        public virtual void CalculatePremium()
        {
            Console.WriteLine("Base premium calculation");
        }
        public string getInsuranceNo()
        {
            return insuranceNo;
        }
        public double getAmountCovered()
        {
            return amountCovered;
        }
    }

    class MotorInsurance:Insurance
    {
        private double idv;
        private float depPercent;

        public MotorInsurance(string insuranceNo, string insuranceName, double amountCovered,double idv, float depPercent):base(insuranceNo,insuranceName,amountCovered)
        {
            this.idv = idv;
            this.depPercent = depPercent;
        }

        public override void CalculatePremium()
        {
            idv = getAmountCovered() - (getAmountCovered() * depPercent) / 100;
            double premium = idv * 0.03;
            Console.WriteLine($"Calculated Premium is : {premium}");
        }
    }

    class LifeInsurance : Insurance
    {
        private int policyTerm;
        private float benefitPercent;

        public LifeInsurance(string insuranceNo, string insuranceName, double amountCovered,int policyTerm,float benefitPercent): base(insuranceNo, insuranceName, amountCovered)
        {
            this.policyTerm = policyTerm;
            this.benefitPercent = benefitPercent;
        }

        public override void CalculatePremium()
        {
            double premium = ((getAmountCovered() - benefitPercent) / 100) / policyTerm;
            Console.WriteLine($"Calculated Premium is : {premium}");
        }
    }


    internal class PayInsurance
    {
        public void PayMain()
        {
            try
            {
                Console.WriteLine("Enter the following data:");
                Console.WriteLine("Insurance Number : ");
                string no = Console.ReadLine();
                Console.WriteLine("Insuarance Name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Amount Covered : ");
                double covered = double.Parse(Console.ReadLine());

                Console.WriteLine("Select : 1.Life Insurance 2.Motor Insurance");
                int ch = int.Parse(Console.ReadLine());
                if (ch == 1)
                {
                    int policyTerm;
                    float benefitPercent;
                    Console.WriteLine("Policy Term : ");
                    policyTerm = int.Parse(Console.ReadLine());
                    Console.WriteLine("Benefits Percent : ");
                    benefitPercent = float.Parse(Console.ReadLine());
                    Insurance ins = new LifeInsurance(no, name, covered, policyTerm, benefitPercent);
                    ins.CalculatePremium();
                }
                else if (ch == 2)
                {
                    double idv;
                    float depPercent;
                    Console.WriteLine("idv : ");
                    idv = double.Parse(Console.ReadLine());
                    Console.WriteLine("Depreciate Percent : ");
                    depPercent = float.Parse(Console.ReadLine());
                    Insurance ins = new MotorInsurance(no, name, covered, idv, depPercent);
                    ins.CalculatePremium();
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured : "+ex.Message);
            }
        }
    }
}
