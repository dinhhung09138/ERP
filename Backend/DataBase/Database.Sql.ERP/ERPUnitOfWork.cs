﻿using System;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.DataAccess.Sql;
using Database.Sql.ERP.Entities.Common;
using Database.Sql.ERP.Entities.HR;
using Database.Sql.ERP.Entities.Security;
using Database.Sql.ERP.Entities.Training;
using Microsoft.EntityFrameworkCore.Storage;

namespace Database.Sql.ERP
{
    public class ERPUnitOfWork : IERPUnitOfWork, IDisposable
    {
        private readonly ERPContext _context;

        private IDbContextTransaction _transaction;

        #region " [ Common ] "

        private ITableGenericRepository<Certificated> _certificatedRepository;
        public ITableGenericRepository<Certificated> CertificatedRepository
        {
            get
            {
                return _certificatedRepository = _certificatedRepository ?? new TableGenericRepository<Certificated>(_context);
            }
        }

        private ITableGenericRepository<School> _schoolRepository;
        public ITableGenericRepository<School> SchoolRepository
        {
            get
            {
                return _schoolRepository = _schoolRepository ?? new TableGenericRepository<School>(_context);
            }
        }

        private ITableGenericRepository<District> _districtRepository;
        public ITableGenericRepository<District> DistrictRepository
        {
            get
            {
                return _districtRepository = _districtRepository ?? new TableGenericRepository<District>(_context);
            }
        }

        private ITableGenericRepository<Major> _majorRepository;
        public ITableGenericRepository<Major> MajorRepository
        {
            get
            {
                return _majorRepository = _majorRepository ?? new TableGenericRepository<Major>(_context);
            }
        }

        private ITableGenericRepository<ProfessionalQualification> _professionalQualificationRepository;
        public ITableGenericRepository<ProfessionalQualification> ProfessionalQualificationRepository
        {
            get
            {
                return _professionalQualificationRepository = _professionalQualificationRepository ?? new TableGenericRepository<ProfessionalQualification>(_context);
            }
        }

        private ITableGenericRepository<Province> _provinceRepository;
        public ITableGenericRepository<Province> ProvinceRepository
        {
            get
            {
                return _provinceRepository = _provinceRepository ?? new TableGenericRepository<Province>(_context);
            }
        }

        private ITableGenericRepository<Ward> _wardRepository;
        public ITableGenericRepository<Ward> WardRepository
        {
            get
            {
                return _wardRepository = _wardRepository ?? new TableGenericRepository<Ward>(_context);
            }
        }

        private ITableGenericRepository<File> _fileRepository;
        public ITableGenericRepository<File> FileRepository
        {
            get
            {
                return _fileRepository = _fileRepository ?? new TableGenericRepository<File>(_context);
            }
        }

        private ITableGenericRepository<CommonCodeType> _codeTypeRepository;
        public ITableGenericRepository<CommonCodeType> CodeTypeRepository
        {
            get
            {
                return _codeTypeRepository = _codeTypeRepository ?? new TableGenericRepository<CommonCodeType>(_context);
            }
        }

        private ITableGenericRepository<CommonCode> _codeRepository;
        public ITableGenericRepository<CommonCode> CodeRepository
        {
            get
            {
                return _codeRepository = _codeRepository ?? new TableGenericRepository<CommonCode>(_context);
            }
        }

        private ITableGenericRepository<MaritalStatus> _maritalStatusRepository;
        public ITableGenericRepository<MaritalStatus> MaritalStatusRepository
        {
            get
            {
                return _maritalStatusRepository = _maritalStatusRepository ?? new TableGenericRepository<MaritalStatus>(_context);
            }
        }

        #endregion

        #region " [ HR ] "

        private ITableGenericRepository<ApproveStatus> _approveStatusRepository;
        public ITableGenericRepository<ApproveStatus> ApproveStatusRepository
        {
            get
            {
                return _approveStatusRepository = _approveStatusRepository ?? new TableGenericRepository<ApproveStatus>(_context);
            }
        }

        private ITableGenericRepository<Bank> _bankRepository;
        public ITableGenericRepository<Bank> BankRepository
        {
            get
            {
                return _bankRepository = _bankRepository ?? new TableGenericRepository<Bank>(_context);
            }
        }

