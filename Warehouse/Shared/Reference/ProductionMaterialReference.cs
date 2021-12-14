using Warehouse.Shared.Models;

namespace Warehouse.Shared.Reference
{
    public class ProductionMaterialReference : ProductionMaterialModel
    {
        public ProductionModel Production { get; set; }
    }
}