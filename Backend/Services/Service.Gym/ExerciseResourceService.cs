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
    public class ExerciseResourceService : IExerciseResourceService
    {
        private readonly IGymUnitOfWork _context;
        public ExerciseResourceService(IGymUnitOfWork context)
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

            var query = _context.ExerciseResourceRepository.Query().Where(m => m.Deleted == false);

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

        public async Task<ResponseModel> Create(ExerciseResourceModel model)
        {
            var response = new ResponseModel();

            if (model == null)
            {
                throw new NullParameterException();
            }

            await _context.ExerciseResourceRepository.AddAsync(new ExerciseResource()
            {
                Id = Guid.NewGuid(),
                ExerciseId = new Guid(model.ExerciseId),
                Video = model.Video,
                Image = model.Image,
                Description = model.Description,
                Notes = model.Notes,
                IsVideo = model.IsVideo,
                Precedence = model.Precedence,
                IsActive = model.IsActive,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now
            });

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return response;
        }

        public async Task<ResponseModel> Edit(ExerciseResourceModel model)
        {
            var response = new ResponseModel();

            if (model == null)
            {
                throw new NullParameterException();
            }

            var item = await _context.ExerciseResourceRepository.FirstOrDefaultAsync(m => m.Id == new Guid(model.Id)).ConfigureAwait(true);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            item.ExerciseId = new Guid(model.ExerciseId);
            item.Video = model.Video;
            item.Image = model.Image;
            item.Description = model.Description;
            item.Notes = model.Notes;
            item.IsVideo = model.IsVideo;
            item.Precedence = model.Precedence;
            item.IsActive = model.IsActive;
            item.UpdatedBy = model.UpdatedBy;
            item.UpdatedDate = DateTime.Now;

            _context.ExerciseResourceRepository.Update(item);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return response;
        }

        public async Task<ResponseModel> Delete(ExerciseResourceModel model)
        {
            var response = new ResponseModel();

            if (model == null)
            {
                throw new NullParameterException();
            }

            var item = await _context.ExerciseResourceRepository.FirstOrDefaultAsync(m => m.Id == new Guid(model.Id)).ConfigureAwait(true);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            item.Deleted = true;
            item.DeletedBy = model.UpdatedBy;
            item.DeletedDate = DateTime.Now;

            _context.ExerciseResourceRepository.Update(item);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return response;
        }
    }
}
