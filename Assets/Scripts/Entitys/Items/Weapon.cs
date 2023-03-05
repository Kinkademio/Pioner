public class Weapon : Item
{
    private int _damage;

    /**
     * Получить урон оруджия
     */
    public int GetDamage()
    {
        return _damage;
    }


    /**
     * Установить урон оружию
     */
    public void SetDamage(int damage)
    {
        this._damage = damage;
    }

    /**
     * Атаковать 
     */
    public void Attack() { }



}
