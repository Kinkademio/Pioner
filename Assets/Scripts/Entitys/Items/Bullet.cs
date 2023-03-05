using UnityEngine;

public abstract class Bullet : WorldEntity
{
    [SerializeField] int damage;

    private void OnCollisionEnter(Collision collision)
    {
        this.Attack(collision.gameObject.GetComponent<WorldEntity>());

    }
    public void Attack(WorldEntity entity)
    {
        if(entity != null)
        {
            entity.TakeDamage(this.damage);
        }
        
    }
}
