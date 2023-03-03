public class FireEffect : Effect
{
    //Прибъем гвоздями если времени хватит пределаем на Flyweight наверно
    public FireEffect()
    {
        this.damage = 5;
        this.duration = 3.0f;
        this.procTime = 0.5f;
    }

    public override void Synergy(Effect effect)
    {

        if (effect.GetType().Name == typeof(PolymerEffect).Name)
        {
            this.damage *= 2;
            this.duration /= 2;
        }
        if (effect.GetType().Name == typeof(ElectroEffect).Name)
        {
            this.damage *= 2;
        }

    }
}
