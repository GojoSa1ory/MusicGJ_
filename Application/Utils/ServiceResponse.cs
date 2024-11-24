using Microsoft.AspNetCore.Authorization;

namespace MusicG.Domain;

public class ServiceResponse<I, E>
{
    private readonly I _data;
    private readonly E _error;

    private ServiceResponse(I data, E error)
    {
        _data = data;
        _error = error;
    }

    public static ServiceResponse<I, E> Success(I data) => new ServiceResponse<I, E>(data, default(E));
    public static ServiceResponse<I, E> Failure(E error) => new ServiceResponse<I, E>(default(I), error);
    
    public bool IsSuccess => _data != null;
    public bool IsFailure => _error != null;
    
    public I DataOrNull => _data;
    public E ErrorOrNull => _error;

    public ServiceResponse<I, E> OnSuccess(Action<I> action)
    {
        if (IsSuccess)
        {
            action(_data);
        }

        return this;
    }

    public ServiceResponse<I, E> OnError(Action<E> action)
    {
        if (IsFailure)
        {
            action(_error);
        }

        return this;
    }
}