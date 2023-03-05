using UnityEngine;

public class ElectroEffect : Effect
{
    public override Effect Synergy(Effect effect)
    {
        ElectroEffect synergyEffect = new ElectroEffect();

        if (effect.GetType().Name == typeof(PolymerEffect).Name)
        {
            synergyEffect.damage *= 4;
            synergyEffect.duration = 2.0f;
            synergyEffect.procTime = 0.1f;
        }
        if (effect.GetType().Name == typeof(FireEffect).Name)
        {
            synergyEffect.damage *= 2;
            
        }
        return synergyEffect;
    }
}
