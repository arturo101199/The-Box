public class WallEvent : GameEvent
{
    Direction wall;
    bool open;
    WallsController wallsController;

    public WallEvent(Direction wall, bool open, WallsController wallsController)
    {
        this.wall = wall;
        this.open = open;
        this.wallsController = wallsController;
    }

    public override void doEvent()
    {
        if (open) wallsController.OpenWall(wall);
        else wallsController.CloseWall(wall);
    }
}