using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoLinkedListsLibrary
{
    public class ListNode<T>
    {
        public ListNode(T data, ListNode<T>? previous = null, ListNode<T>? next = null)
        {
            Data = data;
            Next = next;
            Previous = previous;
        }
        public T Data { get; set; }
        public ListNode<T>? Next { get; set; }
        public ListNode<T>? Previous { get; set; }
    }
}
