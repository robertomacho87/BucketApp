using System;

namespace BucketApp
{
    public class Container
    {
        public int Capacity { get; set; }

        public int Content
        {
            get { return content; }
            set { if (value > 0) content = value; }
        }
        private int content;

        public bool Overflowing = true;

        //public delegate void FilledEventHandler(object sender, FilledEventArgs e);

        public event EventHandler<FilledEventArgs> Full;

        public Container(int content = 0, int capacity = 100)
        {
            this.Capacity = capacity;
            this.Content = content;
        }

        public virtual void RaiseFilledEvent(int overflow = 0)
        {
            Full?.Invoke(this, new FilledEventArgs(overflow: overflow));
        }

        public virtual void Fill(int ammount)
        {
            if (ammount < 1) ammount = 0;

            var overflow = 0;

            if ((Content + ammount) >= Capacity)
            {
                overflow = Content + ammount - Capacity;
                RaiseFilledEvent(overflow);
            }
            
            Content += ammount - overflow;
        }

        public virtual void Fill<T>(T input) where T : Container
        {
            Fill(input.Content);
        }

        public virtual void Empty()
        {
            this.Content = 0;
        }

        public virtual void Empty(int amount)
        {
            if (amount >= Content)
            {
                Content = 0;
            } else
            {
                this.Content -= amount;
            }
        }

    }
}