        private ITableGenericRepository<Commendation> _commendationRepository;
        public ITableGenericRepository<Commendation> CommendationRepository
        {
            get
            {
                return _commendationRepository = _commendationRepository ?? new TableGenericRepository<Commendation>(_context);
            }
        }

        private ITableGenericRepository<ContractType> _contractTypeRepository;
        public ITableGenericRepository<ContractType> ContractTypeRepository
        {
            get
            {
                return _contractTypeRepository = _contractTypeRepository ?? new TableGenericRepository<ContractType>(_context);
            }
        }

        private ITableGenericRepository<Discipline> _disciplineRepository;
        public ITableGenericRepository<Discipline> DisciplineRepository
        {
            get
            {
                return _disciplineRepository = _disciplineRepository ?? new TableGenericRepository<Discipline>(_context);
            }
        }

        private ITableGenericRepository<Education> _educationRepository;
        public ITableGenericRepository<Education> EducationRepository
        {
            get
            {
                return _educationRepository = _educationRepository ?? new TableGenericRepository<Education>(_context);
            }
        }

        private ITableGenericRepository<Employee> _employeeRepository;
        public ITableGenericRepository<Employee> EmployeeRepository
        {
            get
            {
                return _employeeRepository = _employeeRepository ?? new TableGenericRepository<Employee>(_context);
            }
        }

        private ITableGenericRepository<EmployeeCommendation> _employeeCommendationRepository;
        public ITableGenericRepository<EmployeeCommendation> EmployeeCommendationRepository
        {
            get
            {
                return _employeeCommendationRepository = _employeeCommendationRepository ?? new TableGenericRepository<EmployeeCommendation>(_context);
            }
        }

        private ITableGenericRepository<EmployeeBank> _employeeBankRepository;
        public ITableGenericRepository<EmployeeBank> EmployeeBankRepository
        {
            get
            {
                return _employeeBankRepository = _employeeBankRepository ?? new TableGenericRepository<EmployeeBank>(_context);
            }
        }

        private ITableGenericRepository<EmployeeContact> _employeeContactRepository;
        public ITableGenericRepository<EmployeeContact> EmployeeContactRepository
        {
            get
            {
                return _employeeContactRepository = _employeeContactRepository ?? new TableGenericRepository<EmployeeContact>(_context);
            }
        }

        private ITableGenericRepository<EmployeeContract> _employeeContractRepository;
        public ITableGenericRepository<EmployeeContract> EmployeeContractRepository
        {
            get
            {
                return _employeeContractRepository = _employeeContractRepository ?? new TableGenericRepository<EmployeeContract>(_context);
            }
        }

        private ITableGenericRepository<EmployeeContractStatusHistory> _employeeContractStatusHistoryRepository;
        public ITableGenericRepository<EmployeeContractStatusHistory> EmployeeContractStatusHistoryRepository
        {
            get
            {
                return _employeeContractStatusHistoryRepository = _employeeContractStatusHistoryRepository ?? new TableGenericRepository<EmployeeContractStatusHistory>(_context);
            }
        }
        
        private ITableGenericRepository<EmployeeDiscipline> _employeeDisciplineRepository;
        public ITableGenericRepository<EmployeeDiscipline> EmployeeDisciplineRepository
        {
            get
            {
                return _employeeDisciplineRepository = _employeeDisciplineRepository ?? new TableGenericRepository<EmployeeDiscipline>(_context);
            }
        }

        private ITableGenericRepository<EmployeeDependency> _employeeDependencyRepository;
        public ITableGenericRepository<EmployeeDependency> EmployeeDependencyRepository
        {
            get
            {
                return _employeeDependencyRepository = _employeeDependencyRepository ?? new TableGenericRepository<EmployeeDependency>(_context);
            }
        }

        private ITableGenericRepository<EmployeeEducation> _employeeEducationRepository;
        public ITableGenericRepository<EmployeeEducation> EmployeeEducationRepository
        {
            get
            {
                return _employeeEducationRepository = _employeeEducationRepository ?? new TableGenericRepository<EmployeeEducation>(_context);
            }
        }

