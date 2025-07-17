using Microsoft.Extensions.DependencyInjection;
using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Extensions;
using RB.Storage.CodeService.Domain.Interfaces;
using RB.Storage.CodeService.Domain.ValueObjects;

namespace RB.Storage.CodeService.Domain.UnitTests.ValueObjects;

public class CodeTests
{
    private readonly IGeneratorFactory _generatorFactory;

    private const int _defaultCodeTypeValue = 0;
    private const int _verificationCodeTypeValue = 1;

    public CodeTests()
    {
        var services = new ServiceCollection();
        services.AddDomain();
        _generatorFactory = services.BuildServiceProvider().GetRequiredService<IGeneratorFactory>();
    }

    [Theory]
    [InlineData(_defaultCodeTypeValue)]
    [InlineData(_verificationCodeTypeValue)]
    public async Task GenerateAsync_WhenCalled_ReturnsCodeObjectWithCorrectCodeType(int expected)
    {
        // Arrange
        var codeType = CodeType.FromValue(expected);
        // Act
        var actual = (await Code.GenerateAsync(codeType, _generatorFactory)).CodeType;
        // Assert
        Assert.Equal(expected, actual);
    }
}
