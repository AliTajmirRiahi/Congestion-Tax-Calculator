using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Application.Contracts.CongestionTax
{
    public class CalculatorCongestionTaxCommand
    {
        public int VehicleId { get; set; }

        public List<DateTime> Dates { get; set; }
    }
}
