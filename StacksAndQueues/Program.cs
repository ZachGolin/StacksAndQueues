using System.Diagnostics;
using System.Linq.Expressions;

namespace StacksAndQueues
{


    public class Stack<T>
    {
        public int Count => data.Count;
        private readonly LinkedList<T> data;

        public Stack()
        {
            data = new();
        }

        public void Push(T value)
        { 
            data.AddFirst(value);
        }
        public T? Pop()
        {
            LinkedListNode<T>? popped = data.First;
            data.RemoveFirst();
            if (popped != null) { return popped.Value; }
            else { return default; }
        }
        public T? Peek()
        {
            LinkedListNode<T>? peeked = data.First;
            if (peeked != null) { return peeked.Value; }
            else { return default; }
        }
        public void Clear()
        { 
            data.Clear();
        }
        public bool IsEmpty()
        { 
            return data.Count == 0;
        }
    }


    public class Queue<T>
    {
        public int Count => data.Count;
        private readonly LinkedList<T> data;

        public Queue()
        { 
            data = new();
        }

        public void Enqueue(T value)
        {
            data.AddFirst(value);
        }
        public T? Dequeue()
        {
            LinkedListNode<T>? dequeued = data.Last;
            data.RemoveLast();
            if (dequeued != null) { return dequeued.Value; }
            else { return default; }
        }
        public T? Peek()
        {
            LinkedListNode<T>? end = data.Last;
            if (end != null) { return end.Value; }
            else { return default; }
        }
        public bool IsEmpty()
        {
            return data.Count == 0;
        }
        public void Clear()
        { 
            data.Clear();
        }
    }


    public class ArrayStack<T>
    {
        
    } //do later


    public class MyPersonalArrayQueue<T>
    {
        private T[] Entries;
        public int Capacity => Entries.Length;
        public int Size => End - Start;
        private int Start { get; set; }
        private int End { get; set; }

        public MyPersonalArrayQueue()
        { 
            Entries = new T[4];
            Start = 0;
            End = 0;
        }

        private void Resize()
        {
            bool shouldGrow = Size >= Capacity;
            bool shouldShrink = Size < Capacity >> 1;
            //funny gross boolean math
            int newCapacity = (int)(Capacity * ((shouldGrow ? 2 : 1) * (shouldShrink ? 0.5 : 1))); //apparently 1.5 -> int gives lagre value? test later pls


            if (shouldShrink)
            {
                Debug.WriteLine("Shrunk and shifted!");
            }
            else if (shouldGrow)
            {
                Debug.WriteLine("Grew and shifted!");
            }


            T[] newArray = new T[newCapacity];
            for (int i = 0; i < Size; i++)
            {
                newArray[i] = Entries[i + Start];
            }
            Entries = newArray;
            End = Size;
            Start = 0;
        }

        public void Enqueue(T value)
        {
            Entries[End] = value;
            End++;
            Resize();
        }
        public T? Dequeue()
        {
            Start++;
            T value = Entries[Start - 1];
            Resize();
            return value;
        }
        public T? Peek()
        {
            return Entries[Start];
        }
        public bool IsEmpty()
        { 
            return Start == End;
        }
        public void Clear()
        {
            Start = 0;
            End = 0;
            Entries = new T[4];
        }
    }


    public class ArrayQueue<T>
    {
        private T[] Entries;
        public int Capacity => Entries.Length;
        public int Size { get; set; }
        private int Start { get; set; }
        private int End { get; set; }

        public ArrayQueue()
        {
            Entries = new T[4];
            Start = 0;
            End = 0;
            Size = 0;
        }

        private void Resize()
        {
            if (Size >= Capacity)
            {
                T[] newArray = new T[Capacity * 2];
                int j = Start;
                for (int i = 0; i < Capacity; i++)
                {
                    newArray[i] = Entries[j];
                    j = j < Capacity - 1 ? j + 1 : 0;
                }
                Entries = newArray;
                End = Size;
                Start = 0;
                //Debug.WriteLine("Grew!");
            }
        }

        public void Enqueue(T value)
        {
            Entries[End] = value;
            End++;
            if (End > Capacity - 1) { End = 0; }
            Size++;
            Resize();
        }
        public T? Dequeue()
        {
            Start++;
            T value = Entries[Start - 1];
            if (Start > Capacity - 1) { Start = 0; }
            Size--;
            Resize();
            return value;
        }
        public T? Peek()
        {
            return Entries[Start];
        }
        public bool IsEmpty()
        {
            return Size == 0;
        }
        public void Clear()
        {
            Start = 0;
            End = 0;
            Size = 0;
            Entries = new T[4];
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayQueue<int> arrqueueTest = new();
            for (int i = 0; i < 12; i++)
            {
                arrqueueTest.Enqueue(i);
            }
            arrqueueTest.Dequeue();
            arrqueueTest.Dequeue();
            arrqueueTest.Dequeue();
            arrqueueTest.Dequeue();
            for (int i = 0; i < 2; i++)
            {
                arrqueueTest.Enqueue(i+14);
            }
            while (arrqueueTest.Size > 0)
            { 
                Console.WriteLine(arrqueueTest.Dequeue());
            }
        }
    }
}
