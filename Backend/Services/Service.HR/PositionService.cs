using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.HR;
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
        private readonly IERPUnitOfWork _context;
        public PositionService(IERPUnitOfWork context)
        {
            _context = context;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from p in _context.PositionRepository.Query()
                            where !p.Deleted && p.IsActive
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
                listItems.TotalItems = await _context.PositionRepository.Query().Where(p => !p.Deleted).CountAsync();
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
        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Position md = await _context.PositionRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                PositionModel model = new PositionModel()
                {
                    Id = md.Id,
                    Name = md.Name,
                    Description = md.Description,
                    IsActive = md.IsActive,
                    Precedence = md.Precedence
                };

                response.Result = model;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Insert(PositionModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Position md = new Position();

                md.Name = model.Name;
                md.Description = model.Description;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                //Khi nào có chức năng login rồi thêm CreateBy
                // md.CreateBy = 
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.PositionRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Update(PositionModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Position md = await _context.PositionRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Name = model.Name;
                md.Description = model.Description;
                md.IsActive = model.IsActive;
                md.Precedence = model.Precedence;
                //md.UpdateBy = ; 
                md.UpdateDate = DateTime.Now;

                _context.PositionRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Position md = await _context.PositionRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                // md.UpdateBy = ;
                md.UpdateDate = DateTime.Now;

                _context.PositionRepository.Update(md);

                await _context.SaveChangesAsync();
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
