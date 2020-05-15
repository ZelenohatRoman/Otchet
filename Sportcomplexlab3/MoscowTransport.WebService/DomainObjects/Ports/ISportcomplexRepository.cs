using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Sportcomplex.DomainObjects.Ports
{
    public interface IReadOnlySportcomplexRepository
    {
        Task<Sportcomplex> GetSportcomplex(long id);

        Task<IEnumerable<Sportcomplex>> GetAllSportcomplexs();

        Task<IEnumerable<Sportcomplex>> QuerySportcomplexs(ICriteria<Sportcomplex> criteria);

    }

    public interface ISportcomplexRepository
    {
        Task AddSportcomplex(Sportcomplex Sportcomplex);

        Task RemoveSportcomplex(Sportcomplex Sportcomplex);

        Task UpdateSportcomplex(Sportcomplex Sportcomplex);
    }
}
