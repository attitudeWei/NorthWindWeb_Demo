using Microsoft.AspNetCore.Mvc;
using NorthWindWeb_Demo.BLL.Interfaces;
using NorthWindWeb_Demo.BLL.Models.EmployeeManagement;
using NorthWindWeb_Demo.Models;

namespace NorthWindWeb_Demo.Controllers
{
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManagement employeeManagement;
        private readonly ILogger<EmployeeController> logger;
        public EmployeeController(IEmployeeManagement employeeManagement, ILogger<EmployeeController> logger)
        {
            this.employeeManagement = employeeManagement;
            this.logger = logger;
        }


        [HttpGet("",Name ="取得員工清單")]
        public IActionResult GetList()
        {
            try
            {
                var result = this.employeeManagement.GetEmployessList();
                return Ok(ApiResultModel.Success(result));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return Ok(ApiResultModel.Failed(200, new ErrorModel { ErrorCode = 001, ErrorMessage = "error" })); ;
            }
        }
        [HttpGet("{employeeId}", Name = "取得員工詳細資料")]
        public IActionResult Get([FromRoute] int employeeId)
        {
            try
            {
                if (employeeId == 0) { return BadRequest(); }
                var result = this.employeeManagement.GetEmployess(employeeId);
                if (result == null) { return NoContent(); }
                return Ok(ApiResultModel.Success(result));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return Ok(ApiResultModel.Failed(200, new ErrorModel { ErrorCode = 000, ErrorMessage = "some error message..." }));
            }
        }
        [HttpPost("", Name = "新增員工資料")]
        public IActionResult Create([FromBody] EmployeeViewModel data)
        {
            try
            {
                var result = this.employeeManagement.CreateEmployess(data);
                if (result == null) { return BadRequest(); }
                return Ok(ApiResultModel.Success(result));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return Ok(ApiResultModel.Failed(200, new ErrorModel { ErrorCode = 000, ErrorMessage = "error" }));
            }
        }
        [HttpPut("{employeeId}", Name = "修改員工資料")]
        public IActionResult Update([FromRoute] int employeeId, [FromBody] EmployeeViewModel data)
        {
            try
            {
                if (employeeId == 0) { return BadRequest(); }
                data.EmployeeID = employeeId;
                var result = this.employeeManagement.UpdateEmployess(data);
                if (result == null) { return BadRequest(); }
                return Ok(ApiResultModel.Success(result));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return Ok(ApiResultModel.Failed(200, new ErrorModel { ErrorCode = 000, ErrorMessage = "error" }));
            }
        }
        [HttpDelete("{employeeId}", Name = "刪除員工資料")]
        public IActionResult Delete([FromRoute] int employeeId)
        {
            try
            {
                if (employeeId == 0) { return BadRequest(); }
                var result = this.employeeManagement.DeleteEmployess(employeeId);
                if (result == null) { return BadRequest(); }
                return Ok(ApiResultModel.Success(result));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return Ok(ApiResultModel.Failed(200, new ErrorModel { ErrorCode = 000, ErrorMessage = "error" }));
            }
        }
    }
}
