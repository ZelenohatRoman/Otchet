using RPTSobj.ApplicationServices.Ports.Gateways.Database;
using RPTSobj.DomainObjects;
using RPTSobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RPTSobj.ApplicationServices.Repositories
{
    public class DbRPTSobjRepository : IReadOnlyRPTSobjRepository,
                                     IRPTSobjRepository
    {
        private readonly IRPTSobjDatabaseGateway _databaseGateway;

        public DbRPTSobjRepository(IRPTSobjDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<rptsobj> GetRPTSobj(long id)
            => await _databaseGateway.GetRPTSobj(id);

        public async Task<IEnumerable<rptsobj>> GetAllRPTSobjs()
            => await _databaseGateway.GetAllRPTSobjs();

        public async Task<IEnumerable<rptsobj>> QueryRPTSobjs(ICriteria<rptsobj> criteria)
            => await _databaseGateway.QueryRPTSobjs(criteria.Filter);

        public async Task AddRPTSobj(rptsobj rptsobj)
            => await _databaseGateway.AddRPTSobj(rptsobj);

        public async Task RemoveRPTSobj(rptsobj rptsobj)
            => await _databaseGateway.RemoveRPTSobj(rptsobj);

        public async Task UpdateRPTSobj(rptsobj rptsobj)
            => await _databaseGateway.UpdateRPTSobj(rptsobj);
    }
}
