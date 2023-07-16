using System.ComponentModel.DataAnnotations;

namespace NorthWindWeb_Demo.DAL.Entity
{
    public class EntityTerritories
    {
        [Key]
        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }
    }
}
