﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class CoolLinkedList
    {
        private class CoolNode
        {
            public CoolNode(object value)
            {
                this.Value = value;
            }

            public object Value { get; private set; }

            public CoolNode Next { get; set; }

            public CoolNode Previous { get; set; }
        }
        
        private CoolNode head;
        private CoolNode tail;

        public int Count { get; private set; }

        public object Head
        {
            get
            {
                if (this.head == null)
                {
                    throw new InvalidCastException("Cool linked list is empty.");
                }

                return this.head.Value;
            }
        }

        public object Tail
        {
            get
            {
                if (this.tail == null)
                {
                    throw new InvalidCastException("Cool linked list is empty.");
                }

                return this.tail.Value;
            }
        }

        public void AddHead(object value)
        {
            var newNode = new CoolNode(value);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                var oldhead = this.head;
                oldhead.Previous = newNode;
                newNode.Next = oldhead;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddTail(object value)
        {
            var newNode = new CoolNode(value);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                var oldtail = this.tail;
                oldtail.Next = newNode;
                newNode.Previous = oldtail;
                this.tail = newNode;
            }

            this.Count++;
        }
        
        public object RemoveHead()
        {
            this.ValidateIfListIsEmpty();

            var value = this.head.Value;

            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                var newHead = this.head.Next;
                newHead.Previous = null;
                this.head.Next = null;
                this.head = newHead;
            }

            this.Count--;

            return value;
        }

        public object RemoveTail()
        {
            this.ValidateIfListIsEmpty();

            var value = this.tail.Value;

            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                var newTail = this.tail.Previous;
                this.tail.Previous = null;
                newTail.Next = null;
                this.tail = newTail;
            }

            this.Count--;

            return value;
        }

        public bool Contains(object value)
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public void Remove(object value)
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                var nodeValue = currentNode.Value;

                if (nodeValue.Equals(value))
                {
                    this.Count--;

                    var prevNode = currentNode.Previous;
                    var nextNode = currentNode.Next;

                    if (prevNode != null)
                    {
                        prevNode.Next = nextNode;
                    }

                    if (nextNode != null)
                    {
                        nextNode.Previous = prevNode;
                    }

                    if (this.head == currentNode)
                    {
                        this.head = nextNode;
                    }

                    if (this.tail == currentNode)
                    {
                        this.tail = prevNode;
                    }
                }
            }
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public void ForEach(Action<object> action, bool reverse = false)
        {
            var currentNode = reverse 
                ? this.tail 
                : this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = reverse ?
                    currentNode.Previous
                    : currentNode.Next;
            }
        }

        public object[] ToArray()
        {
            var arr = new object[this.Count];

            var currentNode = this.head;
            var index = 0;

            while (currentNode != null)
            {
                arr[index] = currentNode.Value;
                index++;
                currentNode = currentNode.Next;
            }
            
            return arr;
        }

        private void ValidateIfListIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidCastException("Cool linked list is empty.");
            }
        }
    }
}
