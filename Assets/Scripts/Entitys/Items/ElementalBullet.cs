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
        //���������� ������� � ����
        this.mug = gameObject.GetComponentInParent<Pool>();
    }

    /**
     * �������������� ������� ����
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
    * ������� ��������� � ������� ������������
    */
    public new void Attack(WorldEntity entity)
    {
        if (entity != null)
        {
            Debug.Log("� ������!");
            base.Attack(entity);
            entity.ImposedByEffect(this.bullectElementalEffect);
        }
    }

    /**
    * ������������ ������������
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
    * ��������� ����
    */
    public new void Die()
    {
        Debug.Log("� ����.");
        //���������� ����� � �������
        Destroy(this.bulletPrefab);
        this.mug.ReturnObjToPool(this.gameObject);

    }

    /**
    * ���� ���� ����������, �� ���� ��������� �����w
    */
    private IEnumerator WaitBeforDeath(float wait)
    {
        yield return new WaitForSeconds(wait);
        //���������� ����� � �������
        this.Die();
    }

}
