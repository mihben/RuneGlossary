using Blazored.LocalStorage;
using RuneGlossary.Client.WASM.Models;

namespace RuneGlossary.Client.WASM.Repositories
{
    public class LocalStorageCharacterRepository : ICharacterRepository
    {
        private const string KEY = "characters";

        private readonly ILocalStorageService _storage;

        public LocalStorageCharacterRepository(ILocalStorageService storage)
        {
            _storage = storage;
        }

        public async Task<IEnumerable<Character>> GetAsync(CancellationToken cancellationToken)
        {
            if (!await _storage.ContainKeyAsync(KEY, cancellationToken)) return Enumerable.Empty<Character>();
            return await _storage.GetItemAsync<IEnumerable<Character>>(KEY, cancellationToken);
        }

        public async Task SaveAsync(Character character, CancellationToken cancellationToken)
        {
            var characters = await GetAsync(cancellationToken);
            var existing = characters.SingleOrDefault(c => c.Id == character.Id);

            if (existing is null)
            {
                await _storage.SetItemAsync(KEY, characters.Append(character), cancellationToken);
            }
            else
            {
                existing.Level = character.Level;
                await _storage.SetItemAsync(KEY, characters, cancellationToken);
            }
        }
    }
}
