using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.Common.Dtos.Interfaces
{
    public interface ITrackableDto
    {
        TimeSpan ElapsedTime { get; set; }
    }
}
