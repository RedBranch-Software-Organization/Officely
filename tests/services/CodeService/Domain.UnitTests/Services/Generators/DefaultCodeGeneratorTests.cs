using RB.Storage.CodeService.Domain.Services.Generators;

namespace RB.Storage.CodeService.Domain.UnitTests.Services.Generators;

public class DefaultCodeGeneratorTests
{
    [Fact]
    public async Task GenerateAsync_WhenCalled_ReturnsStringWithLengthBetween1And100()
    {
        // Arrange
        var generator = new DefaultCodeGenerator();

        // Act
        var code = await generator.GenerateAsync();

        // Assert
        Assert.InRange(code.Length, 1, 100);
    }

    [Fact]
    public async Task GenerateAsync_WhenCalled_ReturnsStringWithAllowedCharacters()
    {
        // Arrange
        var generator = new DefaultCodeGenerator();
        var allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=[]{}|:;,.<>?".ToCharArray();

        // Act
        var code = await generator.GenerateAsync();

        // Assert
        foreach (var c in code)
        {
            Assert.Contains(c, allowedChars);
        }
    }
}
