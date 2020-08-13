﻿using Core.CommonModel;
using Core.Utility;
using Service.HR.Models;
using System.Threading.Tasks;

namespace Service.HR.Interfaces
{
    public interface IEmployeeInfoService : IBaseService<EmployeeInfoModel>
    {
        Task<ResponseModel> UpdateName(int employeeId, string firstName, string lastName);
    }
}
