using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHashtable
{
    public class HashTable
    {
        private HashNode[] buckets;
        private int numOfBuckets; // capacity
        private int size; // number of key value pairs in hash table or number of hash nodes in a HashTable

        public HashTable() : this(10) // default capacity
        {
        }

        public HashTable(int capacity)
        {
            this.numOfBuckets = capacity;
            this.buckets = new HashNode[numOfBuckets];
            this.size = 0;
        }

        private class HashNode
        {
            public int key; // Can be generic type
            public string value; // Can be generic type
            public HashNode next; // reference to next HashNode

            public HashNode(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Put(int key, string value)
        {
            if (value == null)
            {
                throw new ArgumentException("Value is null!");
            }

            int bucketIndex = GetBucketIndex(key);
            HashNode head = buckets[bucketIndex];
            while (head != null)
            {
                if (head.key == key)
                {
                    head.value = value;
                    return;
                }
                head = head.next;
            }

            size++;
            head = buckets[bucketIndex];
            HashNode node = new HashNode(key, value);
            node.next = head;
            buckets[bucketIndex] = node;
        }

        private int GetBucketIndex(int key)
        {
            return key % numOfBuckets;
        }

        public string Get(int key)
        {
            int bucketIndex = GetBucketIndex(key);
            HashNode head = buckets[bucketIndex];
            while (head != null)
            {
                if (head.key == key)
                {
                    return head.value;
                }
                head = head.next;
            }

            return null;
        }

        public string Remove(int key)
        {
            int bucketIndex = GetBucketIndex(key);
            HashNode head = buckets[bucketIndex];
            HashNode previous = null;

            while (head != null)
            {
                if (head.key == key)
                {
                    break;
                }
                previous = head;
                head = head.next;
            }

            if (head == null)
            {
                return null;
            }

            size--;
            if (previous != null)
            {
                previous.next = head.next;
            }
            else
            {
                buckets[bucketIndex] = head.next;
            }

            return head.value;
        }
    }


}

