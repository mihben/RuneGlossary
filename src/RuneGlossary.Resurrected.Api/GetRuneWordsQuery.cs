using STrain;
using static RuneGlossary.Resurrected.Api.GetRuneWordsQuery;

namespace RuneGlossary.Resurrected.Api
{
    public record GetRuneWordsQuery : Query<IEnumerable<Result>>
    {
        public IEnumerable<int> ItemTypes { get; }

        public GetRuneWordsQuery(IEnumerable<int> itemTypes)
        {
            ItemTypes = itemTypes;
        }

        public record Result
        {
            public int Id { get; }
            public string Name { get; }
            public int Level { get; }
            public string Url { get; }
            public IEnumerable<Rune> Runes { get; }
            public IEnumerable<ItemType> ItemTypes { get; }
            public IEnumerable<Statistic> Statistics { get; }

            public Result(int id, string name, int level, string url, IEnumerable<Rune> runes, IEnumerable<ItemType> itemTypes, IEnumerable<Statistic> statistics)
            {
                Id = id;
                Name = name;
                Level = level;
                Url = url;
                Runes = runes;
                ItemTypes = itemTypes;
                Statistics = statistics;
            }

            public record Rune
            {
                public int Id { get; }
                public int Order { get; }
                public int? Level { get; }
                public string InHelmet { get; }
                public string InBodyArmor { get; }
                public string InShield { get; }
                public string InWeapon { get; }

                public Rune(int id, int order, int? level, string inHelmet, string inBodyArmor, string inShield, string inWeapon)
                {
                    Id = id;
                    Order = order;
                    Level = level;
                    InHelmet = inHelmet;
                    InBodyArmor = inBodyArmor;
                    InShield = inShield;
                    InWeapon = inWeapon;
                }
            }

            public record ItemType
            {
                public int Id { get; }
                public string Name { get; }

                public ItemType(int id, string name)
                {
                    Id = id;
                    Name = name;
                }
            }

            public record Statistic
            {
                public int Id { get; }
                public string Description { get; }
                public Skill? Skill { get; }

                public Statistic(int id, string description, Skill? skill)
                {
                    Id = id;
                    Description = description;
                    Skill = skill;
                }
            }

            public record Skill
            {
                public int Id { get; }
                public string Name { get; }
                public string Description { get; }
                public string Url { get; }

                public Skill(int id, string name, string description, string url)
                {
                    Id = id;
                    Name = name;
                    Description = description;
                    Url = url;
                }
            }
        }
    }
}
