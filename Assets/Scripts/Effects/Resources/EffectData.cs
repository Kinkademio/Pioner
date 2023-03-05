using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Data/EffectData")]
/**
 * Ёкономим пам€ть на константах с помощью скрипт. объектов
 */
public class EffectData : ScriptableObject
{
    [SerializeField] int damage;
    [SerializeField] float duration;
    [SerializeField] float prockTime;
    [SerializeField] Sprite icon;
    [SerializeField] GameObject bulletPrefab;

    //√еттеры
    public int GetDamage()
    {
        return this.damage;
    }

    public float GetDuration()
    {
        return this.duration;

    }

    public float GetProcTime()
    {
        return this.prockTime;
    }

    public Sprite GetIcon()
    {
        return this.icon;   
    }
    
    public GameObject GetBulletPrefab()
    {
        return this.bulletPrefab;
    }

}
