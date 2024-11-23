namespace MusicG.Domain;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public String Err { get; set; } = "";

    public bool IsSuccess => Err == "";
}