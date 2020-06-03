using RPTSobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using RPTSobj.ApplicationServices.GetMetroLineListUseCase;
using System.Linq.Expressions;
using RPTSobj.ApplicationServices.Ports;
using RPTSobj.DomainObjects.Ports;
using RPTSobj.ApplicationServices.Repositories;

namespace RPTSobj.WebService.Core.Tests
{
    public class GetRPTSobjListUseCaseTest
    {
        private InMemoryRPTSobjRepository CreateRPTSobjRepository()
        {
            var repo = new InMemoryRPTSobjRepository(new List<rptsobj> {
                new rptsobj { Id = 1, MetroStation = "генеральный директор", Name = "УЧРЕЖДЕНИЕ «МОСКОВСКИЙ ФИЗКУЛЬТУРНО-СПОРТИВНЫЙ КЛУБ «ЮНЫЙ ДИНАМОВЕЦ»"},
                new rptsobj { Id = 2, MetroStation = "президент", Name = "РЕГИОНАЛЬНАЯ ОБЩЕСТВЕННАЯ ОРГАНИЗАЦИЯ «ФЕДЕРАЦИЯ СКЕЙТБОРДИНГА»"},
                new rptsobj { Id = 3, MetroStation = "генеральный директор", Name = "Автономная некоммерческая организация «Ассоциация «Здоровая нация»"},
                new rptsobj { Id = 4, MetroStation = "исполнительный директор", Name = "АВТОНОМНАЯ НЕКОММЕРЧЕСКАЯ ОРГАНИЗАЦИЯ ПО ПРОВЕДЕНИЮ СПОРТИВНЫХ И МАССОВЫХ МЕРОПРИЯТИЙ «ВЫДВИЖЕНИЕ»"},
            });
            return repo;
        }
        [Fact]
        public void TestGetAllRPTSobj()
        {
            var useCase = new GetRPTSobjListUseCase(CreateRPTSobjRepository());
            var outputPort = new OutputPort();
                        
            Assert.True(useCase.Handle(GetRPTSobjListUseCaseRequest.CreateAllRPTSobjsRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.RPTSobjs.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.RPTSobjs.Select(mp => mp.Id));
        }

        [Fact]
        public void TestGetAllRPTSobjsFromEmptyRepository()
        {
            var useCase = new GetRPTSobjListUseCase(new InMemoryRPTSobjRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetRPTSobjListUseCaseRequest.CreateAllRPTSobjsRequest(), outputPort).Result);
            Assert.Empty(outputPort.RPTSobjs);
        }

        [Fact]
        public void TestGetRPTSobj()
        {
            var useCase = new GetRPTSobjListUseCase(CreateRPTSobjRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetRPTSobjListUseCaseRequest.CreateRPTSobjRequest(2), outputPort).Result);
            Assert.Single(outputPort.RPTSobjs, pn => 2 == pn.Id);
        }

        [Fact]
        public void TestTryGetNotExistingRPTSobj()
        {
            var useCase = new GetRPTSobjListUseCase(CreateRPTSobjRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetRPTSobjListUseCaseRequest.CreateRPTSobjRequest(999), outputPort).Result);
            Assert.Empty(outputPort.RPTSobjs);
        }
      
    }

    class OutputPort : IOutputPort<GetRPTSobjListUseCaseResponse>
    {
        public IEnumerable<rptsobj> RPTSobjs { get; private set; }

        public void Handle(GetRPTSobjListUseCaseResponse response)
        {
            RPTSobjs = response.RPTSobjs;
        }
    }
}
