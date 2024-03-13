using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record VehicleTypeDto
    {
        public int Id { get; init; }
        public string TypeName { get; init; }
    }
}
