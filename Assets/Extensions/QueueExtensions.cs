using System.Collections.Generic;

namespace Extensions
{
    public static class QueueExtensions
    {
        public static void EnqueueRange<T>(this Queue<T> queue, IReadOnlyList<T> items)
        {
            for (int i = 0; i < items.Count; i++) 
                queue.Enqueue(items[i]);
        }
    }
}