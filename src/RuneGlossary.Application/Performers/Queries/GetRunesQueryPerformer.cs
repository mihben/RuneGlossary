﻿using Microsoft.Extensions.Logging;
using RuneGlossary.Api;
using STrain;
using GetRunesQuery = RuneGlossary.Api.GetRunesQuery;

namespace RuneGlossary.Application.Performers.Queries
{
    public class GetRunesQueryPerformer : IQueryPerformer<GetRunesQuery, IEnumerable<Rune>>
    {
        private readonly IRequestSender _sender;
        private readonly ILogger<GetRunesQueryPerformer> _logger;

        public GetRunesQueryPerformer(IRequestSender sender, ILogger<GetRunesQueryPerformer> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task<IEnumerable<Rune>> PerformAsync(GetRunesQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Querying runes");
            return (await _sender.GetAsync<Resurrected.Api.GetRunesQuery, IEnumerable<Resurrected.Api.GetRunesQuery.Rune>>(new Resurrected.Api.GetRunesQuery(), cancellationToken))?
                        .Select(r => new Rune(r.Id, r.Name, r.Level, r.InHelmet, r.InBodyArmor, r.InShield, r.InWeapon)) ?? Enumerable.Empty<Rune>();
        }
    }
}
