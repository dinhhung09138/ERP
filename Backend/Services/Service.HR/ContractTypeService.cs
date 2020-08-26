using Core.CommonMessage;
using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Core.Services;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.HR
{
    public class ContractTypeService : BaseService, IContractTypeService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<ContractTypeService> _logger;

        public ContractTypeService(
            IERPUnitOfWork context,
            ILogger<ContractTypeService> logger,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            _logger = logger;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.ContractTypeRepository.Query()
                            where !m.Deleted
                            orderby m.Precedence
                            select new ContractTypeModel()
                            {
                                Id = m.Id,
                                Code = m.Code,
                                Name = m.Name,
                                Description = m.Description,
                                AllowInsurance = m.AllowInsurance,
                                AllowLeaveDate = m.AllowLeaveDate,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Code.ToLower().Contains(filter.Text)
                                            || m.Name.ToLower().Contains(filter.Text)
                                            || m.Description.ToLower().Contains(filter.Text));
                }

                BaseListModel<ContractTypeModel> listItems = new BaseListModel<ContractTypeModel>();
                listItems.TotalItems = await _context.ContractTypeRepository.Query().Where(m => !m.Deleted).CountAsync();
                listItems.Items = await query.Skip(filter.Paging.PageIndex * filter.Paging.PageSize).Take(filter.Paging.PageSize).ToListAsync().ConfigureAwait(false);

                response.Result = listItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> DropDownSelection()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.ContractTypeRepository.Query()
                            where m.IsActive && !m.Deleted
                            orderby m.CreateDate ascending
                            select new ContractTypeModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                            };

                response.Result = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.GetDropDownError;
                _logger.LogError(ex.Message, ex);
            }
            return response;
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                ContractType md = await _context.ContractTypeRepository.FirstOrDefaultAsync(m => m.Id == id);

                ContractTypeModel model = new ContractTypeModel()
                {
                    Id = md.Id,
                    Code = md.Code,
                    Name = md.Name,
                    Description = md.Description,
                    AllowLeaveDate = md.AllowLeaveDate,
                    AllowInsurance = md.AllowInsurance,
                    Precedence = md.Precedence,
                    IsActive = md.IsActive,
                    RowVersion = md.RowVersion,
                };

                response.Result = model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(ContractTypeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                if (await _context.ContractTypeRepository.CountAsync(m => m.Code == model.Code) > 0)
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.CodeExists;
                    return response;
                }

                ContractType md = new ContractType();

                md.Code = model.Code;
                md.Name = model.Name;
                md.Description = model.Description;
                md.AllowInsurance = model.AllowInsurance;
                md.AllowLeaveDate = model.AllowLeaveDate;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.ContractTypeRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(ContractTypeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ContractType md = await _context.ContractTypeRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Name = model.Name;
                md.Description = model.Description;
                md.AllowInsurance = model.AllowInsurance;
                md.AllowLeaveDate = model.AllowLeaveDate;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.ContractTypeRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(ContractTypeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ContractType md = await _context.ContractTypeRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.ContractTypeRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
