﻿using System;

namespace BucketApp
{
    public class Container
    {
        public int Capacity { get; set; }

        public int Content { get; set; } 

        bool Overflowing = true;

        public delegate void FilledEventHandler(object sender, FilledEventArgs e);

        public event FilledEventHandler Full;

        public Container(int content, int capacity = 100)
        {
            this.Capacity = capacity;
            this.Content = content;
        }

        public Container()
        {

        }

        public virtual void RaiseFilledEvent(int overflow = 0)
        {
            Full?.Invoke(this, new FilledEventArgs(overflow: overflow));
        }

        public virtual void Fill(int ammount)
        {
            var overflow = Content + ammount - Capacity;

            if ((Content + ammount) >= Capacity)
            {
                RaiseFilledEvent(overflow);
            }
            if(Overflowing)
            {
                Content += ammount;
            } else 
            {
                Content += ammount - overflow;
            }
            
            Console.WriteLine(Capacity);
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
            if (amount >= Content) Content = 0;
            this.Content -= amount;
        }

    }
}
