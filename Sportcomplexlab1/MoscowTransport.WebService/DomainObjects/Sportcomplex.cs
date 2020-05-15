using System;
using System.Collections.Generic;
using System.Text;

namespace Sportcomlex.DomainObjects
{
    public class Sportcomplex : DomainObject
    {
        public string Legitiveaddress { get; set; }

        public string Name { get; set; }

        public string FIO { get; set; }

        public string Rang { get; set; }
    }
}
