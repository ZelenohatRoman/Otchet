using RPTSobj.ApplicationServices.Ports.Cache;
using RPTSobj.DomainObjects;
using RPTSobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RPTSobj.InfrastructureServices.Repositories
{
    public class NetworkRPTSobjRepository : NetworkRepositoryBase, IReadOnlyRPTSobjRepository
    {
        private readonly IDomainObjectsCache<rptsobj> _rptsobjCache;

        public NetworkRPTSobjRepository(string host, ushort port, bool useTls, IDomainObjectsCache<rptsobj> rptsobjCache)
            : base(host, port, useTls)
            => _rptsobjCache = rptsobjCache;

        public async Task<rptsobj> GetRPTSobj(long id)
            => CacheAndReturn(await ExecuteHttpRequest<rptsobj>($"rptsobjs/{id}"));

        public async Task<IEnumerable<rptsobj>> GetAllRPTSobjs()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<rptsobj>>($"rptsobjs"), allObjects: true);

        public async Task<IEnumerable<rptsobj>> QueryRPTSobjs(ICriteria<rptsobj> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<rptsobj>>($"rptsobjs"), allObjects: true)
               .Where(criteria.Filter.Compile());


        private IEnumerable<rptsobj> CacheAndReturn(IEnumerable<rptsobj> rptsobjs, bool allObjects = false)
        {
            if (allObjects)
            {
                _rptsobjCache.ClearCache();
            }
            _rptsobjCache.UpdateObjects(rptsobjs, DateTime.Now.AddDays(1), allObjects);
            return rptsobjs;
        }

        private rptsobj CacheAndReturn(rptsobj rptsobj)
        {
            _rptsobjCache.UpdateObject(rptsobj, DateTime.Now.AddDays(1));
            return rptsobj;
        }
    }
}
