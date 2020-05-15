using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sportcomplex.DomainObjects;

namespace Sportcomplex.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly ILogger<RoutesController> _logger;

        public RoutesController(ILogger<RoutesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<DomainObjects.Sportcomplex> GetRoute()
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
