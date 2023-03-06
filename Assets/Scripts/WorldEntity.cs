using System.Collections;
using UnityEngine;


public class WorldEntity : MonoBehaviour
{
    protected int _currentHealth;
    protected bool _canBeAffectedByEffect;
    protected Effect _imposedEffect;
    private DamageCounter damageCounter;
    [SerializeField] protected int maxHealth;
    [SerializeField] GameObject damageCounterReference = null;
    [SerializeField] bool isInvulnerable = false;

    private Color baseColor;
    private SpriteRenderer renderer;

    protected void Start()
    {
        this.SetBeAffectedByEffect(!this.isInvulnerable);
        this.renderer = this.gameObject.GetComponent<SpriteRenderer>();
        if (this.renderer != null)
        {
            this.baseColor = this.renderer.color;
        }
        this._currentHealth = this.maxHealth;
        if (this.damageCounterReference)
        {
            this.damageCounter = Instantiate(this.damageCounterReference, transform.position, this.damageCounterReference.transform.rotation).GetComponent<DamageCounter>();
        }
    }
    /**
     * Получение текущего здоровья мирового объекта
     */
    public int GetHealth()
    {
        return this._currentHealth;
    }

    /**
     * Установка здоровья мирового объекта
     */
    public void SetHealth(int health)
    {
        this._currentHealth = health;
        if (this._currentHealth <= 0)
        {
            this.Die();
        }
    }

    public void OnDestroy()
    {
        //TODO какая-то логика при смерти
    }


    /**
     * Получение действующего на объект эффекта
     */
    public Effect GetImposedEffect()
    {
        return this._imposedEffect;
    }

    /**
     * Может быть подвержено эффектам (Установка)
     */
    public void SetBeAffectedByEffect(bool isAffectable)
    {
        this._canBeAffectedByEffect = isAffectable;
    }

    /**
    * Может быть подвержено эффектам (Получение)
    */
    public bool GetBeAffectedByEffect()
    {
        return this._canBeAffectedByEffect;
    }

    /**
     * Налождение эффекта на данный объект
     */
    public void ImposedByEffect(Effect effect = null)
    {
        //Останавливаем все корутины и возвращаем цвет если в процессе корутины он не успел вернуться 
        if(this.renderer != null)
        {
            this.renderer.color = this.baseColor;
        }
        StopCoroutine("AffectByEffect");

        if (effect != null && _canBeAffectedByEffect)
        {
            //Сохраняем старый эффект
            Effect lastEffect = this._imposedEffect;

            //Устанавливаем на себя эффект 
            this._imposedEffect = effect;

            //Синергия элементов
            if(lastEffect != null)
            {
                this._imposedEffect  =  this._imposedEffect.Synergy(lastEffect);
            }
            float duration = this._imposedEffect.GetDuration();
            //Заускаем корутину на наложение эффекта    
            StartCoroutine(AffectByEffect(duration));
        }   
    }

    /**
     * Прок эффекта на мировом объекте (Корутина)
     */
    private IEnumerator AffectByEffect(float duration)
    {
        if (this._imposedEffect != null)
        {
            //Отнимаем здороье
            this.TakeDamage(this._imposedEffect.GetDamage());
            
            
            //Вызываем прок эффекта если его действие не завершилось
            if (duration > 0.0f)
            {
                duration -= this._imposedEffect.GetProcTime();
                yield return new WaitForSeconds(this._imposedEffect.GetProcTime());
                StartCoroutine(AffectByEffect(duration));
            }
        } 
    }

    /**
     * Получение урона
     */
    public void TakeDamage(int damage)
    {
        
        if(damage > 0)
        {
            Debug.Log(damage);
            StartCoroutine(DamageTaked(damage));
            this.SetHealth(this.GetHealth() - damage);
            Debug.Log("Дошло");
        }
    }

    /**
     * Эффект при получиении урона
     */
    private IEnumerator DamageTaked(int damage)
    {


        //Окрашиваем получившего урон в красный
        if(this.renderer!= null)
        {
            this.renderer.color = new Color(0.7924f, 0.3625846f, 0.3625846f);
        }
        //Выводим символ с уроном
        if (this.damageCounter != null)
        {
            this.damageCounter.PrintDamage(damage);
        }
        yield return new WaitForSeconds(0.1f);
        //Возвращаем прежний цвет
        if (this.renderer != null)
        {
            this.renderer.color = this.baseColor;
        }  
    }
    /**
     * Уничтожает мировую сущьность
     */
    public void Die()
    {
        Debug.Log("Вызывается у Сущности.");
        Destroy(gameObject);
    }
}
