using Sportcomplex.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sportcomplex.ApplicationServices.GetRouteListUseCase
{
    public class GeSportcomplexListUseCaseRequest : IUseCaseRequest<GetSportcomplexListUseCaseResponse>
    {
        public long? OrganizationId { get; private set; }
        public long? SportcomplexId { get; private set; }

        private GeSportcomplexListUseCaseRequest()
        { }

        public static GeSportcomplexListUseCaseRequest CreateAllSportcomplexRequest()
        {
            return new GeSportcomplexListUseCaseRequest();
        }

        public static GeSportcomplexListUseCaseRequest CreateSportcomplexRequest(long SportcomplexId)
        {
            return new GeSportcomplexListUseCaseRequest() { SportcomplexId = SportcomplexId };
        }
        public static GeSportcomplexListUseCaseRequest CreateOrganizationSportcomplexsRequest(long SportcomplexId)
        {
            return new GeSportcomplexListUseCaseRequest() { OrganizationId = SportcomplexId };
        }
    }
}
