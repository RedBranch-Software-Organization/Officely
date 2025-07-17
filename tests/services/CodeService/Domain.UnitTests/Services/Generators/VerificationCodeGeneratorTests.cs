using RB.Storage.CodeService.Domain.Services.Generators;

namespace RB.Storage.CodeService.Domain.UnitTests.Services.Generators;

public class VerificationCodeGeneratorTests
{
    [Fact]
    public async Task GenerateAsync_WhenCalled_Returns6DigitNumericString()
    {
        // Arrange
        var generator = new VerificationCodeGenerator();

        // Act
        var code = await generator.GenerateAsync();

        // Assert
        Assert.Equal(6, code.Length);
        Assert.True(code.All(char.IsDigit));
    }
}
