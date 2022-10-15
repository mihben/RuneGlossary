namespace RuneGlossary.Api.Responses
{
    public record RuneWord
    {
        public int Id { get; }
        public string Name { get; }
        public int Level { get; }
        public IEnumerable<ItemType> ItemTypes { get; }
        public IEnumerable<Rune> Runes { get; }
        public IEnumerable<Statistic> Statistics { get; }
        public string Url { get; }

        public RuneWord(int id, string name, int level, IEnumerable<ItemType> itemTypes, IEnumerable<Rune> runes, IEnumerable<Statistic> statistics, string url)
        {
            Id = id;
            Name = name;
            Level = level;
            ItemTypes = itemTypes;
            Runes = runes;
            Statistics = statistics;
            Url = url;
        }
    }
}
