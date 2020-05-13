namespace Lab5.SLL
{
    public interface ISortedLinkedLIst
    {
        void Add(string value);

        bool Contains(string value);

        SortedLinkedListNode First();

        SortedLinkedListNode Last();

        int Count { get; }
    }
}
