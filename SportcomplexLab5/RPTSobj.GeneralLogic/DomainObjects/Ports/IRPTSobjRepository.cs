using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace RPTSobj.DomainObjects.Ports
{
    public interface IReadOnlyRPTSobjRepository
    {
        Task<rptsobj> GetRPTSobj(long id);

        Task<IEnumerable<rptsobj>> GetAllRPTSobjs();

        Task<IEnumerable<rptsobj>> QueryRPTSobjs(ICriteria<rptsobj> criteria);

    }

    public interface IRPTSobjRepository
    {
        Task AddRPTSobj(rptsobj rptsobj);

        Task RemoveRPTSobj(rptsobj rptsobj);

        Task UpdateRPTSobj(rptsobj rptsobj);
    }
}
