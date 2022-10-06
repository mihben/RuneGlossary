using AutoFixture;
using Blazored.LocalStorage;
using Moq;
using RuneGlossary.Client.WASM.Models;
using RuneGlossary.Client.WASM.Repositories;

namespace RuneGlossary.Test.Unit.Repositories
{
	public class LocalStorageCharacterRepositoryTest
	{
		private Mock<ILocalStorageService> _localStorageServiceMock = null!;

		private LocalStorageCharacterRepository CreateSUT()
		{
			_localStorageServiceMock = new Mock<ILocalStorageService>();

			return new LocalStorageCharacterRepository(_localStorageServiceMock.Object);
		}

		[Fact(DisplayName = "[UNIT][LSCR-001] - Get all characters")]
		public async Task LocalStorageCharacterRepository_GetAsync_GetAllCharacters()
		{
			// Arrange
			var sut = CreateSUT();

			_localStorageServiceMock.Setup(lls => lls.ContainKeyAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(true);

			// Act
			await sut.GetAsync(default);

			// Assert
			_localStorageServiceMock.Verify(lss => lss.GetItemAsync<IEnumerable<Character>>("characters", It.IsAny<CancellationToken>()), Times.Once);
		}

		[Fact(DisplayName = "[UNIT][LSCR-002] - Not found saved data")]
		public async Task LocalStorageCharacterRepository_GetAsync_NotFoundSaveData()
		{
			// Arrange
			var sut = CreateSUT();

			_localStorageServiceMock.Setup(lls => lls.ContainKeyAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(false);

			// Act
			var result = await sut.GetAsync(default);

			// Assert
			Assert.Empty(result);
		}

		[Fact(DisplayName = "[UNIT][LSCR-003] - Save new character")]
		public async Task LocalStorageCharacterRepository_SaveAsync_SaveNewCharacter()
		{
			// Arrange
			var sut = CreateSUT();
			var characters = new Fixture().CreateMany<Character>();
			var character = new Fixture().Create<Character>();

			_localStorageServiceMock.Setup(lls => lls.ContainKeyAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(true);
			_localStorageServiceMock.Setup(lls => lls.GetItemAsync<IEnumerable<Character>>("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(characters);

			// Act
			await sut.SaveAsync(character, default);

			// Assert
			_localStorageServiceMock.Verify(lls => lls.SetItemAsync("characters", It.Is<IEnumerable<Character>>(c => c.SequenceEqual(characters.Append(character))), It.IsAny<CancellationToken>()), Times.Once);
		}

		[Fact(DisplayName = "[UNIT][LSCR-004] - Save modified character")]
		public async Task LocalStorageCharacterRepository_SaveAsync_SaveModifiedCharacter()
		{
			// Arrange
			var sut = CreateSUT();
			var characters = new Fixture().CreateMany<Character>();
			var character = new Character(characters.First().Id)
			{
				Class = characters.First().Class,
				Name = characters.First().Name,
				Level = new Fixture().Create<int>()
			};

			_localStorageServiceMock.Setup(lls => lls.ContainKeyAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(true);
			_localStorageServiceMock.Setup(lls => lls.GetItemAsync<IEnumerable<Character>>("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(characters);

			// Act
			await sut.SaveAsync(character, default);

			// Assert
			characters.First().Level = character.Level;
			_localStorageServiceMock.Verify(lls => lls.SetItemAsync("characters", It.Is<IEnumerable<Character>>(c => c.SequenceEqual(characters)), It.IsAny<CancellationToken>()), Times.Once);
		}

		[Fact(DisplayName = "[UNIT][LSCR-005] - Delete character")]
		public async Task LocalStorageCharacterRepository_DeleteAsync_DeleteCharacter()
		{
			// Arrange
			var sut = CreateSUT();
			var characters = new Fixture().CreateMany<Character>();

			_localStorageServiceMock.Setup(lls => lls.ContainKeyAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(true);
			_localStorageServiceMock.Setup(lls => lls.GetItemAsync<IEnumerable<Character>>("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(characters.ToList());

			// Act
			await sut.DeleteAsync(characters.First(), default);

			// Assert
			_localStorageServiceMock.Verify(lls => lls.SetItemAsync("characters", It.Is<IEnumerable<Character>>(c => !c.Contains(characters.First())), It.IsAny<CancellationToken>()), Times.Once);
		}
	}
}
