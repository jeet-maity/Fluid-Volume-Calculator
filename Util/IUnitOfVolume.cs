using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public interface IUnitOfVolume
    {
        decimal Value { get; set; }
        VolumeUnit Unit { get; set; }
    }
}
