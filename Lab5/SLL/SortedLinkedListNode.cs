using System;

namespace Lab5.SLL
{
    public class SortedLinkedListNode : IComparable<SortedLinkedListNode>
    {
        internal string value;
        internal SortedLinkedListNode next;

        public SortedLinkedListNode(string value)
        {
            this.value = value;
            this.next = null;
        }

        public string Value
        {
            get => this.value;
            set => this.value = value;
        }

        public SortedLinkedListNode Next => this.next;

        public int CompareTo(SortedLinkedListNode other)
        {
            if (other == null)
                return 1;

            return other.value != value ? string.Compare(value, other.value, StringComparison.Ordinal) : 0;
        }
    }
}
