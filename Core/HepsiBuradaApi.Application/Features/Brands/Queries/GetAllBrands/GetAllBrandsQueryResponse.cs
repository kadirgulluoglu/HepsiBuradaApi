using System.Text.Json.Serialization;
using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.DTOs;

public class GetAllBrandsQueryResponse
{
    [JsonPropertyName("brands")] public IList<BrandDto> Brands { get; set; }

    [JsonPropertyName("totalCount")] public int TotalCount { get; set; }
}
