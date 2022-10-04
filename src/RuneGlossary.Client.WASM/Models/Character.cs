using RuneGlossary.Api.Responses;

namespace RuneGlossary.Client.WASM.Models
{
    public class Character
    {
        public int Id { get; }
        public Class Class { get; }
        public string Name { get; }
        public int Level { get; set; }

        public Character(int id, Class @class, string name, int level)
        {
            Id = id;
            Class = @class;
            Name = name;
            Level = level;
        }
    }
}
