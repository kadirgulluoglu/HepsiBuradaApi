using HepsiBuradaApi.Domain.Entities;

namespace HepsiBuradaApi.Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public String Title { get; set; }
    public String Description { get; set; }
    public decimal Price { get; set; }

    public BrandDto Brand { get; set; }
    public ICollection<CategoryDto> Categories { get; set; }
}
