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


    public class ArrayQueue<T>
    {
        private T[] Entries;
        public int Capacity => Entries.Length;
        public int Size => End - Start;
        private int Start { get; set; }
        private int End { get; set; }

        public ArrayQueue()
        { 
            Entries = new T[4];
            Start = 0;
            End = 0;
        }

        private void Resize()
        {
            if (End >= Capacity)
            {
                T[] newArray = new T[Capacity << (Size > Capacity - 1 ? 1 : 0)];
                for (int i = 0; i < Size; i++)
                {
                    newArray[i] = Entries[i+Start];
                }
                Entries = newArray;
                End = Size;
                Start = 0;
                //Console.WriteLine("Grew and shifted!");
            }
            if (Size < Capacity >> 1)
            {
                T[] newArray = new T[Capacity >> 1];
                for (int i = 0; i < Size; i++)
                {
                    newArray[i] = Entries[i + Start];
                }
                Entries = newArray;
                End = Size;
                Start = 0;
                //Console.WriteLine("Shrunk and shifted!");
            }
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



    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayQueue<int> arrqueueTest = new();
            for (int i = 0; i < 100; i++)
            { 
                arrqueueTest.Enqueue(i);
            }
            arrqueueTest.Dequeue();
            while (arrqueueTest.Size > 0)
            { 
                Console.WriteLine(arrqueueTest.Dequeue());
            }
        }
    }
}
