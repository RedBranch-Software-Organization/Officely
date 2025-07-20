using System.Text.Json.Serialization;

namespace Officely.CodeService.Api.Client.Models.Generate;
public class GenerateResponseDto()
{
    [JsonPropertyName("codes")]
    public List<string> Codes { get; set; } = [];
}
