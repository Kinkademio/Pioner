public class Weapon : Item
{
    private int _damage;

    /**
     * �������� ���� �������
     */
    public int GetDamage()
    {
        return _damage;
    }


    /**
     * ���������� ���� ������
     */
    public void SetDamage(int damage)
    {
        this._damage = damage;
    }

    /**
     * ��������� 
     */
    public void Attack() { }



}
