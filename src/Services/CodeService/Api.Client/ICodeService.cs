using Officely.CodeService.Api.Client.Models.Generate;
using Refit;

namespace Officely.CodeService.Api.Client;
public interface ICodeService
{
    [Get("/generate?codeType={codeType}&quantity={quantity}")]
    Task<GenerateResponseDto> GenerateAsync([AliasAs("codeType")] int? codeType = null, [AliasAs("quantity")] int?quantity = null);
}
