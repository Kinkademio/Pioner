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
     * �������� ������ ����
     */
    public GameObject GetBulletPrefab()
    {
        return this.bulletPrefab;
    }

    /**
     * ������� ������ �������
     */
    public Sprite GetIcon()
    {
        return this.icon;
    }
    /**
     * ��������� ������������ �������
     */
    public float GetDuration()
    {
        return this.duration;
    }

    /**
     * ��������� ������������ �������
     */
    public void SetDuration(float duration)
    {
        this.duration = duration;
    }

    /**
     * ��������� ����� �������
     */
    public int GetDamage()
    {
        return this.damage;
    }

    /**
     * ��������� ����� �������
     */
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }


    /**
     * ����������� �������� ����� ������ ����� �� �������
     */
    public float GetProcTime()
    {
        return this.procTime;
    }

    /**
    * ������������ �������� ����� ������ ����� �� �������
    */
    public void SetProcTime(float procTime)
    {
        this.procTime = procTime;
    }

    /**
     * �������� ��������
     */
    public abstract Effect Synergy(Effect effect);
}
