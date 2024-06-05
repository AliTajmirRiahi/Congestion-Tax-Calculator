using Arta.Persistence.EF.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Framework.Exceptions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Anshan.Framework.Application.Command;
using Arta.Application.Contracts.CongestionTax;
using Arta.Application.CongestionTaxHandlers;

namespace Arta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongestionTaxController : BaseController
    {
        private readonly IBus _bus;
        private readonly ArtaDbContext _dbContext;

        public CongestionTaxController(IBus bus, ArtaDbContext dbContext)
        {
            _bus = bus;
            _dbContext = dbContext;
        }
        [HttpPost("calculator")]
        public async Task<IActionResult> Calculator(CalculatorCongestionTaxCommand command)
        {
            var taxes = await _bus.Dispatch<CalculatorCongestionTaxCommand, List<TaxResult>>(command);
            return CustomOk(taxes);
        }
    }
}
