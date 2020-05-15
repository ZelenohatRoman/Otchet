using Sportcomplex.DomainObjects;
using Sportcomplex.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sportcomplex.ApplicationServices.GetSportcomplexListUseCase
{
    public class SportcomplexCriteria : ICriteria<DomainObjects.Sportcomplex>
    {
        public long SportcomplexId { get; }

        public Expression<Func<DomainObjects.Sportcomplex, bool>> Filter => throw new NotImplementedException();

        public SportcomplexCriteria(long SportcomplexId)
            => this.SportcomplexId = SportcomplexId;

    }
}
