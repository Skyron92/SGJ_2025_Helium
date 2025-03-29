public class Plaine : Case {
    
    public override void ApplyEffect() {
        if (Wet()) {
            Flood();
        }
    }
}