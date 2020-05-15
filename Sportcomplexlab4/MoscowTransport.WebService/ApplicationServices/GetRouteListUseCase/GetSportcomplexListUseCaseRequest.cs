using Sportcomplex.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sportcomplex.ApplicationServices.GetRouteListUseCase
{
    public class GetSportcomplexListUseCaseRequest : IUseCaseRequest<GetSportcomplexListUseCaseResponse>
    {
        public long? SportcomplexId { get; private set; }

        private GetSportcomplexListUseCaseRequest()
        { }

        public static GetSportcomplexListUseCaseRequest CreateAllSportcomplexRequest()
        {
            return new GetSportcomplexListUseCaseRequest();
        }

        public static GetSportcomplexListUseCaseRequest CreateSportcomplexRequest(long SportcomplexId)
        {
            return new GetSportcomplexListUseCaseRequest() { SportcomplexId = SportcomplexId };
        }
        public static GetSportcomplexListUseCaseRequest CreateOrganizationRoutesRequest(long SportcomplexId)
        {
            return new GetSportcomplexListUseCaseRequest() { SportcomplexId = SportcomplexId };
        }
    }
}
