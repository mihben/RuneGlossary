using RuneGlossary.Api.Responses;
using STrain;

namespace RuneGlossary.Api
{
    public record GetItemTypesQuery : Query<IEnumerable<ItemType>>
    {
    }
}
