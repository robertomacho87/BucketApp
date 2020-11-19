using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketApp
{
    public class Bucket : Container
    {
        public Bucket(int content = 0, int capacity = 100) : base(content, capacity)
        {
            Console.WriteLine($"Nieuwe emmer met inhoud van {content} en maximum inhoud van {capacity}");
        }
        public override string ToString()
        {
            return $"Emmer met inhoud {this.Capacity}";
        }
    }
}
