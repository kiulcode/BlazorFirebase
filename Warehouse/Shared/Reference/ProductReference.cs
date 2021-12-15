using Warehouse.Shared.Models;

namespace Warehouse.Shared.Reference
{
    public class ProductReference : ProductModel
    {
        public ProductionModel Production { get; set; }
    }
}