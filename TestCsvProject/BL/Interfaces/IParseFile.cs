using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestCsvProject.BL.Interfaces
{
    public interface IParseCsvFile<T>
    {
        IEnumerable<T> Parse(HttpPostedFileBase file);
    }
}
