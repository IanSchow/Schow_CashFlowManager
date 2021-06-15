using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Schow_CashFlowManager
{
    class Invoice : IPayable
    {
        // Creating Variables
        string rNum;
        string PartNum;
        int quantity;
        string partDesc;
        decimal price;

        // Constructing the Invoice object
        public Invoice(string pNum, string pDesc, int quan, decimal price)
        {
            // Gerating a random six digit number
            Random r = new Random(DateTime.Now.Millisecond);
            Thread.Sleep(1); // Guarantees that each random number is different (two kept being output the same)
            rNum = r.Next(100000, 999999).ToString();
            // Assigning properties
            PartNumber = pNum;
            PartDescription = pDesc;
            Quantity = quan;
            Price = price;
        }
        public decimal GetPayableAmount
        {
            // Returning the combined total of all parts of this type
            get { return Math.Round(Price * Quantity, 3); }
        }
        public LedgerType GetLedgerType()
        {
            // Returns what type the Invoice is
            LedgerType Ledger = LedgerType.INVOICE;
            return Ledger;
        }

        // Creating properties
        public string RNum
        {
            get { return rNum; }
            set { rNum = value; }
        }
        public string PartNumber
        {
            get { return PartNum; }
            set { PartNum = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string PartDescription
        {
            get { return partDesc; }
            set { partDesc = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

    }
}
