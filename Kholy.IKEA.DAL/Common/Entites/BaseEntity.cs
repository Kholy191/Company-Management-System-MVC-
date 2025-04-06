using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kholy.IKEA.DAL.Common.Entites
{
    public class BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public TKey ID { get; set; }

        /*Audit Fields*/
    }
}
