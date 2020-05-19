using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Core.Utility.Extensions;
using Database.Sql.Gym;
using Database.Sql.Gym.Enitties;
using Service.Gym.Interfaces;
using Service.Gym.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Gym
{
    public class ExerciseLevelService : IExerciseLevelService
    {
        private readonly IGymUnitOfWork _context;
        public ExerciseLevelService(IGymUnitOfWork context)
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

            var query = _context.ExerciseLevelRepository.Query().Where(m => m.Deleted == false);

            if (!string.IsNullOrEmpty(filter.Text))
            {
                query = query.Where(m => m.Name.ToLower().Contains(filter.Text));
            }

            if (filter.Sort != null)
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

        public async Task<ResponseModel> Create(ExerciseLevelModel model)
        {
            var response = new ResponseModel();

            if (model == null)
            {
                throw new NullParameterException();
            }

            await _context.ExerciseLevelRepository.AddAsync(new ExerciseLevel()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Precedence = model.Precedence,
                IsActive = model.IsActive,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now
            });

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return response;
        }

        public async Task<ResponseModel> Edit(ExerciseLevelModel model)
        {
            var response = new ResponseModel();

            if (model == null)
            {
                throw new NullParameterException();
            }

            var item = await _context.ExerciseLevelRepository.FirstOrDefaultAsync(m => m.Id == new Guid(model.Id)).ConfigureAwait(true);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            item.Name = model.Name;
            item.Precedence = model.Precedence;
            item.IsActive = model.IsActive;
            item.UpdatedBy = model.UpdatedBy;
            item.UpdatedDate = DateTime.Now;

            _context.ExerciseLevelRepository.Update(item);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return response;
        }

        public async Task<ResponseModel> Delete(ExerciseLevelModel model)
        {
            var response = new ResponseModel();

            if (model == null)
            {
                throw new NullParameterException();
            }

            var item = await _context.ExerciseLevelRepository.FirstOrDefaultAsync(m => m.Id == new Guid(model.Id)).ConfigureAwait(true);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            item.Deleted = true;
            item.DeletedBy = model.UpdatedBy;
            item.DeletedDate = DateTime.Now;

            _context.ExerciseLevelRepository.Update(item);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return response;
        }
    }
}
