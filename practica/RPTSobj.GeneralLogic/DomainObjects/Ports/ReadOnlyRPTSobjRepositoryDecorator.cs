using RPTSobj.DomainObjects;
using RPTSobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RPTSobj.DomainObjects.Repositories
{
    public abstract class ReadOnlyRPTSobjRepositoryDecorator : IReadOnlyRPTSobjRepository
    {
        private readonly IReadOnlyRPTSobjRepository _rptsobjRepository;

        public ReadOnlyRPTSobjRepositoryDecorator(IReadOnlyRPTSobjRepository rptsobjRepository)
        {
            _rptsobjRepository = rptsobjRepository;
        }

        public virtual async Task<IEnumerable<rptsobj>> GetAllRPTSobjs()
        {
            return await _rptsobjRepository?.GetAllRPTSobjs();
        }

        public virtual async Task<rptsobj> GetRPTSobj(long id)
        {
            return await _rptsobjRepository?.GetRPTSobj(id);
        }

        public virtual async Task<IEnumerable<rptsobj>> QueryRPTSobjs(ICriteria<rptsobj> criteria)
        {
            return await _rptsobjRepository?.QueryRPTSobjs(criteria);
        }
    }
}
