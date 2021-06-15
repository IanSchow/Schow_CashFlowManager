using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schow_CashFlowManager
{
    class HourlyEmployee : Employee
    {
        // Creating variables
        private decimal hours;
        private decimal wages;

        // Creating properties
        public decimal Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        // Constructing the Hourly Employee Object
        public HourlyEmployee(string fName, string lName, string SSN, decimal hourlyWage, decimal hoursWorked)
        {
            // Assigning variables
            wages = hourlyWage;
            Hours = hoursWorked;
            FirstName = fName;
            LastName = lName;
            SocSecNum = SSN;
        }
        public override decimal GetPayableAmount
        {
            // Returning hourly wages
            get { return wages; }
        }
        public override LedgerType GetLedgerType()
        {
            // Declaring that this is the Hourly Employee object
            LedgerType Ledger = LedgerType.HOURLY;
            return Ledger;
        }
        public override decimal TotalEarnings()
        {
            // Determing whether or not to include overtime, and doing the math accordingly
            if (hours - 40M >= 0)
                return Math.Round(((wages * 40M) + Overtime()), 3);
            else
                return Math.Round(wages * hours, 3);
        }

        private decimal Overtime()
        {
            // Determining how much overtime pay should be given
            decimal otPay = 0;
            decimal ot = hours - 40M;
            if (ot > 0)
                otPay = ot * wages * 1.5M;
            Math.Round(otPay, 3);
            return otPay;
        }
    }
}
