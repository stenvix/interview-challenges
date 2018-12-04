using System;
using System.Linq;

namespace DataStructures.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------ List stack created");
            var listStack = new ListStack();
            listStack.Push(30);
            listStack.Push(50);
            listStack.Push(5);

            listStack.Pop();
            listStack.Pop();
            listStack.Pop();
            listStack.Pop();

            Console.WriteLine("------------ Array stack created");
            var arrayStack = new ArrayStack(3);
            arrayStack.Pop();
            arrayStack.Push(5);
            arrayStack.Push(51);
            arrayStack.Push(123);
            arrayStack.Push(3);
            arrayStack.Pop();
            arrayStack.Pop();
            arrayStack.Pop();
            arrayStack.Pop();

            Console.WriteLine("------------ Reverse string using stack");
            var lorem = "Stack | Set 3 (Reverse a string using stack) | GeeksforGeeks";
            Console.WriteLine($"Input string '{lorem}'");
            var reverseStringStack = new ArrayStack(lorem.Length);
            var charArray = lorem.ToCharArray();
            foreach (var currentChar in charArray)
            {
                reverseStringStack.Push(currentChar);
            }

            int index = 0;
            char[] resultArray = new char[lorem.Length];
            while (index != lorem.Length)
            {
                var value = reverseStringStack.Pop();
                resultArray[index] = (char)value;
                index++;
            }
            Console.WriteLine($"Output from stack  '{string.Join("", resultArray)}'");
            Console.WriteLine($"Output from system '{string.Join("", charArray.Reverse())}'");
            Console.ReadKey();
        }
    }
}
