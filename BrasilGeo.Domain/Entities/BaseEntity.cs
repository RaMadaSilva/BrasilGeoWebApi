using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasilGeo.Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; private set; }
    }
}
