using RuneGlossary.Api.Responses;
using STrain;

namespace RuneGlossary.Api
{
    public record GetClassesQuery : Query<IEnumerable<Class>>
    {
    }
}
