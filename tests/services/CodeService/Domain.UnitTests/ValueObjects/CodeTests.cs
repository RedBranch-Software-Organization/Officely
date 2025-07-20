using Microsoft.Extensions.DependencyInjection;
using Officely.CodeService.Domain.Enums;
using Officely.CodeService.Domain.Extensions;
using Officely.CodeService.Domain.Interfaces;
using Officely.CodeService.Domain.ValueObjects;

namespace Officely.CodeService.Domain.UnitTests.ValueObjects;

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
