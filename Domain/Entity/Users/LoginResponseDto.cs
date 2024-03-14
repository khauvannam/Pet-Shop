namespace Domain.Entity.Users;

public record LoginResponseDto(string RefreshToken, string AccessToken);
