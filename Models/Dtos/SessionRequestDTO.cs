using ObiletApp.Models.Dtos.Shared;

namespace ObiletApp.Models.Dtos;

public class SessionRequestDTO
{
    public int Type { get; set; }
    public Connection? Connection { get; set; }
    public Browser? Browser { get; set; }
}


