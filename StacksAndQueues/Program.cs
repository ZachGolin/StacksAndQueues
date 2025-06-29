namespace StacksAndQueues
{


    public class Stack<T>
    {
        public int Count { get; private set; }
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







    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
