﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Training;
using Service.Training.Interfaces;

namespace API.Training
{
    public static class TrainingBuilderExtension
    {
        public static IServiceCollection AddTrainingServices(this IServiceCollection services, IConfiguration config)
        {
            //// DI services
            services.AddScoped<IAppraiseAnswerService, AppraiseAnswerService>();
            services.AddScoped<IAppraiseQuestionService, AppraiseQuestionService>();
            services.AddScoped<IAppraiseSectionService, AppraiseSectionService>();
            services.AddScoped<IAppraiseService, AppraiseService>();
            services.AddScoped<ILecturerService, LecturerService>();
            services.AddScoped<ISpecializedTrainingService, SpecializedTrainingService>();
            services.AddScoped<ITrainingCenterContactService, TrainingCenterContactService>();
            services.AddScoped<ITrainingCenterService, TrainingCenterService>();
            services.AddScoped<ITrainingCourseDocumentService, TrainingCourseDocumentService>();
            services.AddScoped<ITrainingCourseService, TrainingCourseService>();
            services.AddScoped<ITrainingTypeService, TrainingTypeService>();
            return services;
        }
    }
}
