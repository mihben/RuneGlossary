﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RuneGlossary.Resurrected.Api;
using RuneGlossary.Resurrected.Infrastructure;
using STrain;

namespace RuneGlossary.Resurrected.Application.Performers.Queries
{
    public class GetRunesQueryPerformer : IQueryPerformer<GetRunesQuery, IEnumerable<GetRunesQuery.Rune>>
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<GetRunesQueryPerformer> _logger;

        public GetRunesQueryPerformer(DatabaseContext context, ILogger<GetRunesQueryPerformer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<GetRunesQuery.Rune>> PerformAsync(GetRunesQuery query, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Querying runes");
            return (await _context.Runes.ToListAsync(cancellationToken))
                        .Select(r => new GetRunesQuery.Rune(r.Id, r.Name, r.Level, r.InHelmet, r.InBodyArmor, r.InShield, r.InWeapon));
        }
    }
}
