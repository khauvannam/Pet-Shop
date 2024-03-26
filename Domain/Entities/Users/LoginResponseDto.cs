namespace Domain.Entities.Users;

public record LoginResponseDto(string RefreshToken, string AccessToken);
