namespace RuneGlossary.Resurrected.Infrastructure.Entities
{
    public class RuneWordEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public IEnumerable<RuneEntity> Runes { get; set; }
        public IEnumerable<ItemTypeEntity> ItemTypes { get; set; }
        public IEnumerable<StatisticEntity> Statistics { get; set; }
        public string Url { get; set; }

        public ICollection<RuneRuneWordSwitchEntity> RuneSwitch { get; set; }
        public ICollection<RuneWordItemTypeSwitchEntity> ItemTypeSwitch { get; set; }
    }
}
