namespace Dto;

public class TokenDto
{
    public string Access_token { get; set; } = null!;
    public string Token_type { get; set; } = null!;
    public int Expires_in { get; set; }
}
