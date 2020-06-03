using RPTSobj.DomainObjects;
using RPTSobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RPTSobj.ApplicationServices.GetMetroLineListUseCase
{
    public class MetroLineCriteria : ICriteria<rptsobj>
    {
        public string MetroLine { get; }

        public MetroLineCriteria (string metroline)
            => MetroLine = metroline;

        public Expression<Func<rptsobj, bool>> Filter
            => (b => b.MetroStation == MetroLine);
    }
}
