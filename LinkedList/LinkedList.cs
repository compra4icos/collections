using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T> First { get; private set; }
        public LinkedListNode<T> Last { get; private set; }
        public int Count { get; private set; }

        public LinkedList() { }
        ~LinkedList() { }

        public void AddFirst(T value)
        {
            CheckArgumentForNull<T>(value);
            var item = new LinkedListNode<T>(value);
            if (First == null)
            {
                Last = item;
            }
            else
            {
                First.Previous = item;
                item.Next = First;
            }
            First = item;
            ++Count;
        }
        public void AddLast(T value)
        {
            CheckArgumentForNull<T>(value);
            var item = new LinkedListNode<T>(value);

            if (First == null)
            {
                First = item;
            }
            else
            {
                Last.Next = item;
                item.Previous = Last;
            }
            Last = item;
            ++Count;
        }

        public T PickFirst()
        {
            CheckArgumentForNull<LinkedListNode<T>>(First);
            return First.Value;
        }
        public T PickLast()
        {
            CheckArgumentForNull<LinkedListNode<T>>(Last);
            return Last.Value;
        }

        public T PopFirst()
        {
            T res = PickFirst();
            First = First.Next;
            --Count;
            return res;
        }
        public T PopLast()
        {
            T res = PickLast();
            Last.Previous.Next = null;
            Last = Last.Previous;
            --Count;
            return res;
        }

        public LinkedListNode<T> Find(T value)
        {
            var current = First;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Next;
            }
            throw new KeyNotFoundException();
        }

        public void AddAfter(LinkedListNode<T> node, T value)
        {
            CheckArgumentForNull<T>(value);
            var item = new LinkedListNode<T>(value);
            if (node.Next == null)
            {
                AddLast(value);
            }
            else
            {
                var temp = node.Next;
                node.Next = item;
                item.Next = temp;
                temp.Previous = item;
                item.Previous = node;
            }
            ++Count;
        }
        public void AddBefore(LinkedListNode<T> node, T value)
        {
            CheckArgumentForNull<T>(value);
            var item = new LinkedListNode<T>(value);
            if (node.Previous.Previous == null)
            {
                AddFirst(value);
            }
            else
            {
                var temp = node.Previous;
                node.Previous = item;
                item.Previous = temp;
                temp.Next = item;
                item.Next = node;
            }
            ++Count;
        }

        public void Sort(bool Ascending = true)
        {
            Sort(0, Count, Ascending);
        }
        private void Sort(int startIndex, int endIndex, bool Ascending = true)
        {
            bool startingIndexGreater;
            if (Ascending)
            {
                startingIndexGreater = CompareTo(this[startIndex], this[endIndex]) > 0;
            }
            else
            {
                startingIndexGreater = CompareTo(this[startIndex], this[endIndex]) < 0;
            }
            if (startingIndexGreater)
            {
                var temp = this[startIndex];
                this[startIndex] = this[endIndex];
                this[endIndex] = temp;
            }

            if (endIndex - startIndex > 1)
            {
                var len = (endIndex - startIndex + 1) / 3;
                Sort(startIndex, endIndex - len, Ascending);
                Sort(startIndex + len, endIndex, Ascending);
                Sort(startIndex, endIndex - len, Ascending);
            }
        }


        public int CompareTo(T first, T second)
        {
            return Convert.ToInt32(first) - Convert.ToInt32(second);
        }

        private bool Equals(T first, T second)
        {
            return Convert.ToInt32(first) - Convert.ToInt32(second) == 0 ? true : false;
        }


        public T this[int index]
        {
            get
            {
                LinkedListNode<T> current;
                if (index <= Count / 2)
                {
                    current = First;
                    for (int item = 0; item < index; ++item)
                    {
                        current = current.Next;
                    }
                    return current.Value;
                }
                else
                {
                    current = Last;
                    for (int item = Count - 1; item > index; --item)
                    {
                        current = current.Previous;
                    }
                    return current.Value;
                }
            }
            set
            {
                LinkedListNode<T> current;
                if (index <= Count / 2)
                {
                    current = First;
                    for (int item = 0; item < index; ++item)
                    {
                        current = current.Next;
                    }
                }
                else
                {
                    current = Last;
                    for (int item = Count - 1; item > index; --item)
                    {
                        current = current.Previous;
                    }
                }
                current.Value = value;
            }
        }

        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }



        private void CheckArgumentForNull<TypeArg>(TypeArg arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(nameof(Last));
            }
        }



        public IEnumerator<T> GetEnumerator()
        {
            var current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
