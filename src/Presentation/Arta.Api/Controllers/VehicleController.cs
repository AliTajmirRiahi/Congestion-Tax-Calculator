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
using Arta.Application.Contracts.VehiclesCommands;

namespace Arta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : BaseController
    {
        private readonly IBus _bus;
        private readonly ArtaDbContext _dbContext;

        public VehicleController(IBus bus, ArtaDbContext dbContext)
        {
            _bus = bus;
            _dbContext = dbContext;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateVehicleCommand command)
        {
            int Id = await _bus.Dispatch<CreateVehicleCommand, int>(command);
            return CustomOk(Id);
        }
    }
}
