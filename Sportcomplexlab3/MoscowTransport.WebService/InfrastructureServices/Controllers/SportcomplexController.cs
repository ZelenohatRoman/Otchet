using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sportcomplex.DomainObjects;

namespace Sportcomplex.WebService.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportcomplexController : ControllerBase
    {
        private readonly ILogger<SportcomplexController> _logger;

        public SportcomplexController(ILogger<SportcomplexController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<DomainObjects.Sportcomplex> GetAllRoutes()
        {
            return new List<DomainObjects.Sportcomplex>()
            {
                new DomainObjects.Sportcomplex()
                {
                    Id = 1,
                    Legitiveaddress = "Ленинградский проспект, дом 36, строение 21",
                    Name = "УЧРЕЖДЕНИЕ «МОСКОВСКИЙ ФИЗКУЛЬТУРНО-СПОРТИВНЫЙ КЛУБ «ЮНЫЙ ДИНАМОВЕЦ»",
                    FIO = "генеральный директор",
                    Rang = "Тихонюк Виктор Дмитриевич",
                }
            };
        }
    }
}

