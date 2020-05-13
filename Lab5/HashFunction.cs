namespace Lab5
{
    internal static class HashFunction
    {
        public static int Hash(string value)
        {
            int result = 1;

            foreach (var i in value)
            {
                result += (int) i;
            }

            return result % CountElements;
        }

        public static int CountElements { get; set; }
    }
}
