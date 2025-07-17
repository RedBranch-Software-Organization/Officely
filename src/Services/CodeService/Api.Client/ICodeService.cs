using RB.Storage.CodeService.Api.Client.Models.Generate;
using Refit;

namespace RB.Storage.CodeService.Api.Client;
public interface ICodeService
{
    [Get("/generate?codeType={codeType}&quantity={quantity}")]
    Task<GenerateResponseDto> GenerateAsync([AliasAs("codeType")] int? codeType = null, [AliasAs("quantity")] int?quantity = null);
}
