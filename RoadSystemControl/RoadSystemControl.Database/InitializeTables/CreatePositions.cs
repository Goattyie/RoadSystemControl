using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.Database.InitializeTables;

public class CreatePositions
{
    public static void Init(RscContext dbContext)
    {
        var entity1 = new Position {Name = "Сержант"};
        var entity2 = new Position {Name = "Рядовой"};
        var entity3 = new Position {Name = "Лейтенант"};
        var entity4 = new Position {Name = "Майор"};
        var entity5 = new Position {Name = "Прапорщик"};
        var entity6 = new Position {Name = "Офицер"};
        var entity7 = new Position {Name = "Генерал"};
        var entity8 = new Position {Name = "Подполковник"};

        dbContext.Positions.Add(entity1);
        dbContext.Positions.Add(entity2);
        dbContext.Positions.Add(entity3);
        dbContext.Positions.Add(entity4);
        dbContext.Positions.Add(entity5);
        dbContext.Positions.Add(entity6);
        dbContext.Positions.Add(entity7);
        dbContext.Positions.Add(entity8);

        dbContext.SaveChanges();
    }
}