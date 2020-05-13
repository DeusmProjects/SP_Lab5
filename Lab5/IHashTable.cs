namespace Lab5
{
    internal interface IHashTable
    {
        string Name { get; }

        void Put(string value);

        bool Contains(string value);
    }
}
