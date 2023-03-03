public class ElectroEffect : Effect
{
    public ElectroEffect()
    {
        this.damage = 2;
        this.duration = 0f;
        this.procTime = 0f;
    }

    public override void Synergy(Effect effect)
    {

        if (effect.GetType().Name == typeof(PolymerEffect).Name)
        {
            this.damage *= 4;
            this.duration = 2.0f;
            this.procTime = 0.1f;
        }
        if (effect.GetType().Name == typeof(FireEffect).Name)
        {
            this.damage *= 2;
        }
    }
}
