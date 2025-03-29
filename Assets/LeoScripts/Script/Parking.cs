public class Parking : Case
{
    public Parking(int x, int y) : base(x, y)
    {
    }

    public override void ApplyEffect() {
        Wet();
    }
}