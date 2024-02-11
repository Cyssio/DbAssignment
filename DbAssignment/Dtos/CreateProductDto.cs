namespace DbAssignment.Dtos;

internal class CreateProductDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = null!;
}
