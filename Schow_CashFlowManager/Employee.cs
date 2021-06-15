using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schow_CashFlowManager
{
    class Employee : IPayable
    {
        // Creating variables
        string fName;
        string lName;
        string SSN;

        // Creating Properties
        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
        public string LastName
        {
            get { return lName; }
            set { lName = value; }
        }
        public string SocSecNum
        {
            get { return SSN; }
            set { SSN = value; }
        }

        // Constructing the Employee object
        public Employee() { }
        public Employee(string fName, string lName, string ssn)
        {
            // Assigning variables
            FirstName = fName;
            LastName = lName;
            SSN = ssn;
        }
        public virtual decimal GetPayableAmount
        {
            // Providing the base GetPayableAmount property to be overriden in subclasses
            get { return 0; }
        }
        public virtual LedgerType GetLedgerType()
        {
            // Providing the base GetLedgerType() method to be overriden in subclasses
            return 0;
        }

        public virtual decimal TotalEarnings()
        {
            // Providing the base TotalEarnings() method to be overriden in subclasses
            return 0;
        }
    }
}
