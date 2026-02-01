using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_oktatas.bank
{
    public record Transaction(DateTime Timestamp, decimal Amount, string Note);
}
