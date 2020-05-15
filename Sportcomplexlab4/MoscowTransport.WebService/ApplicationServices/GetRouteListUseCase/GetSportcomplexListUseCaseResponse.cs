using Sportcomplex.DomainObjects;
using Sportcomplex.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sportcomplex.ApplicationServices.GetRouteListUseCase
{
    public class GetSportcomplexListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<DomainObjects.Sportcomplex> Sportcomplex { get; }

        public GetSportcomplexListUseCaseResponse(IEnumerable<DomainObjects.Sportcomplex> Sportcomplexs) => Sportcomplex = Sportcomplexs;
    }
}
