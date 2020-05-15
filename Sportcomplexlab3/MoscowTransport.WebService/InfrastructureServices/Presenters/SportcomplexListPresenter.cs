using Sportcomplex.ApplicationServices.GetRouteListUseCase;
using System.Net;
using Newtonsoft.Json;
using Sportcomplex.ApplicationServices.Ports;

namespace Sportcomplex.InfrastructureServices.Presenters
{
    public class SportcomplexListPresenter : IOutputPort<GetSportcomplexListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public SportcomplexListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetSportcomplexListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Routes) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
