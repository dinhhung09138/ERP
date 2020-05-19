using Core.CommonMessage;
using Core.CommonModel;
using Database.Sql.Gym;
using Service.Gym.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utility.Extensions;
using Service.Gym.Models;
using Database.Sql.Gym.Enitties;
using Core.CommonModel.Exceptions;

namespace Service.Gym
{
    public class MuscleService : IMuscleService
    {
        private readonly IGymUnitOfWork _context;
        public MuscleService(IGymUnitOfWork context)
        {
            _context = context;
        }

        public async Task<ResponseModel> List(FilterModel filter)
        {
            var response = new ResponseModel();

            if (filter == null)
            {
                throw new NullParameterException();
            }

            var query = _context.MuscleRepository.Query().Where(m => m.Deleted == false);

            if (!string.IsNullOrEmpty(filter.Text))
            {
                query = query.Where(m => m.Name.ToLower().Contains(filter.Text));
            }

            if(filter.Sort != null)
            {
                query = query.SortBy(filter.Sort);
            }
            else
            {
                query = query.OrderBy(m => m.Precedence);
            }

            response.Result = await query.ToBaseList(filter.Paging?.PageIndex, filter.Paging?.PageSize).ConfigureAwait(false);

            return response;
        }

        public async Task<ResponseModel> Create(MuscleModel model)
        {
            var response = new ResponseModel();

            if (model == null)
            {
                throw new NullParameterException();
            }

            await _context.MuscleRepository.AddAsync(new Muscle()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Image = model.Image,
                Precedence = model.Precedence,
                IsActive = model.IsActive,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now
            });
            
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return response;
        }

        public async Task<ResponseModel> Edit(MuscleModel model)
        {
            var response = new ResponseModel();

            if (model == null)
            {
                throw new NullParameterException();
            }

            var item = await _context.MuscleRepository.FirstOrDefaultAsync(m => m.Id == new Guid(model.Id)).ConfigureAwait(true);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            item.Name = model.Name;
            item.Image = model.Image;
            item.Precedence = model.Precedence;
            item.IsActive = model.IsActive;
            item.UpdatedBy = model.UpdatedBy;
            item.UpdatedDate = DateTime.Now;

            _context.MuscleRepository.Update(item);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return response;
        }

        public async Task<ResponseModel> Delete(MuscleModel model)
        {
            var response = new ResponseModel();

            if (model == null)
            {
                throw new NullParameterException();
            }

            var item = await _context.MuscleRepository.FirstOrDefaultAsync(m => m.Id == new Guid(model.Id)).ConfigureAwait(true);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            item.Deleted = true;
            item.DeletedBy = model.UpdatedBy;
            item.DeletedDate = DateTime.Now;

            _context.MuscleRepository.Update(item);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return response;
        }
    }
}
