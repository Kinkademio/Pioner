using UnityEngine;
using UnityEngine.UI;

public abstract class Effect
{
    protected int damage;
    protected float duration;
    protected float procTime;
    protected Sprite icon;
    protected GameObject bulletPrefab;

    public Effect()
    {
        EffectData data = Resources.Load<EffectData>(this.GetType().Name);
        this.damage = data.GetDamage();
        this.duration = data.GetDuration();
        this.procTime = data.GetProcTime();
        this.icon= data.GetIcon();
        this.bulletPrefab= data.GetBulletPrefab();
    }
    /**
     * Получить префаб пули
     */
    public GameObject GetBulletPrefab()
    {
        return this.bulletPrefab;
    }

    /**
     * Получть иконку эффекта
     */
    public Sprite GetIcon()
    {
        return this.icon;
    }
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
    public abstract Effect Synergy(Effect effect);
}
