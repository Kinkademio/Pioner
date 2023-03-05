using UnityEngine;
public class FireEffect : Effect
{
    public override Effect Synergy(Effect effect)
    {
        FireEffect synergyEffect = new FireEffect();
        if (effect.GetType().Name == typeof(PolymerEffect).Name)
        {
            synergyEffect.damage *= 2;
            synergyEffect.duration /= 2;
        }
        if (effect.GetType().Name == typeof(ElectroEffect).Name)
        {
            synergyEffect.damage *= 2;
        }
        return synergyEffect;
    }
}
