namespace LearningApi.Models.Dtos
{
    namespace LearningApi.Models.Dtos 
    {
        //Miguel Zaiter 2025-0928

        public class ProductReadDto
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public bool Stock { get; set; }
            public DateTime DateReceived { get; set; }
        }

        public class ProductCreateDto
        {
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public bool Stock { get; set; }
            public DateTime DateReceived { get; set; }
        }

        public class ProductUpdateDto
        {
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public bool Stock { get; set; }
            public DateTime DateReceived { get; set; }
        }

    }
}
