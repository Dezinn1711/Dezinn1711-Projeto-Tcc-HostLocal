using HostLocal.API.DTOs;

namespace HostLocal.API.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(UserDto user);
}