        private ITableGenericRepository<EmployeeCertificate> _employeeCertificateRepository;
        public ITableGenericRepository<EmployeeCertificate> EmployeeCertificateRepository
        {
            get
            {
                return _employeeCertificateRepository = _employeeCertificateRepository ?? new TableGenericRepository<EmployeeCertificate>(_context);
            }
        }

        private ITableGenericRepository<EmployeeIdentification> _employeeIdentificationRepository;
        public ITableGenericRepository<EmployeeIdentification> EmployeeIdentificationRepository
        {
            get
            {
                return _employeeIdentificationRepository = _employeeIdentificationRepository ?? new TableGenericRepository<EmployeeIdentification>(_context);
            }
        }

        private ITableGenericRepository<EmployeeInfo> _employeeInfoRepository;
        public ITableGenericRepository<EmployeeInfo> EmployeeInfoRepository
        {
            get
            {
                return _employeeInfoRepository = _employeeInfoRepository ?? new TableGenericRepository<EmployeeInfo>(_context);
            }
        }

        private ITableGenericRepository<EmployeeLeave> _employeeLeaveRepository;
        public ITableGenericRepository<EmployeeLeave> EmployeeLeaveRepository
        {
            get
            {
                return _employeeLeaveRepository = _employeeLeaveRepository ?? new TableGenericRepository<EmployeeLeave>(_context);
            }
        }


        private ITableGenericRepository<EmployeeLeaveConfiguration> _employeeLeaveConfigurationRepository;
        public ITableGenericRepository<EmployeeLeaveConfiguration> EmployeeLeaveConfigurationRepository
        {
            get
            {
                return _employeeLeaveConfigurationRepository = _employeeLeaveConfigurationRepository ?? new TableGenericRepository<EmployeeLeaveConfiguration>(_context);
            }
        }

        private ITableGenericRepository<EmployeeLeaveStatus> _employeeLeaveStatusRepository;
        public ITableGenericRepository<EmployeeLeaveStatus> EmployeeLeaveStatusRepository
        {
            get
            {
                return _employeeLeaveStatusRepository = _employeeLeaveStatusRepository ?? new TableGenericRepository<EmployeeLeaveStatus>(_context);
            }
        }

        private ITableGenericRepository<EmployeeRelationship> _employeeRelationshipRepository;
        public ITableGenericRepository<EmployeeRelationship> EmployeeRelationshipRepository
        {
            get
            {
                return _employeeRelationshipRepository = _employeeRelationshipRepository ?? new TableGenericRepository<EmployeeRelationship>(_context);
            }
        }

        private ITableGenericRepository<EmployeeWorkingStatus> _employeeWorkingStatusRepository;
        public ITableGenericRepository<EmployeeWorkingStatus> EmployeeWorkingStatusRepository
        {
            get
            {
                return _employeeWorkingStatusRepository = _employeeWorkingStatusRepository ?? new TableGenericRepository<EmployeeWorkingStatus>(_context);
            }
        }

        private ITableGenericRepository<IdentificationType> _identificationTypeRepository;
        public ITableGenericRepository<IdentificationType> IdentificationTypeRepository
        {
            get
            {
                return _identificationTypeRepository = _identificationTypeRepository ?? new TableGenericRepository<IdentificationType>(_context);
            }
        }

        private ITableGenericRepository<LeaveStatus> _leaveStatusRepository;
        public ITableGenericRepository<LeaveStatus> LeaveStatusRepository
        {
            get
            {
                return _leaveStatusRepository = _leaveStatusRepository ?? new TableGenericRepository<LeaveStatus>(_context);
            }
        }

        private ITableGenericRepository<LeaveType> _leaveTypeRepository;
        public ITableGenericRepository<LeaveType> LeaveTypeRepository
        {
            get
            {
                return _leaveTypeRepository = _leaveTypeRepository ?? new TableGenericRepository<LeaveType>(_context);
            }
        }

        private ITableGenericRepository<ModelOfStudy> _modelOfStudyRepository;
        public ITableGenericRepository<ModelOfStudy> ModelOfStudyRepository
        {
            get
            {
                return _modelOfStudyRepository = _modelOfStudyRepository ?? new TableGenericRepository<ModelOfStudy>(_context);
            }
        }

