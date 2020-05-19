using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Core.Utility.Extensions;
using Database.Sql.Gym;
using Database.Sql.Gym.Enitties;
using Service.Gym.Interfaces;
using Service.Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Gym
{
    public class ExerciseService : IExerciseService
    {
        private readonly IGymUnitOfWork _context;
        public ExerciseService(IGymUnitOfWork context)
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

            var query = _context.ExerciseRepository.Query().Where(m => m.Deleted == false);

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

        public async Task<ResponseModel> Create(ExerciseModel model)
        {
            var response = new ResponseModel();

            if (model == null)
            {
                throw new NullParameterException();
            }

            await _context.ExerciseRepository.AddAsync(new Exercise()
            {
                Id = Guid.NewGuid(),
                MainMuscleId = new Guid(model.MainMuscleId),
                SecondaryMuscleIds = model.SecondaryMuscleIds,
                Name = model.Name,
                Description = model.Description,
                Notes = model.Notes,
                HardLevel = model.HardLevel,
                Precedence = model.Precedence,
                IsActive = model.IsActive,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now
            });

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return response;
        }

        public async Task<ResponseModel> Edit(ExerciseModel model)
        {
            var response = new ResponseModel();

            if (model == null)
            {
                throw new NullParameterException();
            }

            var item = await _context.ExerciseRepository.FirstOrDefaultAsync(m => m.Id == new Guid(model.Id)).ConfigureAwait(true);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            item.Name = model.Name;
            item.MainMuscleId = new Guid(model.MainMuscleId);
            item.SecondaryMuscleIds = model.SecondaryMuscleIds;
            item.Description = model.Description;
            item.Notes = model.Notes;
            item.HardLevel = model.HardLevel;
            item.Precedence = model.Precedence;
            item.IsActive = model.IsActive;
            item.UpdatedBy = model.UpdatedBy;
            item.UpdatedDate = DateTime.Now;

            _context.ExerciseRepository.Update(item);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return response;
        }

        public async Task<ResponseModel> Delete(ExerciseModel model)
        {
            var response = new ResponseModel();

            if (model == null)
            {
                throw new NullParameterException();
            }

            var item = await _context.ExerciseRepository.FirstOrDefaultAsync(m => m.Id == new Guid(model.Id)).ConfigureAwait(true);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            item.Deleted = true;
            item.DeletedBy = model.UpdatedBy;
            item.DeletedDate = DateTime.Now;

            _context.ExerciseRepository.Update(item);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return response;
        }
    }
}
