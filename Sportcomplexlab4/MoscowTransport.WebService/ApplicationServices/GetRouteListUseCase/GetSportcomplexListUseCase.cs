using System.Threading.Tasks;
using System.Collections.Generic;
using Sportcomplex.DomainObjects;
using Sportcomplex.DomainObjects.Ports;
using Sportcomplex.ApplicationServices.Ports;

namespace Sportcomplex.ApplicationServices.GetRouteListUseCase
{
    public class GetSportcomplexListUseCase : IGetSportcomplexListUseCase
    {
        private readonly IReadOnlyRouteRepository _readOnlySportcomplexRepository;

        public GetSportcomplexListUseCase(IReadOnlyRouteRepository readOnlyRouteRepository) 
            => _readOnlySportcomplexRepository = readOnlyRouteRepository;

        public async Task<bool> Handle(GetSportcomplexListUseCaseRequest request, IOutputPort<GetSportcomplexListUseCaseResponse> outputPort)
        {
            IEnumerable<DomainObjects.Sportcomplex> Sportcomplexs = null;
            if (request.SportcomplexId != null)
            {
                var route = await _readOnlySportcomplexRepository.GetRoute(request.SportcomplexId.Value);
                Sportcomplexs  = (route != null) ? new List<DomainObjects.Sportcomplex>() { route } : new List<DomainObjects.Sportcomplex>();
                
            }
            else if (request.SportcomplexId != null)
            {
                Sportcomplexs = await _readOnlySportcomplexRepository.QueryRoutes(new SportcomplexCriteria(request.SportcomplexId.Value));
            }
            else
            {
                Sportcomplexs = await _readOnlySportcomplexRepository.GetAllRoutes();
            }
            outputPort.Handle(new GetSportcomplexListUseCaseResponse(Sportcomplexs));
            return true;
        }
    }
}