        private ITableGenericRepository<Ethnicity> _nationRepository;
        public ITableGenericRepository<Ethnicity> NationRepository
        {
            get
            {
                return _nationRepository = _nationRepository ?? new TableGenericRepository<Ethnicity>(_context);
            }
        }

        private ITableGenericRepository<Nationality> _nationalityRepository;
        public ITableGenericRepository<Nationality> NationalityRepository
        {
            get
            {
                return _nationalityRepository = _nationalityRepository ?? new TableGenericRepository<Nationality>(_context);
            }
        }

        private ITableGenericRepository<Ranking> _rankingRepository;
        public ITableGenericRepository<Ranking> RankingRepository
        {
            get
            {
                return _rankingRepository = _rankingRepository ?? new TableGenericRepository<Ranking>(_context);
            }
        }

        private ITableGenericRepository<RelationshipType> _relationshipTypeRepository;
        public ITableGenericRepository<RelationshipType> RelationshipTypeRepository
        {
            get
            {
                return _relationshipTypeRepository = _relationshipTypeRepository ?? new TableGenericRepository<RelationshipType>(_context);
            }
        }

        private ITableGenericRepository<Position> _positionRepository;
        public ITableGenericRepository<Position> PositionRepository
        {
            get
            {
                return _positionRepository = _positionRepository ?? new TableGenericRepository<Position>(_context);
            }
        }

        private ITableGenericRepository<Religion> _religionRepository;
        public ITableGenericRepository<Religion> ReligionRepository
        {
            get
            {
                return _religionRepository = _religionRepository ?? new TableGenericRepository<Religion>(_context);
            }
        }

        #endregion

        #region " [ Training ] "

        private ITableGenericRepository<Appraise> _appraiseRepository;
        public ITableGenericRepository<Appraise> AppraiseRepository
        {
            get
            {
                return _appraiseRepository = _appraiseRepository ?? new TableGenericRepository<Appraise>(_context);
            }
        }

        private ITableGenericRepository<AppraiseAnswer> _appraiseAnswerRepository;
        public ITableGenericRepository<AppraiseAnswer> AppraiseAnswerRepository
        {
            get
            {
                return _appraiseAnswerRepository = _appraiseAnswerRepository ?? new TableGenericRepository<AppraiseAnswer>(_context);
            }
        }

        private ITableGenericRepository<AppraiseQuestion> _appraiseQuestionRepository;
        public ITableGenericRepository<AppraiseQuestion> AppraiseQuestionRepository
        {
            get
            {
                return _appraiseQuestionRepository = _appraiseQuestionRepository ?? new TableGenericRepository<AppraiseQuestion>(_context);
            }
        }

        private ITableGenericRepository<AppraiseSection> _appraiseSectionRepository;
        public ITableGenericRepository<AppraiseSection> AppraiseSectionRepository
        {
            get
            {
                return _appraiseSectionRepository = _appraiseSectionRepository ?? new TableGenericRepository<AppraiseSection>(_context);
            }
        }

        private ITableGenericRepository<Lecturer> _lecturerRepository;
        public ITableGenericRepository<Lecturer> LecturerRepository
        {
            get
            {
                return _lecturerRepository = _lecturerRepository ?? new TableGenericRepository<Lecturer>(_context);
            }
        }

        private ITableGenericRepository<SpecializedTraining> _specializedTrainingRepository;
        public ITableGenericRepository<SpecializedTraining> SpecializedTrainingRepository
        {
            get
            {
                return _specializedTrainingRepository = _specializedTrainingRepository ?? new TableGenericRepository<SpecializedTraining>(_context);
            }
        }

        private ITableGenericRepository<TrainingCenter> _trainingCenterRepository;
        public ITableGenericRepository<TrainingCenter> TrainingCenterRepository
        {
            get
            {
                return _trainingCenterRepository = _trainingCenterRepository ?? new TableGenericRepository<TrainingCenter>(_context);
            }
        }

        private ITableGenericRepository<TrainingCenterContact> _trainingCenterContactRepository;
        public ITableGenericRepository<TrainingCenterContact> TrainingCenterContactRepository
        {
            get
            {
                return _trainingCenterContactRepository = _trainingCenterContactRepository ?? new TableGenericRepository<TrainingCenterContact>(_context);
            }
        }

