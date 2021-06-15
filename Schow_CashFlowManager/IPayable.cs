using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schow_CashFlowManager
{
    interface IPayable
    {
        // Creating Base properties and the LedgerType Enumerator
        decimal GetPayableAmount { get; }
        LedgerType GetLedgerType();
        
    }

    public enum LedgerType
    {
        SALARIED,
        HOURLY,
        INVOICE
    }
}
