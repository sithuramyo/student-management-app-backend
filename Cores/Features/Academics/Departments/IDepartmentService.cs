using Cores.Features.Services;
using Shares.Models.Academics.Departments;
using Shares.Models.ApiModels;
using Shares.Models.Paginations;

namespace Cores.Features.Academics.Departments;

public interface IDepartmentService : IServiceWrapper<DepartmentResponseModel, CreateDepartmentRequestModel, UpdateDepartmentRequestModel> { }