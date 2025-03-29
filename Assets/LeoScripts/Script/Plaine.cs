public class Plaine : Case {
    public Plaine(int x, int y) : base(x, y)
    {
    }

    public override void ApplyEffect() {
        Wet();
    }
}