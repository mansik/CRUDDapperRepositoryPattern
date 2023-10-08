using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDapperRepositoryPattern.Models
{
    internal enum EntityState
    {
        Unchanged,
        Added,
        Changed,
        Deleted
    }
}
