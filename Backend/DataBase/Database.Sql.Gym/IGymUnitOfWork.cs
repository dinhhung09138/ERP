using Core.DataAccess;
using Database.Sql.Gym.Enitties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.Gym
{
    public interface IGymUnitOfWork : IGenericUnitOfWork
    {
        /// <summary>
        /// Muscle table repository.
        /// </summary>
        ITableGenericRepository<Muscle> MuscleRepository { get; }

        /// <summary>
        /// Exercise table repository.
        /// </summary>
        ITableGenericRepository<Exercise> ExerciseRepository { get; }

        /// <summary>
        /// Exercise Level table repository.
        /// </summary>
        ITableGenericRepository<ExerciseLevel> ExerciseLevelRepository { get; }

        /// <summary>
        /// Exercise Resource table repository.
        /// </summary>
        ITableGenericRepository<ExerciseResource> ExerciseResourceRepository { get; }

    }
}
