using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sportcomplex.DomainObjects;
using Sportcomplex.ApplicationServices.GetRouteListUseCase;
using Sportcomplex.InfrastructureServices.Presenters;

namespace Sportcomplex.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportcomplexController : ControllerBase
    {
        private readonly ILogger<SportcomplexController> _logger;
        private readonly IGetSportcomplexListUseCase _getSportcomplexListUseCase;

        public SportcomplexController(ILogger<SportcomplexController> logger,
                                IGetSportcomplexListUseCase getSportcomplexListUseCase)
        {
            _logger = logger;
            _getSportcomplexListUseCase = getSportcomplexListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRoutes()
        {
            var presenter = new SportcomplexListPresenter();
            await _getSportcomplexListUseCase.Handle(GetSportcomplexListUseCaseRequest.CreateAllSportcomplexRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{routeId}")]
        public async Task<ActionResult> GetSportcomplex(long SportcomplexId)
        {
            var presenter = new SportcomplexListPresenter();
            await _getSportcomplexListUseCase.Handle(GetSportcomplexListUseCaseRequest.CreateSportcomplexRequest(SportcomplexId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("Sportcomplex/{SportcomplexId}")]
        public async Task<ActionResult> GetSportcomplex1(long SportcomplexId)
        {
            var presenter = new SportcomplexListPresenter();
            await _getSportcomplexListUseCase.Handle(GetSportcomplexListUseCaseRequest.CreateOrganizationRoutesRequest(SportcomplexId), presenter);
            return presenter.ContentResult;
        }
    }
}
