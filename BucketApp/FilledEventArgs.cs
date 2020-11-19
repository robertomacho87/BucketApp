using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketApp
{
    public class FilledEventArgs
    {
        public FilledEventArgs()
        {
        }

        public FilledEventArgs(int overflow = 0, string text = "FULL BUCKET")
        {
            this.Text = text;
            this.Overflow = overflow;
        }
        public string Text { get; }

        public int Overflow { get; }

    }
}

