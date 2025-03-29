public class Forest : Case
{
    public override void ApplyEffect() {
        if (Wet()) {
            Flood();
        } 
        // Update le slider de Tom ici
    }
}