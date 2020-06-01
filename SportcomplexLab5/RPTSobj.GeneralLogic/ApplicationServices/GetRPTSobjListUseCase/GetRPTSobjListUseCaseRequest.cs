using RPTSobj.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPTSobj.ApplicationServices.GetMetroLineListUseCase
{
    public class GetRPTSobjListUseCaseRequest : IUseCaseRequest<GetRPTSobjListUseCaseResponse>
    {
        public string MetroLine { get; private set; }
        public long? RPTSobjId { get; private set; }

        private GetRPTSobjListUseCaseRequest()
        { }

        public static GetRPTSobjListUseCaseRequest CreateAllRPTSobjsRequest()
        {
            return new GetRPTSobjListUseCaseRequest();
        }

        public static GetRPTSobjListUseCaseRequest CreateRPTSobjRequest(long rptsobjId)
        {
            return new GetRPTSobjListUseCaseRequest() { RPTSobjId = rptsobjId };
        }
        public static GetRPTSobjListUseCaseRequest CreateRPTSobjsRequest(string metroline)
        {
            return new GetRPTSobjListUseCaseRequest() { MetroLine = metroline };
        }
    }
}
