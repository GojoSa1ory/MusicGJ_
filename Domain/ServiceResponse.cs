namespace MusicG.Domain;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public String err { get; set; } = "";

    public bool IsSuccess => err == "";
}