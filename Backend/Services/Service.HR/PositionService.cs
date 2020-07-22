using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Database.Sql.HR;
using DataBase.Sql.HR.Entities;
using Microsoft.EntityFrameworkCore;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.HR
{
    public class PositionService : IPositionService
    {
        private readonly IHRUnitOfWork _context;
        public PositionService(IHRUnitOfWork context)
        {
            _context = context;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from p in _context.PositionRepository.Query()
                            where !p.Deleted && !p.IsActive
                            orderby p.Name ascending
                            select new PositionModel()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Description = p.Description,
                                Precedence = p.Precedence,
                                IsActive = p.IsActive
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(p => p.Name.ToLower().Contains(filter.Text));
                }

                var listItems = new BaseListModel<PositionModel>();
                listItems.TotalItems = await _context.CommendationRepository.Query().Where(p => !p.Deleted).CountAsync();
                listItems.Items = await query.Skip(filter.Paging.PageIndex * filter.Paging.PageSize).Take(filter.Paging.PageSize).ToListAsync().ConfigureAwait(false);

                response.Result = listItems;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> DropDownSelection()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from p in _context.PositionRepository.Query()
                            where p.IsActive && !p.Deleted
                            orderby p.Name ascending
                            select new PositionModel
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Precedence = p.Precedence
                            };

                response.Result = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

    }
}
