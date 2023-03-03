public class PolymerEffect : Effect
{
    public PolymerEffect()
    {
        this.damage = 0;
        this.duration = 5.0f;
        this.procTime = 0.5f;
    }
    public override void Synergy(Effect effect)
    {
        if (effect.GetType().Name == typeof(FireEffect).Name)
        {
            this.damage *= effect.GetDamage() * 2;
            this.duration /= 2;
        }
        if (effect.GetType().Name == typeof(ElectroEffect).Name)
        {
            this.damage *= effect.GetDamage() * 3;
            this.duration = 0;
        }
    }

}
