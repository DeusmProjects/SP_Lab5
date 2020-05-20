using Lab5.SLL;

namespace Lab5
{
    internal class OrderListTable : IHashTable
    {
        public string Name => "Открытая адресация с упорядоченным списком";

        private readonly string[] _table;
        private readonly SortedLinkedList _sll;

        public OrderListTable(int tableSize)
        {
            _table = new string[tableSize];
            _sll = new SortedLinkedList();
        }

        public void Put(string value)
        {
            int hash = HashFunction.Hash(value);

            if (string.IsNullOrEmpty(_table[hash]))
            {
                _table[hash] = value;
            }
            else
            {
                _sll.Add(value);
            }
        }

        public bool Contains(string value)
        {
            int hash = HashFunction.Hash(value);

            if (string.IsNullOrEmpty(_table[hash])) return false;
            
            return _table[hash].Equals(value) || _sll.Contains(value);
        }
    }
}
