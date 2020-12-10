using Core.CommonModel;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.HR;
using Core.Services;
using Microsoft.AspNetCore.Http;

namespace Service.HR
{
    public class EmployeeBankService : BaseService, IEmployeeBankService
    {
        private readonly IERPUnitOfWork _context;

        public EmployeeBankService(
            IERPUnitOfWork context,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> List(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeBankRepository.Query()
                            join b in _context.BankRepository.Query() on m.BankId equals b.Id
                            where !m.Deleted && m.EmployeeId == filter.EmployeeId
                            orderby m.CreateDate
                            select new EmployeeBankModel()
                            {
                                Id = m.Id,
                                BankId = m.BankId,
                                BankName = b.Name,
                                BankAddress = m.BankAddress,
                                AccountNumber = m.AccountNumber,
                                AccountOwner = m.AccountOwner,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.BankName.ToLower().Contains(filter.Text)
                                        || m.BankAddress.ToLower().Contains(filter.Text)
                                        || m.AccountNumber.ToLower().Contains(filter.Text)
                                        || m.AccountOwner.ToLower().Contains(filter.Text));
                }

                BaseListModel<EmployeeBankModel> listItems = new BaseListModel<EmployeeBankModel>();
                listItems.TotalItems = await _context.EmployeeBankRepository.Query().Where(m => !m.Deleted && m.EmployeeId == filter.EmployeeId).CountAsync();
                listItems.Items = await query.Skip(filter.Paging.PageIndex * filter.Paging.PageSize).Take(filter.Paging.PageSize).ToListAsync().ConfigureAwait(false);

                response.Result = listItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeBankRepository.Query()
                            where m.Id == id
                            select new EmployeeBankModel
                            {
                                Id = m.Id,
                                EmployeeId = m.EmployeeId,
                                BankId = m.BankId,
                                BankAddress = m.BankAddress,
                                AccountOwner = m.AccountOwner,
                                AccountNumber = m.AccountNumber,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                response.Result = await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(EmployeeBankModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeBank md = new EmployeeBank();

                md.EmployeeId = model.EmployeeId;
                md.BankId = model.BankId;
                md.BankAddress = model.BankAddress;
                md.AccountNumber = model.AccountNumber;
                md.AccountOwner = model.AccountOwner;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EmployeeBankRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Update(EmployeeBankModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeBank md = await _context.EmployeeBankRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.EmployeeId = model.EmployeeId;
                md.BankId = model.BankId;
                md.BankAddress = model.BankAddress;
                md.AccountNumber = model.AccountNumber;
                md.AccountOwner = model.AccountOwner;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeBankRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(DeleteModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeBank md = await _context.EmployeeBankRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeBankRepository.Update(md);

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
