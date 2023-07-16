using System.ComponentModel.DataAnnotations;

namespace NorthWindWeb_Demo.DAL.Entity
{
    public class EntityRegion
    {
        [Key]
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
    }
}
