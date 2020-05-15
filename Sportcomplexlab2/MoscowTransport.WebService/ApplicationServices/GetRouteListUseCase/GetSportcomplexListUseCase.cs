using System.Threading.Tasks;
using System.Collections.Generic;
using Sportcomplex.DomainObjects;
using Sportcomplex.DomainObjects.Ports;
using Sportcomplex.ApplicationServices.Ports;

namespace Sportcomplex.ApplicationServices.GetSportcomplexListUseCase
{
    public class GetSportcomplexListUseCase : IGetSportcomplexListUseCase
    {
        private readonly IReadOnlySportcomplexRepository _readOnlySportcomplexRepository;

        public GetSportcomplexListUseCase(IReadOnlySportcomplexRepository readOnlySportcomplexRepository) 
            => _readOnlySportcomplexRepository = readOnlySportcomplexRepository;

        public async Task<bool> Handle(GetSportcomplexListUseCaseRequest request, IOutputPort<GetSportcomplexListUseCaseResponse> outputPort)
        {
            IEnumerable<DomainObjects.Sportcomplex> Sportcomplexs = null;
            if (request.SportcomplexId != null)
            {
                var Sportcomplex = await _readOnlySportcomplexRepository.GetRoute(request.SportcomplexId.Value);
                Sportcomplexs = (Sportcomplex != null) ? new List<DomainObjects.Sportcomplex>() { Sportcomplex } : new List<DomainObjects.Sportcomplex>();
                
            }
            else if (request.OrganizationId != null)
            {
                Sportcomplexs = await _readOnlySportcomplexRepository.QueryRoutes(new SportcomplexCriteria(request.OrganizationId.Value));
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
