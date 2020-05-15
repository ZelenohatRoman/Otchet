using System;
using System.Collections.Generic;
using System.Text;

namespace Sportcomplex.ApplicationServices.Ports
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);
    }
}
