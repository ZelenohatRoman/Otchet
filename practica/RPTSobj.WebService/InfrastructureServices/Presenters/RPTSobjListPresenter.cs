using RPTSobj.ApplicationServices.GetMetroLineListUseCase;
using System.Net;
using Newtonsoft.Json;
using RPTSobj.ApplicationServices.Ports;

namespace RPTSobj.InfrastructureServices.Presenters
{
    public class RPTSobjListPresenter : IOutputPort<GetRPTSobjListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RPTSobjListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetRPTSobjListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.RPTSobjs) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
