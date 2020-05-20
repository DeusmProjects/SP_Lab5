using System.Collections.Generic;

namespace Lab5
{
    internal class ChainsTable : IHashTable
    {
        public string Name => "Метод цепочек";

        private readonly LinkedList<string>[] _table;

        public ChainsTable(int tableSize)
        {
            _table = new LinkedList<string>[tableSize];
        }

        public void Put(string value)
        {
            var hash = HashFunction.Hash(value);

            if (_table[hash] == null)
            {
                _table[hash] = new LinkedList<string>();
            }

            _table[hash].AddLast(value);
        }

        public bool Contains(string value)
        {
            var hash = HashFunction.Hash(value);
            return _table[hash] != null && _table[hash].Contains(value);
        }
    }
}
