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

namespace Arta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ArtaDbContext _dbContext;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public UserController(ArtaDbContext dbContext, IStringLocalizer<SharedResources> localizer)
        {
            _dbContext = dbContext;
            _localizer = localizer;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate()
        {
            var result = await _dbContext.Users.ToListAsync();
            var tt = _localizer["Test"];
            return Ok(tt);
        }
    }
}
