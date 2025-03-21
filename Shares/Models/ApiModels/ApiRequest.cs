namespace Shares.Models.ApiModels;

public class ApiRequest<T>
{
    public T Request { get; set; } = default!;
}