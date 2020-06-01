using RPTSobj.DomainObjects;
using RPTSobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RPTSobj.ApplicationServices.Repositories
{
    public class InMemoryRPTSobjRepository : IReadOnlyRPTSobjRepository,
                                           IRPTSobjRepository 
    {
        private readonly List<rptsobj> _rptsobjs = new List<rptsobj>();

        public InMemoryRPTSobjRepository(IEnumerable<rptsobj> rptsobjs = null)
        {
            if (rptsobjs != null)
            {
                _rptsobjs.AddRange(rptsobjs);
            }
        }

        public Task AddRPTSobj(rptsobj rptsobj)
        {
            _rptsobjs.Add(rptsobj);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<rptsobj>> GetAllRPTSobjs()
        {
            return Task.FromResult(_rptsobjs.AsEnumerable());
        }

        public Task<rptsobj> GetRPTSobj(long id)
        {
            return Task.FromResult(_rptsobjs.Where(pn => pn.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<rptsobj>> QueryRPTSobjs(ICriteria<rptsobj> criteria)
        {
            return Task.FromResult(_rptsobjs.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveRPTSobj(rptsobj rptsobj)
        {
            _rptsobjs.Remove(rptsobj);
            return Task.CompletedTask;
        }

        public Task UpdateRPTSobj(rptsobj rptsobj)
        {
            var foundRPTSobj = GetRPTSobj(rptsobj.Id).Result;
            if (foundRPTSobj == null)
            {
                AddRPTSobj(rptsobj);
            }
            else
            {
                if (foundRPTSobj != rptsobj)
                {
                    _rptsobjs.Remove(foundRPTSobj);
                    _rptsobjs.Add(rptsobj);
                }
            }
            return Task.CompletedTask;
        }
    }
}
