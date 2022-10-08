using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RuneGlossary.Resurrected.Api;
using RuneGlossary.Resurrected.Infrastructure;
using RuneGlossary.Resurrected.Infrastructure.Entities;
using STrain;

namespace RuneGlossary.Resurrected.Application.Performers
{
    public class RuneWordPerformers : IQueryPerformer<GetRunesWordsQuery, IEnumerable<GetRunesWordsQuery.Result>>
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<RuneWordPerformers> _logger;

        public RuneWordPerformers(DatabaseContext context, ILogger<RuneWordPerformers> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<GetRunesWordsQuery.Result>> PerformAsync(GetRunesWordsQuery query, CancellationToken cancellationToken)
        {
            return (await _context.RuneWords
                            .Include(rw => rw.RuneSwitch)
                            .ThenInclude(rw => rw.Rune)
                            .Include(rw => rw.ItemTypeSwitch)
                            .ThenInclude(rw => rw.ItemType)
                            .Include(rw => rw.Statistics)
                            .ToListAsync(cancellationToken)).AsResult();
        }
    }

    internal static class RuneWordPerformersExtensions
    {
        public static IEnumerable<GetRunesWordsQuery.Result> AsResult(this IEnumerable<RuneWordEntity> entities)
        {
            return entities.Select(e => e.AsResult());
        }

        public static GetRunesWordsQuery.Result AsResult(this RuneWordEntity entity)
        {
            return new GetRunesWordsQuery.Result(entity.Id,
                                                 entity.Name,
                                                 entity.Level,
                                                 entity.Url,
                                                 entity.RuneSwitch.Select(rs => new GetRunesWordsQuery.Result.Rune(rs.Rune.Id,
                                                                                                                   rs.Order,
                                                                                                                   rs.Rune.Level,
                                                                                                                   rs.Rune.InHelmet,
                                                                                                                   rs.Rune.InBodyArmor,
                                                                                                                   rs.Rune.InShield,
                                                                                                                   rs.Rune.InWeapon)),
                                                 entity.ItemTypeSwitch.Select(it => new GetRunesWordsQuery.Result.ItemType(it.ItemType.Id, it.ItemType.Name)),
                                                 entity.Statistics.Select(s => new GetRunesWordsQuery.Result.Statistic(s.Id, s.Description, null)));
        }
    }
}
