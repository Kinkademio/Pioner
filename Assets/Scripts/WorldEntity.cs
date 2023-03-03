using System.Collections;
using UnityEngine;


public class WorldEntity : MonoBehaviour
{
    [SerializeField] int health;
    private bool canBeAffectedByEffect;
    private Effect imposedEffect;

    /**
     * Получение здоровья мирового объекта
     */
    public int GetHealth()
    {
        return this.health;
    }

    /**
     * Установка здоровья мирового объекта
     */
    public void SetHealth(int health)
    {
        this.health = health;
        if (this.health <= 0)
        {
            Destroy(gameObject);
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
        return this.imposedEffect;
    }

    /**
     * Может быть подвержено эффектам (Установка)
     */
    public void SetBeAffectedByEffect(bool isAffectable)
    {
        this.canBeAffectedByEffect = isAffectable;
    }

    /**
    * Может быть подвержено эффектам (Получение)
    */
    public bool GetBeAffectedByEffect()
    {
        return this.canBeAffectedByEffect;
    }

    /**
     * Налождение эффекта на данный объект
     */
    public void ImposedByEffect(Effect effect = null)
    {
        if (effect != null && canBeAffectedByEffect)
        {
            //Сохраняем старый эффект
            Effect lastEffect = this.imposedEffect;

            //Устанавливаем на себя эффект 
            this.imposedEffect = effect;

            //Синергия элементов
            if(lastEffect != null)
            {
                this.imposedEffect.Synergy(lastEffect);
            }

            //Заускаем корутину на наложение эффекта
            StartCoroutine(AffectByEffect());
        }   
    }

    /**
     * Прок эффекта на мировом объекте (Корутина)
     */
    private IEnumerator AffectByEffect()
    {
        if (this.imposedEffect != null)
        {
            //Отнимаем здороье
            this.SetHealth(this.GetHealth() - this.imposedEffect.GetDamage());

            //Вызываем прок эффекта если его действие не завершилось
            if (this.imposedEffect.GetDuration() > 0.0f)
            {
                this.imposedEffect.SetDuration(this.imposedEffect.GetDuration() - this.imposedEffect.GetProcTime());
                yield return new WaitForSeconds(this.imposedEffect.GetProcTime());
                StartCoroutine(AffectByEffect());
            }
        } 
    }
}
