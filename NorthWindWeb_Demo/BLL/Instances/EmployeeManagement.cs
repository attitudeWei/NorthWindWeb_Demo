using NorthWindWeb_Demo.BLL.Interfaces;
using NorthWindWeb_Demo.BLL.Models.EmployeeManagement;
using NorthWindWeb_Demo.DAL;
using NorthWindWeb_Demo.DAL.Entity;

namespace NorthWindWeb_Demo.BLL.Instances
{
    public class EmployeeManagement : IEmployeeManagement
    {
        private readonly DataBaseContext dbContext;

        public EmployeeManagement(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// 檢查新增/刪除傳入參數
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool CheckEmployeeModelData(EmployeeViewModel data)
        {
            if (data == null || string.IsNullOrEmpty(data.LastName) || string.IsNullOrEmpty(data.FirstName))
            {
                return false;
            }
            return true;
        }
        public IEnumerable<EmployeeViewModel> GetEmployessList()
        {
            var result = this.dbContext.Employees.Select(s => new EmployeeViewModel
            {
                EmployeeID = s.EmployeeID,
                FirstName = s.FirstName,
                LastName = s.LastName,
                City = s.City
            }).AsEnumerable();
            return result;
        }
        public EmployeeViewModel? GetEmployess(int employeeId)
        {
            var db_data = this.dbContext.Employees.Find(employeeId);
            if (db_data == null) { return null; }
            var result = new EmployeeViewModel
            {
                EmployeeID = db_data.EmployeeID,
                FirstName = db_data.FirstName,
                LastName = db_data.LastName,
                City = db_data.City
            };
            return result;
        }
        public EmployeeViewModel? CreateEmployess(EmployeeViewModel data)
        {
            if (!CheckEmployeeModelData(data)) { return null; }
            var insertData = new EntityEmployees
            {
                LastName = data.LastName,
                FirstName = data.FirstName,
                City = data.City
            };
            this.dbContext.Employees.Add(insertData);
            this.dbContext.SaveChanges();
            data.EmployeeID = insertData.EmployeeID;
            return data;

        }
        public EmployeeViewModel? UpdateEmployess(EmployeeViewModel data)
        {
            if (!CheckEmployeeModelData(data) || !data.EmployeeID.HasValue) { return null; }
            var db_data = this.dbContext.Employees.Find(data.EmployeeID!.Value);
            if (db_data == null) { return null; }
            db_data.City = data.City;
            db_data.LastName = data.LastName;
            db_data.FirstName = data.FirstName;
            this.dbContext.Update(db_data);
            this.dbContext.SaveChanges();
            return data;
        }
        public bool DeleteEmployess(int employeeId)
        {
            if (employeeId == 0) { return false; }
            var db_data = this.dbContext.Employees.Find(employeeId);
            if (db_data == null) { return false; };
            this.dbContext.Employees.Remove(db_data);
            this.dbContext.SaveChanges();
            return true;
        }
    }
}
