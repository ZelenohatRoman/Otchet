using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Sportcomlex.DomainObjects.Ports
{
    public interface IReadOnlySportcomplexRepository
    {
        Task<Sportcomplex> GetSportcomplex(long id);

        Task<IEnumerable<Sportcomplex>> GetAllSportcomlex();

        Task<IEnumerable<Sportcomplex>> QuerySportcomplex(ICriteria<Sportcomplex> criteria);

    }

    public interface ISportcomplexRepository
    {
        Task AddSportcomplex(Sportcomplex Sportcomlex);

        Task RemoveSportcomlex(Sportcomplex Sportcomlex);

        Task UpdateSportcomplex(Sportcomplex Sportcomlex);
    }
}
