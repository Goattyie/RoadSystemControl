namespace RoadSystemControl.Domains.Dtos.Update;

public class LocationUpdateDto : IUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}