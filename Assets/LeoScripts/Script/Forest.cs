public class Forest : Case
{
    public Forest(int x, int y) : base(x, y)
    {
    }

    public override void ApplyEffect() {
        Wet();
        // Update le slider de Tom ici
    }
}