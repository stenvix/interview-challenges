using System;
using System.Collections.Generic;
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

            Console.WriteLine("------------ Implement two stacks in array");
            TwoStacks();
            Console.WriteLine("------------ The Stock Span Problem");
            TheStockSpanProblem();
            Console.WriteLine("------------ Next Greater Element");
            NextGreaterElement();
            Console.WriteLine("------------ Reverse a stack using recursion");
            ReverseStackUsingRecursion();
            Console.WriteLine("------------ Length of the longest valid substring");
            FindMaxValidSubstring();
            Console.WriteLine("------------ Check for balanced parentheses in an expression");
            CheckForBalancedParentheses();
            Console.WriteLine("------------ Implement a Stack using Single Queue ");
            QueueStackCheck();
            Console.ReadKey();
        }

        private static void TwoStacks()
        {
            var twoStack = new TwoStacks(3);
            twoStack.Push1(1);
            twoStack.Push1(5);
            twoStack.Push2(12);
            twoStack.Push2(7);
            twoStack.Push1(4);
            Console.WriteLine($"Stack 1: Pop = {twoStack.Pop1()}");
            Console.WriteLine($"Stack 2: Pop = {twoStack.Pop2()}");
        }

        private static void TheStockSpanProblem()
        {
            var prices = new[] { 100, 80, 60, 70, 60, 75, 86 };
            Console.Write($"Input array=");
            PrintArray(prices);
            var spans = new int[prices.Length];
            spans[0] = 0;

            var stack = new Stack<int>(prices.Length);
            stack.Push(0);
            for (int i = 0; i < prices.Length; i++)
            {
                while (stack.Count != 0 && prices[stack.Peek()] <= prices[i])
                {
                    stack.Pop();
                }

                spans[i] = stack.Count == 0 ? 1 : i - stack.Peek();
                stack.Push(i);
            }

            PrintArray(spans);
        }

        private static void NextGreaterElement()
        {
            //var input = new[] { 4, 5, 2, 25, 54, 11, 13, 1 };    
            var input = new[] { 13, 7, 6, 12 };
            var result = new int[input.Length];
            var valueStack = new Stack<int>(input.Length);

            Console.Write("Input array=");
            PrintArray(input);

            result[input.Length - 1] = -1;
            valueStack.Push(input[input.Length - 1]);

            for (int i = input.Length - 2; i >= 0; i--)
            {
                while (valueStack.Count != 0 && input[i] >= valueStack.Peek())
                {
                    valueStack.Pop();
                }

                if (valueStack.Count == 0)
                {
                    result[i] = -1;
                }
                else
                {
                    result[i] = valueStack.Peek();
                }
                valueStack.Push(input[i]);
            }
            Console.Write("Output array=");
            PrintArray(result);
        }


        private static void ReverseStackUsingRecursion()
        {
            var input = new int[] { 1, 2, 3, 4, 5 };
            Console.Write("Input array=");
            PrintArray(input);
            var stack = new Stack<int>(input.Length);
            foreach (var i in input.Reverse())
            {
                stack.Push(i);
            }
            Reverse(stack);
            var result = stack.ToArray();
            Console.Write("Output array=");
            PrintArray(result);
        }


        private static void Reverse(Stack<int> stack)
        {
            if (stack.Count != 0)
            {
                var temp = stack.Pop();
                Reverse(stack);
                InsertAtBottom(stack, temp);
            }
        }

        private static void InsertAtBottom(Stack<int> stack, int value)
        {
            if (stack.Count == 0)
            {
                stack.Push(value);
            }
            else
            {
                var temp = stack.Pop();
                InsertAtBottom(stack, value);
                stack.Push(temp);
            }
        }

        private static void FindMaxValidSubstring()
        {
            var input = "()()(()()()((())";
            Console.WriteLine($"Input string='{input}'");
            var stack = new Stack<int>();

            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count != 0)
                    {
                        result = Math.Max(result, i - stack.Peek());
                    }
                    else
                    {
                        stack.Push(i);
                    }
                }
            }

            Console.WriteLine($"Result={result}");
        }

        private static void CheckForBalancedParentheses()
        {
            var validInput = "[()]{}{[()()]()}";
            var invalidInput = "[(])";

            Console.WriteLine($"String '{validInput}' is correct = '{CheckBalancedParentheses(validInput)}'");
            Console.WriteLine($"String '{invalidInput}' is correct = '{CheckBalancedParentheses(invalidInput)}'");
        }

        private static bool CheckBalancedParentheses(string input)
        {
            var stack = new Stack<int>();
            var parentheses = new Dictionary<char, char>
            {
                { ']', '[' },
                {')', '(' },
                {'}' ,'{'}
            };

            for (int i = 0; i < input.Length; i++)
            {
                var current = input[i];
                if (parentheses.ContainsValue(current))
                {
                    stack.Push(i);
                }
                else
                {
                    var open = stack.Pop();
                    if (parentheses[input[i]] != input[open])
                    {
                        return false;
                    }
                }
            }

            if (stack.Count == 0)
            {
                return true;
            }

            return false;
        }

        private static void QueueStackCheck()
        {
            var input = new[] { 4, 5, 7, 9, 12, 18 };
            var stack = new QueueStack(input.Length);
            for (int i = 0; i < input.Length / 2; i++)
            {
                var value = input[i];
                Console.WriteLine($"Push value='{value}'");
                stack.Push(value);
            }
            for (int i = 0; i < input.Length / 2; i++)
            {
                var value = stack.Pop();
                Console.WriteLine($"Pop value='{value}'");
            }
        }

        private static void PrintArray(int[] array)
        {
            Console.WriteLine($"[{string.Join(",", array)}]");
        }
    }
}
