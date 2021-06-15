using System;
using System.Threading;

// Ian Schow
// IT112
// Notes: This project has taken more time than most of the other ones, 
// but that might've been because I was spacing my work out.
// I was able to get through the assignment without any major issues,
// which is nice. All in all, a fun project!
// ALL BEHAVIORS IMPLEMENTED
namespace Schow_CashFlowManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating my array, filling it, and creating variables
            IPayable[] CashFlowArray = new IPayable[50];
            InitArray(ref CashFlowArray);
            int counter = 9;
            bool cont = false;
            // Playing a little boot up sequence
            BootUp();
            // Starting the main do loop
            do
            {
                // Gathering what the user would like to do, and sending them to the appropriate method
                // The counter increases so nothing is overwritten
                int response = Interface();
                if (response == 1)
                {
                    CreateInvoice(ref CashFlowArray, counter);
                    counter++;
                }
                else if (response == 2)
                {
                    CreateHourly(ref CashFlowArray, counter);
                    counter++;
                }
                else if (response == 3)
                {
                    CreateSalaried(ref CashFlowArray, counter);
                    counter++;
                }
                else if (response == 4)
                {
                    WCFAnalysis(ref CashFlowArray, counter);
                }
                // Determining if the user would like to continue
                cont = Proceed();
            } while (cont == true);
        }
        static void BootUp()
        {
            // Sending a message displaying that data has already been placed in the array
            Console.WriteLine("Assembling the base team...");
            Thread.Sleep(1000);
            Console.WriteLine("Done!");
            Thread.Sleep(500);
            Console.Clear();
            
        }
        static int Interface()
        {
            // Determining what the user would like to do
            bool success = false;
            int parsedResponse;
            do
            {
                Console.WriteLine("Choose one of the following: (input 1, 2...)");
                Console.WriteLine("1. Add Invoice");
                Console.WriteLine("2. Add Hourly Employee");
                Console.WriteLine("3. Add Salaried Employee");
                Console.WriteLine("4. Generate Weekly Cash Flow Analysis");
                string response = Console.ReadLine();
                success = int.TryParse(response, out parsedResponse);
                if (success == false || parsedResponse <= 0 || parsedResponse >= 5)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please try again");
                    Console.WriteLine();
                }
            } while (success == false);
            return parsedResponse;
        }
        static void InitArray(ref IPayable[] CFA)
        {
            // Creating the original nine array items
            CFA[0] = new Invoice("4653", "Hyperdrive", 72, 19999.99M);
            CFA[1] = new Invoice("6425", "Sonic Screwdriver", 13, 256.75M);
            CFA[2] = new Invoice("4242", "Supercomputer", 42, 42.42M);
            CFA[3] = new HourlyEmployee("Bob", "Ross", "134659785", 34.63M, 37);
            CFA[4] = new HourlyEmployee("Bert", "Sesame", "123456789", 12.34M, 32);
            CFA[5] = new HourlyEmployee("Ernie", "Sesame", "987654321", 43.21M, 23);
            CFA[6] = new SalariedEmployee("Napoleon", "Dynamite", "456621378", 2004);
            CFA[7] = new SalariedEmployee("Mark", "Rober", "613485294", 2011);
            CFA[8] = new SalariedEmployee("Tom", "Sawyer", "164581129", 1876);
        }
        static void CreateInvoice(ref IPayable[] CFA, int arrLocation)
        {
            // Gathering information for a new Invoice, and then creating it
            Console.Clear();
            Console.WriteLine("What is the name of this part?");
            string pNum = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("What is the part number? (4 digits)");
            string pName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("How many of this part are being ordered?");
            int quan = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("How much does this part cost?");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Clear();
            CFA[arrLocation] = new Invoice(pNum, pName, quan, price);
        }
        static void CreateHourly(ref IPayable[] CFA, int arrLocation)
        {
            // Gathering information for a new Hourly Employee, and then creating it
            Console.Clear();
            Console.WriteLine("What is this employee's first name?");
            string fName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("What is this employee's last name?");
            string lName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("What is this employee's Social Security Number? (9 Digits)");
            string SSN = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("How much does this employee make an hour?");
            decimal wages = decimal.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("How many hours did this employee work this week?");
            int hours = int.Parse(Console.ReadLine());
            Console.Clear();
            CFA[arrLocation] = new HourlyEmployee(fName, lName, SSN, wages, hours);
        }
        static void CreateSalaried(ref IPayable[] CFA, int arrLocation)
        {
            // Gathering information for a new Salaried employee, and then creating it
            Console.Clear();
            Console.WriteLine("What is this employee's first name?");
            string fName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("What is this employee's last name?");
            string lName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("What is this employee's Social Security Number? (9 Digits)");
            string SSN = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("What is this employee's weekly salary?");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Clear();
            CFA[arrLocation] = new SalariedEmployee(fName, lName, SSN, salary);
        }
        static void WCFAnalysis(ref IPayable[] CFA, int counter)
        {
            // Creating Variables
            decimal totalPayout = 0;
            decimal totalInvoice = 0;
            decimal totalHourly = 0;
            decimal totalSalaried = 0;
            // Displaying Report
            Console.Clear();
            Console.WriteLine("Weekly Cash Flow Analysis is as follows:");
            Console.WriteLine();
            for (int i = 0; i < counter; i++)
            {
                // Gathering all data for each invoice as they pass through the for loop,
                // and adding it to the totals
                if (CFA[i].GetLedgerType() == LedgerType.INVOICE)
                {
                    Invoice curIn = (Invoice)CFA[i];
                    Console.WriteLine("Invoice: " + curIn.RNum.ToString() + "_" + curIn.PartNumber.ToString());
                    Console.WriteLine("Quantity: " + curIn.Quantity.ToString());
                    Console.WriteLine("Part Description: " + curIn.PartDescription.ToString());
                    Console.WriteLine(String.Format("Unit Price: {0:C2}", curIn.Price));
                    Console.WriteLine(String.Format("Extended Price: {0:C2}", curIn.GetPayableAmount));
                    Console.WriteLine();
                    totalPayout += curIn.GetPayableAmount;
                    totalInvoice += curIn.GetPayableAmount;
                }
                else if (CFA[i].GetLedgerType() == LedgerType.HOURLY)
                {
                    // Gathering all data for each hourly employee as they pass through the for loop,
                    // and adding it to the totals
                    HourlyEmployee curHr = (HourlyEmployee)CFA[i];
                    Console.WriteLine("Hourly employee: " + curHr.FirstName.ToString() + " " + curHr.LastName.ToString());
                    Console.WriteLine(String.Format("SSN: {0:000-00-0000}", curHr.SocSecNum));
                    Console.WriteLine(String.Format("Hourly Wage Salary: {0:C2}", curHr.GetPayableAmount));
                    Console.WriteLine("Hours Worked: " + curHr.Hours.ToString());
                    Console.WriteLine(String.Format("Earned: {0:C2}", curHr.TotalEarnings()));
                    Console.WriteLine();
                    totalPayout += curHr.TotalEarnings();
                    totalHourly += curHr.TotalEarnings();
                }
                else if (CFA[i].GetLedgerType() == LedgerType.SALARIED)
                {
                    // Gathering all data for each salaried employee as they pass through the for loop,
                    // and adding it to the totals
                    SalariedEmployee curSal = (SalariedEmployee)CFA[i];
                    Console.WriteLine("Salaried employee: " + curSal.FirstName.ToString() + " " + curSal.LastName.ToString());
                    Console.WriteLine(String.Format("SSN: {0:000-00-0000}", curSal.SocSecNum));
                    Console.WriteLine(String.Format("Weekly Salary: {0:C2}", curSal.GetPayableAmount));
                    Console.WriteLine(String.Format("Earned: {0:C2}", curSal.TotalEarnings()));
                    Console.WriteLine();
                    totalPayout += curSal.TotalEarnings();
                    totalSalaried += curSal.TotalEarnings();
                }
            }
            // Presenting totals
            Console.WriteLine(String.Format("Total Weekly Payout: {0:C2}", totalPayout));
            Console.WriteLine("Category Breakdown:");
            Console.WriteLine(String.Format("Invoices: {0:C2}", totalInvoice));
            Console.WriteLine(String.Format("Hourly Payroll: {0:C2}", totalHourly));
            Console.WriteLine(String.Format("Salaried Payroll: {0:C2}", totalSalaried));
            Console.WriteLine();
        }
        static bool Proceed()
        {
            // Determining whether or not the user would like to continue
            bool proceed = false;
            Console.WriteLine("Would you like to continue? Y/N");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
                proceed = true;
            else
                proceed = false;
            Console.Clear();
            return proceed;
        }
    }
}
