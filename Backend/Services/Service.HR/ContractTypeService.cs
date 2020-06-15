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
    public class ContractTypeService : IContractTypeService
    {
        private readonly IHRUnitOfWork _context;
        public ContractTypeService(IHRUnitOfWork context)
        {
            _context = context;
        }
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = _context.ContractTypeRepository.Query();

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Code.ToLower().Contains(filter.Text)
                                            || m.Name.ToLower().Contains(filter.Text)
                                            || m.Description.ToLower().Contains(filter.Text));
                }

                var list = query.Select(m => new ContractTypeModel()
                {
                    Id = m.Id,
                    Code = m.Code,
                    Name = m.Name,
                    Description = m.Description,
                    AllowInsurrance = m.AllowInsurrance,
                    AllowLeaveDate = m.AllowLeaveDate,
                    IsActive = m.IsActive,
                    CreateBy = m.CreateBy.ToString(),
                    CreateDate = m.CreateDate
                }).OrderBy(m => m.CreateDate);

                BaseListModel<ContractTypeModel> listItems = new BaseListModel<ContractTypeModel>();
                listItems.TotalItems = await _context.ContractTypeRepository.Query().CountAsync();
                listItems.Items = await list.Skip(filter.Paging.PageIndex * filter.Paging.PageSize).Take(filter.Paging.PageSize).ToListAsync().ConfigureAwait(false);

                response.Result = listItems;
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
                ContractType md = await _context.ContractTypeRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                ContractTypeModel model = new ContractTypeModel()
                {
                    Id = md.Id,
                    Code = md.Code,
                    Name = md.Name,
                    Description = md.Description,
                    AllowLeaveDate = md.AllowLeaveDate,
                    AllowInsurrance = md.AllowInsurrance,
                    IsActive = md.IsActive,
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

        public async Task<ResponseModel> Save(ContractTypeModel model)
        {
            ResponseModel response = new ResponseModel();
            switch (model.Action)
            {
                case Core.CommonModel.Enums.FormActionStatus.Insert:
                    response = await Insert(model);
                    break;
                case Core.CommonModel.Enums.FormActionStatus.Update:
                    response = await Update(model);
                    break;
                case Core.CommonModel.Enums.FormActionStatus.Delete:
                    response = await Delete(model);
                    break;
            }
            return response;
        }


        private async Task<ResponseModel> Insert(ContractTypeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ContractType md = new ContractType();

                md.Code = model.Code;
                md.Name = model.Name;
                md.Description = model.Description;
                md.AllowInsurrance = model.AllowInsurrance;
                md.AllowLeaveDate = model.AllowLeaveDate;
                md.IsActive = model.IsActive;
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;

                await _context.ContractTypeRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Update(ContractTypeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ContractType md = await _context.ContractTypeRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Code = model.Code;
                md.Name = model.Name;
                md.Description = model.Description;
                md.AllowInsurrance = model.AllowInsurrance;
                md.AllowLeaveDate = model.AllowLeaveDate;
                md.IsActive = model.IsActive;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.ContractTypeRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Delete(ContractTypeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ContractType md = await _context.ContractTypeRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.ContractTypeRepository.Update(md);

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
