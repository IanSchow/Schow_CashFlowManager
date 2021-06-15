using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schow_CashFlowManager
{
    class SalariedEmployee : Employee
    {
        // Creating variables
        private decimal wages;

        // Constructing the Salaried Employee object
        public SalariedEmployee(string fName, string lName, string SSN, decimal weeklySalary)
        {
            // Assigning variables and properties
            wages = weeklySalary;
            FirstName = fName;
            LastName = lName;
            SocSecNum = SSN;
        }

        public override decimal GetPayableAmount
        {
            // Returning salary
            get { return wages; }
        }
        public override LedgerType GetLedgerType()
        {
            // Declaring that this is the Salaried Employee object
            LedgerType Ledger = LedgerType.SALARIED;
            return Ledger;
        }
        public override decimal TotalEarnings()
        {
            // Returning Salary total
            return wages;
        }
    }
}
