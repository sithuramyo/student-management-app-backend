namespace Cores.Features.Services;

public interface IServiceWrapper<TResponse, in TCreate, in TUpdate>
{
    Task<ApiResponse<PaginationResponse<TResponse>>> ListAsync(PaginationRequest request);
    Task<ApiResponse<NoResponseModel>> CreateAsync(TCreate request);
    Task<ApiResponse<TResponse>> GetByIdAsync(string id);
    Task<ApiResponse<NoResponseModel>> UpdateAsync(string id, TUpdate request);
    Task<ApiResponse<NoResponseModel>> DeleteAsync(string id);
}