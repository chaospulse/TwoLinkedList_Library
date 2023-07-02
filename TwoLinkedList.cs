using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace IdealWeightStudentsLibrary
{
    public abstract class TwoLinkedList<T> : IEnumerable<T>
    {
        protected TwoLinkedList() { }
		protected ListNode<T>? head { get; private set; } // reference to the first list item
		protected ListNode<T>? tail { get; private set; } // reference to the last list item
		public ListNode<T> GetPreviousNode(ListNode<T> node) { return node.Previous; } // returns the previous node
        //
		// adding an element to the end of the list
        //
		public void AddStudent(T data)
        {
            ListNode<T> newNode = new ListNode<T>(data);

			// if the list is empty, add a new node to the beginning of the list
			if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
			//if the list is not empty, add a new node to the end of the list
			else
			{
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }
		// deleting an element from the end of the list
		public void RemoveStudent(int position)
        {
            if (Length == 0)
                throw new InvalidOperationException("List is empty");
            if (position < 0 || position >= GetLength())
                throw new ArgumentOutOfRangeException("Index out of range");

			//if the list has only one element
			if (position == 0)
            {
                ListNode<T> nodeToRemove = head;
                head = head.Next;
                if (head != null)
                    head.Previous = null;

                nodeToRemove.Next = null;
            }
			// if the node to be deleted is at the end of the list
			else if (position == GetLength() - 1)
            {
                ListNode<T> NodeToRemove = tail;
                tail = tail.Previous;
                if (tail != null)
                    tail.Next = null;

                NodeToRemove.Previous = null;
            }
			// if the node to be deleted is in the middle of the list
			else
			{
                ListNode<T> current = head;
                for (int i = 0; i < position; i++)
                    current = current.Next;

                ListNode<T> nodeToRemove = current;
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
                nodeToRemove.Next = null;
                nodeToRemove.Previous = null;
            }
        }
        //
		// indexator for accessing the list by index
        //
		public ListNode<T> this[int index]
        {
            get
            {
                if (index < 0 || index >= GetLength())
                    throw new ArgumentOutOfRangeException("index", "Invalid index");

                ListNode<T> current = head;
                for (int i = 0; i < index; i++)
                    current = current.Next;

                return current;
            }
            set
            {
                if (index < 0 || index >= GetLength())
                    throw new ArgumentOutOfRangeException("index", "Invalid index");

                ListNode<T> current = head;
                for (int i = 0; i < index; i++)
                    current = current.Next;
            }
        }
        //
		// length of the list
        //
		public int Length { get { return GetLength(); } }
        private int GetLength()
        {
            int length = 0;
            ListNode<T> current = head;
            while (current != null)
            {
                length++;
                current = current.Next;
            }
            return length;
        }
		//
		// sorting the list
		//
		public abstract void Sort();
		//
		// swapping two elements of the list
		//
		protected void Swap(ListNode<T> node1, ListNode<T> node2)
        {
           T temp = node1.Data;
           node1.Data = node2.Data;
           node2.Data = temp;
        }
		//
		// finding the element in the list
		//
		public abstract List<T> Find();
		//
		// getting an enumerator
		//
		public IEnumerable<T> GetReversedEnumerator()
        {
            ListNode<T>? current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
		public IEnumerator<T> GetEnumerator()
        {
            ListNode<T>? current = tail;
            while (current is not null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
