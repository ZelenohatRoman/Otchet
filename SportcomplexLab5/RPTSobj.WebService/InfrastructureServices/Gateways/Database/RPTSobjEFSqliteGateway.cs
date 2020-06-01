using RPTSobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using RPTSobj.ApplicationServices.Ports.Gateways.Database;

namespace RPTSobj.InfrastructureServices.Gateways.Database
{
    public class RPTSobjEFSqliteGateway : IRPTSobjDatabaseGateway
    {
        private readonly RPTSobjContext _rptsobjContext;

        public RPTSobjEFSqliteGateway(RPTSobjContext RPTSobjContext)
            => _rptsobjContext = RPTSobjContext;

        public async Task<rptsobj> GetRPTSobj(long id)
           => await _rptsobjContext.RPTSobjs.Where(b => b.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<rptsobj>> GetAllRPTSobjs()
            => await _rptsobjContext.RPTSobjs.ToListAsync();
          
        public async Task<IEnumerable<rptsobj>> QueryRPTSobjs(Expression<Func<rptsobj, bool>> filter)
            => await _rptsobjContext.RPTSobjs.Where(filter).ToListAsync();

        public async Task AddRPTSobj(rptsobj rptsobj)
        {
            _rptsobjContext.RPTSobjs.Add(rptsobj);
            await _rptsobjContext.SaveChangesAsync();
        }

        public async Task UpdateRPTSobj(rptsobj rptsobj)
        {
            _rptsobjContext.Entry(rptsobj).State = EntityState.Modified;
            await _rptsobjContext.SaveChangesAsync();
        }

        public async Task RemoveRPTSobj(rptsobj rptsobj)
        {
            _rptsobjContext.RPTSobjs.Remove(rptsobj);
            await _rptsobjContext.SaveChangesAsync();
        }

    }
}
