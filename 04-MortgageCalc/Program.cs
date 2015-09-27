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

        public static decimal homePrice, loanTerm, UserinterestRate, downPayment;
        public static decimal loan = homePrice - downPayment;
        public static decimal TermOfLoan = loanTerm * 12;
        public static decimal InterestRate = UserinterestRate / 100;

        public static double monthlyPaymentDbl;



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
        }

        public static void getUserInput()
        {
            Console.Clear();
            Console.WriteLine(DLine);
            homePrice = JeffToolBox.ReadCurrency("Enter the price of the home ($)", true, false);
            Console.WriteLine(Break);
            loanTerm = JeffToolBox.ReadDecimal("Enter the length of the loan term in years", true, false);
            Console.WriteLine(Break);
            UserinterestRate = JeffToolBox.ReadDecimal("Enter the interest (%) || Do not enter the % symbol", true, false);
            Console.WriteLine(Break);
            downPayment = JeffToolBox.ReadDecimal("Please enter the downpayment ($), Enter 0 if there is no downpayment.", true, true);
        }
        public static void CalcMort()
        {
            double homePriceDbl = Convert.ToDouble(homePrice);
            double interestRateDbl = Convert.ToDouble(UserinterestRate);
            double downpaymentDbl = Convert.ToDouble(downPayment);
            double TermOfLoanDbl = Convert.ToDouble(TermOfLoan);
            double currentLoanValueDbl = homePriceDbl - downpaymentDbl;
            Console.WriteLine("Yur current Loan Amount is: {0}", currentLoanValueDbl);


            double holder = (homePriceDbl - downpaymentDbl) * (Math.Pow((1 + interestRateDbl / 12), TermOfLoanDbl) * interestRateDbl) / (12 * (Math.Pow((1 + interestRateDbl / 12), TermOfLoanDbl) - 1));


            double rate = (interestRateDbl/1200.0);
            double negNumberOfMonths = 0 - TermOfLoanDbl;
            double final = currentLoanValueDbl * rate / (1 - System.Math.Pow((1 + rate), TermOfLoanDbl));


         //   double denaminator = Math.Pow((1 + rate), TermOfLoanDbl) - 1;
       //     Console.WriteLine("This is your denaminator: {0}", denaminator);
    //        double final= (rate + (rate / denaminator)) * currentLoanValueDbl;



            Console.WriteLine("Your Monthly Payment is: {0}", final);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

        }
        


        static void Main(string[] args)
        {
            ProgramIntro();

            // declare variables
            double principle = 0;
            double years = 0;
            double interest = 0;
            string principleInput, yearsInput, interestInput;


            // User input for Principle amount in dollars
            decimal DprincipleInput = JeffToolBox.ReadCurrency("Enter the loan amount, in dollars(0000.00)", true, false);


            principle = Convert.ToDouble(DprincipleInput);
            


            // User input for number of years
           decimal Dyearsinput =JeffToolBox.ReadDecimal("Enter the Number of Years", true, false);



            years = Convert.ToDouble(Dyearsinput);
           
            // User input for interest rate
            Console.Write("Enter the interest rate(%): ( Do not add the '%') ");
            decimal DinterestInput = JeffToolBox.ReadInterestRate("Enter the interest rate(%): ( Do not add the '%') ", true, false);

            interest = Convert.ToDouble(DinterestInput);
           

            //Calculate the monthly payment
            //ADD IN THE .Net function call Math.pow(x, y) to compute xy (x raised to the y power). 
            double loanM = (interest / 1200.0);
            double numberMonths = years * 12;
            double negNumberMonths = 0 - numberMonths;
            double monthlyPayment = principle * loanM / (1 - System.Math.Pow((1 + loanM), negNumberMonths));


            string final = monthlyPayment.ToString("C");

            //Output the result of the monthly payment
            Console.WriteLine(String.Format("The amount of the monthly payment is: {0}",final));
            Console.WriteLine();
            Console.WriteLine("Press the Enter key to end. . .");
            Console.Read();

        }

    }
}
