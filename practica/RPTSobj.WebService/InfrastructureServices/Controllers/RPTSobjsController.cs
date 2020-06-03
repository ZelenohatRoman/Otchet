using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RPTSobj.DomainObjects;
using RPTSobj.ApplicationServices.GetMetroLineListUseCase;
using RPTSobj.InfrastructureServices.Presenters;

namespace RPTSobj.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RPTSobjsController : ControllerBase
    {
        private readonly ILogger<RPTSobjsController> _logger;
        private readonly IGetRPTSobjListUseCase _getRPTSobjListUseCase;

        public RPTSobjsController(ILogger<RPTSobjsController> logger,
                                IGetRPTSobjListUseCase getRPTSobjListUseCase)
        {
            _logger = logger;
            _getRPTSobjListUseCase = getRPTSobjListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRPTSobjs()
        {
            var presenter = new RPTSobjListPresenter();
            await _getRPTSobjListUseCase.Handle(GetRPTSobjListUseCaseRequest.CreateAllRPTSobjsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{rptsobjId}")]
        public async Task<ActionResult> GetRPTSobj(long rptsobjId)
        {
            var presenter = new RPTSobjListPresenter();
            await _getRPTSobjListUseCase.Handle(GetRPTSobjListUseCaseRequest.CreateRPTSobjRequest(rptsobjId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("metroline/{metroline}")]
        public async Task<ActionResult> GetMetroLineRPTSobjs(string metroline)
        {
            var presenter = new RPTSobjListPresenter();
            await _getRPTSobjListUseCase.Handle(GetRPTSobjListUseCaseRequest.CreateRPTSobjsRequest(metroline), presenter);
            return presenter.ContentResult;
        }
    }
}
