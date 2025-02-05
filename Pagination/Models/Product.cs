using Microsoft.EntityFrameworkCore;

namespace Pagination.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal price { get; set; }

    }
}
