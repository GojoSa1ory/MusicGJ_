using MusicG.Application.User.DTO;
using MusicG.Domain.User;

namespace MusicG.Application.Auth.DTO;

public class ResponseAuthDto
{
    public ResponseUserDto User { get; set; }
    public string Token { get; set; }
}