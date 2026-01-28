namespace MiguelGameDev
{
    public readonly struct IndexNumber
    {
        public readonly int Index { get; }
        public readonly int Number { get; }

        public IndexNumber(int index)
        {
            Index = index;
            Number = index + 1;
        }

        public IndexNumber Next()
        {
            return new IndexNumber(Index + 1);
        }
    }
}
