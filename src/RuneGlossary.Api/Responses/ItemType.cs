namespace RuneGlossary.Api.Responses
{
    public enum ItemClass
    {
        Weapon,
        Armor
    }

    public record ItemType
    {
        public int Id { get; }
        public ItemClass Class { get; }
        public string Name { get; }

        public ItemType(int id, ItemClass @class, string name)
        {
            Id = id;
            Class = @class;
            Name = name;
        }
    }
}
