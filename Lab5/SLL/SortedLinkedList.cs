using System.Text;

namespace Lab5.SLL
{
    public class SortedLinkedList : ISortedLinkedLIst
    {
        private SortedLinkedListNode head;
        private int count = 0;

        public int Count => count;

        public void Add(string value)
        {
            SortedLinkedListNode newNode = new SortedLinkedListNode(value);

            if (head == null)
                head = newNode;
            else
            {
                if (newNode.CompareTo(head) <= 0)
                {
                    InsertBeforeNode(head, newNode);
                }
                else
                {
                    SortedLinkedListNode current = head;

                    while (current.next != null && newNode.CompareTo(current.next) > 0)
                    {
                        current = current.next;
                    }

                    InsertAfterNode(current, newNode);
                }
            }

            count++;
        }

        public bool Contains(string value)
        {
            SortedLinkedListNode node = head;

            while (node != null)
            {
                if (node.value.Equals(value))
                    return true;

                node = node.next;
            }

            return false;
        }

        public SortedLinkedListNode First()
        {
            return this.head;
        }

        public SortedLinkedListNode Last()
        {
            SortedLinkedListNode node = head;

            while (node.next != null)
            {
                node = node.next;
            }

            return node;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            SortedLinkedListNode node = head;

            while (node != null)
            {
                sb.Append(node.value).Append(" ");
                node = node.next;
            }

            return sb.ToString();
        }

        private void InsertAfterNode(SortedLinkedListNode node, SortedLinkedListNode newNode)
        {
            SortedLinkedListNode tmp = node.next;
            node.next = newNode;
            newNode.next = tmp;
        }

        private void InsertBeforeNode(SortedLinkedListNode node, SortedLinkedListNode newNode)
        {
            if (node == head)
            {
                newNode.next = node;
                head = newNode;
                return;
            }

            SortedLinkedListNode current = head;

            while (current.next != node)
            {
                current = current.next;
            }

            current.next = newNode;
            newNode.next = node;
        }
    }
}
