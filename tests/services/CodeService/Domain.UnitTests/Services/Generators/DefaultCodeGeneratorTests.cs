using Officely.CodeService.Domain.Services.Generators;

namespace Officely.CodeService.Domain.UnitTests.Services.Generators;

public class DefaultCodeGeneratorTests
{
    private static readonly char[] _allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=[]{}|:;,.<>?".ToCharArray();

    private readonly int _minValue = 1;
    private readonly int _maxValue = 100;

    [Fact]
    public async Task GenerateAsync_WhenCalled_ReturnsStringWithLengthBetween1And100()
    {
        // Arrange
        var generator = new DefaultCodeGenerator();
        // Act
        var code = await generator.GenerateAsync();
        // Assert
        Assert.InRange(code.Length, _minValue, _maxValue);
    }

    [Fact]
    public async Task GenerateAsync_WhenCalled_ReturnsStringWithAllowedCharacters()
    {
        // Arrange
        var generator = new DefaultCodeGenerator();
        // Act
        var code = await generator.GenerateAsync();
        // Assert
        foreach (var c in code)
            Assert.Contains(c, _allowedChars);
    }
}
