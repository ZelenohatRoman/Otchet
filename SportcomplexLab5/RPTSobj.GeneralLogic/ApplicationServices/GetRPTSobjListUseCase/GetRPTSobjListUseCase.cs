using System.Threading.Tasks;
using System.Collections.Generic;
using RPTSobj.DomainObjects;
using RPTSobj.DomainObjects.Ports;
using RPTSobj.ApplicationServices.Ports;

namespace RPTSobj.ApplicationServices.GetMetroLineListUseCase
{
    public class GetRPTSobjListUseCase : IGetRPTSobjListUseCase
    {
        private readonly IReadOnlyRPTSobjRepository _readOnlyRPTSobjRepository;

        public GetRPTSobjListUseCase(IReadOnlyRPTSobjRepository readOnlyRPTSobjRepository) 
            => _readOnlyRPTSobjRepository = readOnlyRPTSobjRepository;
        
        public async Task<bool> Handle(GetRPTSobjListUseCaseRequest request, IOutputPort<GetRPTSobjListUseCaseResponse> outputPort)
        {
            IEnumerable<rptsobj> rptsobjs = null;
            if (request.RPTSobjId != null)
            {
                var rptsobj = await _readOnlyRPTSobjRepository.GetRPTSobj(request.RPTSobjId.Value);
                rptsobjs = (rptsobj != null) ? new List<rptsobj>() { rptsobj } : new List<rptsobj>();
                
            }
            else if (request.MetroLine != null)
            {
                rptsobjs = await _readOnlyRPTSobjRepository.QueryRPTSobjs(new MetroLineCriteria(request.MetroLine));
            }
            else
            {
                rptsobjs = await _readOnlyRPTSobjRepository.GetAllRPTSobjs();
            }
            outputPort.Handle(new GetRPTSobjListUseCaseResponse(rptsobjs));
            return true;
        }
    }
}
