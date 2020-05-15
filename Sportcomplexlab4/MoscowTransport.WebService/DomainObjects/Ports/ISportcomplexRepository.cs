using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Sportcomplex.DomainObjects.Ports
{
    public interface IReadOnlyRouteRepository
    {
        Task<Sportcomplex> GetRoute(long id);

        Task<IEnumerable<Sportcomplex>> GetAllRoutes();

        Task<IEnumerable<Sportcomplex>> QueryRoutes(ICriteria<Sportcomplex> criteria);

    }

    public interface ISportcomplexRepository
    {
        Task AddRoute(Sportcomplex route);

        Task RemoveRoute(Sportcomplex route);

        Task UpdateRoute(Sportcomplex route);
    }
}
