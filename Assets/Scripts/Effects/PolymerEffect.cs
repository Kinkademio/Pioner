using UnityEngine;

public class PolymerEffect : Effect
{
    public override Effect Synergy(Effect effect)
    {
        PolymerEffect synergy = new PolymerEffect();

        if (effect.GetType().Name == typeof(FireEffect).Name)
        {
            synergy.damage *= effect.GetDamage() * 2;
            synergy.duration /= 2;
        }
        if (effect.GetType().Name == typeof(ElectroEffect).Name)
        {
            synergy.damage *= effect.GetDamage() * 3;
            synergy.duration = 0;
        }
        return synergy;
    }

}
