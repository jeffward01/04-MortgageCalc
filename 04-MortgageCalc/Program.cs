using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_MortgageCalc
{
    class Program
    {
        //Global Varibles 
        public static string Line = "----------------------- \n \n ";
        public static string DLine = "----------------------- \n---------------------- \n \n";
        public static string Break = "\n \n";

        // declare variables
        public static double principle = 0;
       public static double years = 0;
        public static double interest = 0;
       public static string principleInput, yearsInput, interestInput;
        public static string finalMonthlyPayment;
        public static double downPaymentdbl = 0;






        public static void ProgramIntro()
        {
            Console.WriteLine(DLine);
            Console.WriteLine("Welcome to Tilr's Mortgage Calculator!! (V.05)");
            Console.WriteLine(Line);
            Console.WriteLine("Please know a few things before you continue... \n");
            Console.WriteLine("1.) The price of the home ($).");
            Console.WriteLine("2.) The loan term in years.");
            Console.WriteLine("3.) The interest rate");
            Console.WriteLine("4.) The downpayment ($), if any... \n");
            Console.WriteLine(DLine);
            Console.WriteLine("Press enter to continue forward!");
            Console.ReadLine();
            Console.Clear();
        }

        public static void GetInfo()
        {
            // User input for Principle amount in dollars

            decimal downPaymentDec = JeffToolBox.ReadCurrency("Enter the DownPayment amount, (If any) in dollars(0000.00)", true, true);
            downPaymentdbl = Convert.ToDouble(downPaymentdbl);


            decimal DprincipleInput = JeffToolBox.ReadCurrency("Enter the loan amount, in dollars(0000.00)", true, false);


            principle = Convert.ToDouble(DprincipleInput);



            // User input for number of years
            decimal Dyearsinput = JeffToolBox.ReadDecimal("Enter the Number of Years", true, false);



            years = Convert.ToDouble(Dyearsinput);

            // User input for interest rate
            Console.Write("Enter the interest rate(%): ( Do not add the '%') ");
            decimal DinterestInput = JeffToolBox.ReadInterestRate("Enter the interest rate(%): ( Do not add the '%') ", true, false);

            interest = Convert.ToDouble(DinterestInput);



        }
        public static void calcMort()
        {
            //Calculate the monthly payment
            //ADD IN THE .Net function call Math.pow(x, y) to compute xy (x raised to the y power). 
            double loanM = (interest / 1200.0);
            double numberMonths = years * 12;
            double negNumberMonths = 0 - numberMonths;
            principle = principle - downPaymentdbl;

            string TotalDownPayment = downPaymentdbl.ToString("C");

            double monthlyPayment = principle * loanM / (1 - System.Math.Pow((1 + loanM), negNumberMonths));


            finalMonthlyPayment = monthlyPayment.ToString("C");
            string totalLoanAmount = principle.ToString("C");


            double totalCost = (monthlyPayment * numberMonths);
            string totalMortCost = totalCost.ToString("C");

            double interestEarned = totalCost - principle;
            string TotalInterestPaid = interestEarned.ToString("C");

            //Output the result of the monthly payment
            Console.WriteLine(DLine);
            Console.WriteLine("-------Mortgage Information------- \n");
            Console.WriteLine("-   You made a downpayment of: {0}" , downPaymentdbl.ToString("C"));
            Console.WriteLine("-   The total amount of the loan is: {0}", totalLoanAmount);
            Console.WriteLine("-   The number of monthly payments is: {0}", numberMonths);
            Console.WriteLine(String.Format("-   The amount of the monthly payment is: {0}", finalMonthlyPayment));
            Console.WriteLine("-   The total cost of the Mortgage is: {0}",totalMortCost);
            Console.WriteLine("-  The total Interest Earned is: {0}", TotalInterestPaid);
            Console.WriteLine();
            Console.WriteLine("-  Press the Enter key to end. . .");
            Console.Read();

        }



        static void Main(string[] args)
        {
            ProgramIntro();

            GetInfo();

            calcMort();

  

          

        }

    }
}
