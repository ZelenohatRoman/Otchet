using System.Threading.Tasks;
using System.Collections.Generic;
using Sportcomplex.DomainObjects;
using Sportcomplex.DomainObjects.Ports;
using Sportcomplex.ApplicationServices.Ports;

namespace Sportcomplex.ApplicationServices.GetRouteListUseCase
{
    public class GetSportcomplexListUseCase : IGetSportcomplexListUseCase
    {
        private readonly IReadOnlySportcomplexRepository _readOnlySportcomplexRepository;

        public GetSportcomplexListUseCase(IReadOnlySportcomplexRepository readOnlySportcomplexRepository) 
            => _readOnlySportcomplexRepository = readOnlySportcomplexRepository;

        public async Task<bool> Handle(GeSportcomplexListUseCaseRequest request, IOutputPort<GetSportcomplexListUseCaseResponse> outputPort)
        {
            IEnumerable<DomainObjects.Sportcomplex> Sportcomplex = null;
            if (request.SportcomplexId != null)
            {
                var route = await _readOnlySportcomplexRepository.GetSportcomplex(request.SportcomplexId.Value);
                Sportcomplex = (route != null) ? new List<DomainObjects.Sportcomplex>() { route } : new List<DomainObjects.Sportcomplex>();
                
            }
            else if (request.OrganizationId != null)
            {
                Sportcomplex = await _readOnlySportcomplexRepository.QuerySportcomplexs(new SportcomplexCriteria(request.OrganizationId.Value));
            }
            else
            {
                Sportcomplex = await _readOnlySportcomplexRepository.GetAllSportcomplexs();
            }
            outputPort.Handle(new GetSportcomplexListUseCaseResponse(Sportcomplex));
            return true;
        }
    }
}
