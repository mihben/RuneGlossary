using RuneGlossary.Client.WASM.Models;

namespace RuneGlossary.Client.WASM.Repositories
{
    public interface ICharacterRepository
    {
        Task DeleteAsync(Character character, CancellationToken cancellationToken);
        Task<IEnumerable<Character>> GetAsync(CancellationToken cancellationToken);
        Task SaveAsync(Character character, CancellationToken cancellationToken);
    }
}
