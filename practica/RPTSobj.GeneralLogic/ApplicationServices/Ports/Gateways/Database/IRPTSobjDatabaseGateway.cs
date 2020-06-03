using RPTSobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RPTSobj.ApplicationServices.Ports.Gateways.Database
{
    public interface IRPTSobjDatabaseGateway
    {
        Task AddRPTSobj(rptsobj rptsobj);

        Task RemoveRPTSobj(rptsobj rptsobj);

        Task UpdateRPTSobj(rptsobj rptsobj);

        Task<rptsobj> GetRPTSobj(long id);

        Task<IEnumerable<rptsobj>> GetAllRPTSobjs();

        Task<IEnumerable<rptsobj>> QueryRPTSobjs(Expression<Func<rptsobj, bool>> filter);

    }
}
