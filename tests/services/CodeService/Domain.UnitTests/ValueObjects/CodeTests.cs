using Moq;
using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Interfaces;
using RB.Storage.CodeService.Domain.ValueObjects;

namespace RB.Storage.CodeService.Domain.UnitTests.ValueObjects;

public class CodeTests
{
    [Fact]
    public async Task GenerateAsync_WhenCalled_ReturnsCodeObjectWithCorrectCodeTypeAndValue()
    {
        // Arrange
        var codeType = CodeType.Default;
        var expectedValue = "test_code";
        var generatorMock = new Mock<IGenerator>();
        generatorMock.Setup(g => g.GenerateAsync(default)).ReturnsAsync(expectedValue);
        var generatorFactoryMock = new Mock<IGeneratorFactory>();
        generatorFactoryMock.Setup(f => f.Create(codeType)).Returns(generatorMock.Object);

        // Act
        var code = await Code.GenerateAsync(codeType, generatorFactoryMock.Object);

        // Assert
        Assert.Equal(codeType, code.CodeType);
        Assert.Equal(expectedValue, code.Value);
    }
}
