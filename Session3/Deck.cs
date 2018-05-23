using System;
using System.Collections.Generic;

namespace csharp.Session3
{
    public class Deck<T> where T : class
    {
        private IList<T> Items { get; set; }

        public T this[int index]
        {
            get { return Items[index]; }
        }

        public void Add(T item) {
            this.Items.Add(item);
        }
        
        public Deck()
        {
            this.Items = new List<T>();
        }
    }
}
