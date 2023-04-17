using System.Collections.Generic;

namespace Extensions
{
    public static class StackExtensions
    {
        public static void PushRange<T>(this Stack<T> stack, IReadOnlyList<T> items)
        {
            for (int i = 0; i < items.Count; i++) 
                stack.Push(items[i]);
        }
    }
}