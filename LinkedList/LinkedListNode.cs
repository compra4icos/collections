using System;

namespace LinkedList
{
    public sealed class LinkedListNode<T>
    {
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }
        public T Value { get; set; }

        public LinkedListNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            Value = value;
        }
        ~LinkedListNode() { }


    }
}
