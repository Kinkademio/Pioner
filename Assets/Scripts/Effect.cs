public abstract class Effect
{
    protected int damage;
    protected float duration;
    protected float procTime;

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
    public abstract void Synergy(Effect effect);
}
