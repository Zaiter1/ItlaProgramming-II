//Miguel Zaiter 2025-0928
namespace LearningApi.Models.Dtos 
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public bool Stock { get; set; }
        public DateTime DateReceived { get; set; }
    }
}