using System.Collections;
using UnityEngine;

public class ElementalBullet : Bullet
{
    private Effect bullectElementalEffect;
    private Pool mug;
    private GameObject bulletPrefab;

    private const float polymerBulletLifeTime = 10.0f;
    private const float bulletLifeTime = 1.0f;

    private void Start()
    {
        //Определяем магазин у пули
        this.mug = gameObject.GetComponentInParent<Pool>();
    }

    /**
     * Инициализируем элемент пули
     */
    public void Initialize(Effect effect)
    {
        this.bullectElementalEffect = effect;
        this.bulletPrefab =  Instantiate(effect.GetBulletPrefab(), transform);
        float timeToDestroy = bulletLifeTime;
        if(this.bullectElementalEffect.GetType().Name == typeof(PolymerEffect).Name)
        {
            timeToDestroy = polymerBulletLifeTime;
        }
        StartCoroutine(WaitBeforDeath(timeToDestroy));
    }

    /**
    * Атакуем сущьность с которой стролкнулись
    */
    public new void Attack(WorldEntity entity)
    {
        if (entity != null)
        {
            Debug.Log("Я атакую!");
            base.Attack(entity);
            entity.ImposedByEffect(this.bullectElementalEffect);
        }
    }

    /**
    * Обрабатываем столкновение
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag != "Player")
        {
            this.Attack(collision.gameObject.GetComponent<WorldEntity>());
            if(this.bullectElementalEffect.GetType().Name != typeof(PolymerEffect).Name)
            {
                this.Die();
            }  
        }
    }

    /**
    * Разрушакм пулю
    */
    public new void Die()
    {
        Debug.Log("Я умер.");
        //возвращаем пулую в магазин
        Destroy(this.bulletPrefab);
        this.mug.ReturnObjToPool(this.gameObject);

    }

    /**
    * Если пуля полимерная, то ждем некоторое времяw
    */
    private IEnumerator WaitBeforDeath(float wait)
    {
        yield return new WaitForSeconds(wait);
        //возвращаем пулую в магазин
        this.Die();
    }

}
