﻿using Core.CommonModel;
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
    public class CommendationService : ICommendationService
    {
        private readonly IHRUnitOfWork _context;
        public CommendationService(IHRUnitOfWork context)
        {
            _context = context;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.CommendationRepository.Query()
                            where !m.Deleted
                            orderby m.CreateDate descending
                            select new CommendationModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Description = m.Description,
                                Money = m.Money,
                                IsActive = m.IsActive
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text) || m.Description.Contains(filter.Text));
                }

                BaseListModel<CommendationModel> listItems = new BaseListModel<CommendationModel>();
                listItems.TotalItems = await _context.CommendationRepository.Query().Where(m => !m.Deleted).CountAsync();
                listItems.Items = await query.Skip(filter.Paging.PageIndex * filter.Paging.PageSize).Take(filter.Paging.PageSize).ToListAsync().ConfigureAwait(false);

                response.Result = listItems;
            }
            catch(Exception ex)
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
                var query = from m in _context.CommendationRepository.Query()
                            where m.IsActive && !m.Deleted
                            orderby m.CreateDate ascending
                            select new CommendationModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Money = m.Money,
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
                Commendation md = await _context.CommendationRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                CommendationModel model = new CommendationModel()
                {
                    Id = md.Id,
                    Name = md.Name,
                    Description = md.Description,
                    IsActive = md.IsActive,
                    Money = md.Money
                };

                response.Result = model;
            }
            catch(Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Save(CommendationModel model)
        {
            ResponseModel response = new ResponseModel();
            switch(model.Action)
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


        private async Task<ResponseModel> Insert(CommendationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Commendation md = new Commendation();

                md.Name = model.Name;
                md.Description = model.Description;
                md.Money = model.Money;
                md.IsActive = model.IsActive;
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.CommendationRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Update(CommendationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Commendation md = await _context.CommendationRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Name = model.Name;
                md.Description = model.Description;
                md.IsActive = model.IsActive;
                md.Money = model.Money;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.CommendationRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Delete(CommendationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Commendation md = await _context.CommendationRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.CommendationRepository.Update(md);

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
