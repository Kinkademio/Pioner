public abstract class Effect
{
    protected int damage;
    protected float duration;
    protected float procTime;

    /**
     * Получение длительности еффекта
     */
    public float GetDuration()
    {
        return this.duration;
    }

    /**
     * Установка длительности еффекта
     */
    public void SetDuration(float duration)
    {
        this.duration = duration;
    }

    /**
     * Получение урона эффекта
     */
    public int GetDamage()
    {
        return this.damage;
    }

    /**
     * Установка урона эффекта
     */
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }


    /**
     * Возращещает задержку между тиками урона от еффекта
     */
    public float GetProcTime()
    {
        return this.procTime;
    }

    /**
    * Устанавливае задержку между тиками урона от еффекта
    */
    public void SetProcTime(float procTime)
    {
        this.procTime = procTime;
    }

    /**
     * Синергия эффектов
     */
    public abstract void Synergy(Effect effect);
}
