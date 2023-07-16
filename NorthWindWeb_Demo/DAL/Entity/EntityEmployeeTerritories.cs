using System.ComponentModel.DataAnnotations;

namespace NorthWindWeb_Demo.DAL.Entity
{
    public class EntityEmployeeTerritories
    {
        [Key]
        public int EmployeeID { get; set;}
        [Key]
        public string TerritoryID { get; set;}  
    }
}
