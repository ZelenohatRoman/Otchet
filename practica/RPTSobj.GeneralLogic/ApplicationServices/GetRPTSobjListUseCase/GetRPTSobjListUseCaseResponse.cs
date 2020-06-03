using RPTSobj.DomainObjects;
using RPTSobj.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPTSobj.ApplicationServices.GetMetroLineListUseCase
{
    public class GetRPTSobjListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<rptsobj> RPTSobjs { get; }

        public GetRPTSobjListUseCaseResponse(IEnumerable<rptsobj> rptsobjs) => RPTSobjs = rptsobjs;
    }
}
