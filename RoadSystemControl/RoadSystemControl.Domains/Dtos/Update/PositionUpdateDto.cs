namespace RoadSystemControl.Domains.Dtos.Update;

public class PositionUpdateDto : IUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}