        private ITableGenericRepository<TrainingCourse> _trainingCourseRepository;
        public ITableGenericRepository<TrainingCourse> TrainingCourseRepository
        {
            get
            {
                return _trainingCourseRepository = _trainingCourseRepository ?? new TableGenericRepository<TrainingCourse>(_context);
            }
        }

        private ITableGenericRepository<TrainingCourseDocument> _trainingCourseDocumentRepository;
        public ITableGenericRepository<TrainingCourseDocument> TrainingCourseDocumentRepository
        {
            get
            {
                return _trainingCourseDocumentRepository = _trainingCourseDocumentRepository ?? new TableGenericRepository<TrainingCourseDocument>(_context);
            }
        }

        private ITableGenericRepository<TrainingType> _trainingTypeRepository;
        public ITableGenericRepository<TrainingType> TrainingTypeRepository
        {
            get
            {
                return _trainingTypeRepository = _trainingTypeRepository ?? new TableGenericRepository<TrainingType>(_context);
            }
        }

        #endregion

        #region " [ Security ] "

        private ITableGenericRepository<Function> _functionRepository;
        public ITableGenericRepository<Function> FunctionRepository
        {
            get
            {
                return _functionRepository = _functionRepository ?? new TableGenericRepository<Function>(_context);
            }
        }

        private ITableGenericRepository<FunctionCommand> _functionCommandRepository;
        public ITableGenericRepository<FunctionCommand> FunctionCommandRepository
        {
            get
            {
                return _functionCommandRepository = _functionCommandRepository ?? new TableGenericRepository<FunctionCommand>(_context);
            }
        }

        private ITableGenericRepository<Module> _moduleRepository;
        public ITableGenericRepository<Module> ModuleRepository
        {
            get
            {
                return _moduleRepository = _moduleRepository ?? new TableGenericRepository<Module>(_context);
            }
        }

        private ITableGenericRepository<Role> _roleRepository;
        public ITableGenericRepository<Role> RoleRepository
        {
            get
            {
                return _roleRepository = _roleRepository ?? new TableGenericRepository<Role>(_context);
            }
        }

        private ITableGenericRepository<RoleDetail> _roleDetailRepository;
        public ITableGenericRepository<RoleDetail> RoleDetailRepository
        {
            get
            {
                return _roleDetailRepository = _roleDetailRepository ?? new TableGenericRepository<RoleDetail>(_context);
            }
        }

        private ITableGenericRepository<User> _userRepository;
        public ITableGenericRepository<User> UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new TableGenericRepository<User>(_context);
            }
        }

        private ITableGenericRepository<SessionLog> _sesionLogRepository;
        public ITableGenericRepository<SessionLog> SessionLogRepository
        {
            get
            {
                return _sesionLogRepository = _sesionLogRepository ?? new TableGenericRepository<SessionLog>(_context);
            }
        }

        private ITableGenericRepository<SystemLog> _systemLogRepository;
        public ITableGenericRepository<SystemLog> SystemLogRepository
        {
            get
            {
                return _systemLogRepository = _systemLogRepository ?? new TableGenericRepository<SystemLog>(_context);
            }
        }

        private ITableGenericRepository<UserRole> _userRoleRepository;
        public ITableGenericRepository<UserRole> UserRoleRepository
        {
            get
            {
                return _userRoleRepository = _userRoleRepository ?? new TableGenericRepository<UserRole>(_context);
            }
        }

        private ITableGenericRepository<UserModule> _userModuleRepository;
        public ITableGenericRepository<UserModule> UserModuleRepository
        {
            get
            {
                return _userModuleRepository = _userModuleRepository ?? new TableGenericRepository<UserModule>(_context);
            }
        }

        #endregion

        public ERPUnitOfWork(ERPContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync().ConfigureAwait(true);
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
        }

        public async Task CommitTransactionAsync()
        {
            await (_transaction?.CommitAsync()).ConfigureAwait(true);
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
        }

        public async Task RollbackTransactionAsync()
        {
            await (_transaction?.RollbackAsync()).ConfigureAwait(true);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(true);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                }

                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
