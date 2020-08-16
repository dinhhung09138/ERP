﻿using Core.CommonModel;
using Core.Services.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace Service.HR.Interfaces
{
    public interface IPositionService : IBaseService<PositionModel>
    {
        Task<ResponseModel> DropDownSelection();
    }
}
