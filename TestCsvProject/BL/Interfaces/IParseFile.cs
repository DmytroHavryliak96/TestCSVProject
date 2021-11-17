using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCsvProject.BL.Interfaces
{
    public interface IParseCsvFile<T>
    {
        IEnumerable<T> Parse(string filepath);
    }
}
