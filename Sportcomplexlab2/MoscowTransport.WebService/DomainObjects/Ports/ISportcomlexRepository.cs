using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Sportcomplex.DomainObjects.Ports
{
    public interface IReadOnlySportcomplexRepository
    {
        Task<Sportcomplex> GetRoute(long id);

        Task<IEnumerable<Sportcomplex>> GetAllRoutes();

        Task<IEnumerable<Sportcomplex>> QueryRoutes(ICriteria<Sportcomplex> criteria);

    }

    public interface ISportcomlexRepository
    {
        Task AddRoute(Sportcomplex Sportcomplex);

        Task RemoveRoute(Sportcomplex Sportcomplex);

        Task UpdateRoute(Sportcomplex Sportcomplex);
    }
}
