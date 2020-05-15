using Sportcomplex.DomainObjects;
using Sportcomplex.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sportcomplex.ApplicationServices.Repositories
{
    public class InMemorySportcomplexRepository : IReadOnlyRouteRepository,
                                           ISportcomplexRepository 
    {
        private readonly List<DomainObjects.Sportcomplex> _routes = new List<DomainObjects.Sportcomplex>();

        public InMemorySportcomplexRepository(IEnumerable<DomainObjects.Sportcomplex> routes = null)
        {
            if (routes != null)
            {
                _routes.AddRange(routes);
            }
        }

        public Task AddRoute(DomainObjects.Sportcomplex route)
        {
            _routes.Add(route);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<DomainObjects.Sportcomplex>> GetAllRoutes()
        {
            return Task.FromResult(_routes.AsEnumerable());
        }

        public Task<DomainObjects.Sportcomplex> GetRoute(long id)
        {
            return Task.FromResult(_routes.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<DomainObjects.Sportcomplex>> QueryRoutes(ICriteria<DomainObjects.Sportcomplex> criteria)
        {
            return Task.FromResult(_routes.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveRoute(DomainObjects.Sportcomplex route)
        {
            _routes.Remove(route);
            return Task.CompletedTask;
        }

        public Task UpdateRoute(DomainObjects.Sportcomplex route)
        {
            var foundRoute = GetRoute(route.Id).Result;
            if (foundRoute == null)
            {
                AddRoute(route);
            }
            else
            {
                if (foundRoute != route)
                {
                    _routes.Remove(foundRoute);
                    _routes.Add(route);
                }
            }
            return Task.CompletedTask;
        }
    }
}
