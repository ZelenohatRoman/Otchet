using RPTSobj.ApplicationServices.Ports.Cache;
using RPTSobj.DomainObjects;
using RPTSobj.DomainObjects.Ports;
using RPTSobj.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RPTSobj.ApplicationServices.Repositories
{
    public class CachedReadOnlyRPTSobjRepository : ReadOnlyRPTSobjRepositoryDecorator
    {
        private readonly IDomainObjectsCache<rptsobj> _rptsobjsCache;

        public CachedReadOnlyRPTSobjRepository(IReadOnlyRPTSobjRepository rptsobjRepository, 
                                             IDomainObjectsCache<rptsobj> rptsobjsCache)
            : base(rptsobjRepository)
            => _rptsobjsCache = rptsobjsCache;

        public async override Task<rptsobj> GetRPTSobj(long id)
            => _rptsobjsCache.GetObject(id) ?? await base.GetRPTSobj(id);

        public async override Task<IEnumerable<rptsobj>> GetAllRPTSobjs()
            => _rptsobjsCache.GetObjects() ?? await base.GetAllRPTSobjs();

        public async override Task<IEnumerable<rptsobj>> QueryRPTSobjs(ICriteria<rptsobj> criteria)
            => _rptsobjsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryRPTSobjs(criteria);

    }
}
