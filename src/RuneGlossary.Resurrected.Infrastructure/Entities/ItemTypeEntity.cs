namespace RuneGlossary.Resurrected.Infrastructure.Entities
{
    public enum ItemClass
    {
        Armor,
        Weapon
    }

    public class ItemTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemClass Class { get; set; }


        public ICollection<RuneWordEntity> RuneWords { get; set; }
        public ICollection<RuneWordItemTypeSwitchEntity> ItemTypeSwitch { get; set; }
    }
}
