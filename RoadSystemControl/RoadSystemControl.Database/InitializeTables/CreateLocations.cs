using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.Database.InitializeTables;

public class CreateLocations
{
    public static void Init(RscContext dbContext)
    {
        var location1 = new Location {Name = "Ленинский проспект"};
        var location2 = new Location {Name = "Остановка 'Гурова'"};
        var location3 = new Location {Name = "Парк Щербакова"};
        var location4 = new Location {Name = "Бульвар Пушкина"};
        var location5 = new Location {Name = "Улица Синицина"};
        var location6 = new Location {Name = "Бакинские"};
        var location7 = new Location {Name = "Проспект им. Авина"};
        var location8 = new Location {Name = "Зоопарк 'Живо'"};
        var location9 = new Location {Name = "Кировская фильтровальная станция"};
        var location10 = new Location {Name = "Футбольный клуб 'Победа'"};

        dbContext.Locations.Add(location1);
        dbContext.Locations.Add(location2);
        dbContext.Locations.Add(location3);
        dbContext.Locations.Add(location4);
        dbContext.Locations.Add(location5);
        dbContext.Locations.Add(location6);
        dbContext.Locations.Add(location7);
        dbContext.Locations.Add(location8);
        dbContext.Locations.Add(location9);
        dbContext.Locations.Add(location10);

        dbContext.SaveChanges();
    }
}