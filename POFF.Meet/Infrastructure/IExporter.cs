using POFF.Meet.View.Model;
using System.Collections.Generic;

namespace POFF.Meet.Infrastructure
{
    public interface IExporter
    {
        void Export(Tournament tournament);
        void Export(Tournament tournament, IEnumerable<int> matchNumbers);
    }
}