using HepsiBuradaApi.Domain.Entities;

namespace HepsiBuradaApi.Application.DTOs;

public class ProductDto
{
    public int id { get; set; }
    public String Title { get; set; }
    public String Description { get; set; }
    public decimal Price { get; set; }
    public BrandDto Brand { get; set; }
}
