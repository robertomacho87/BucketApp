using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketApp
{
    public class BucketFactory
    {
        public Bucket Create(int content, int capacity)
        {
            if(content < 0)
            {
                throw new ArgumentNullException(nameof(content));
            } else if (capacity < 0)
            {
                throw new ArgumentNullException(nameof(capacity));
            }
            return new Bucket(content, capacity);
        }
    }
}
