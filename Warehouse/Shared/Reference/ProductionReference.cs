using Warehouse.Shared.Models;

namespace Warehouse.Shared.Reference
{
    public class ProductionReference : ProductionModel
    {
        public RawMaterialModel RawMaterial { get; set; }

        public SectorModel Sector { get; set; }

        public PreserveTypeModel PreserveType { get; set; }
    }
}