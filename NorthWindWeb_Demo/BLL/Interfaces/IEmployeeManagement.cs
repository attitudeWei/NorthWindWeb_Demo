using NorthWindWeb_Demo.BLL.Models.EmployeeManagement;

namespace NorthWindWeb_Demo.BLL.Interfaces
{
    public interface IEmployeeManagement
    {
        /// <summary>
        /// 取得Employess清單
        /// </summary>
        public IEnumerable<EmployeeViewModel> GetEmployessList();
        /// <summary>
        /// 取得Employess詳細資料
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public EmployeeViewModel? GetEmployess(int employeeId);
        /// <summary>
        /// 新增Employess
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public EmployeeViewModel? CreateEmployess(EmployeeViewModel data);
        /// <summary>
        /// 修改Employess
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public EmployeeViewModel? UpdateEmployess(EmployeeViewModel data);
        /// <summary>
        /// 刪除Employess
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public bool DeleteEmployess(int employeeId);

    }
}
