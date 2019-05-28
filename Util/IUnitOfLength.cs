using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public interface IUnitOfLength
    {
        decimal Value { get; set; }

        LengthUnit Unit { get; set; }
    }
}
