//Miguel Zaiter 2025-0928

namespace LearningApi.Models.Dtos
{
    public class ProductUpdateDto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public bool Stock { get; set; }
        public DateTime DateReceived { get; set; }
    }
}
