using System.Collections;
using UnityEngine;


public class WorldEntity : MonoBehaviour
{
    [SerializeField] int health;
    private bool canBeAffectedByEffect;
    private Effect imposedEffect;

    /**
     * ��������� �������� �������� �������
     */
    public int GetHealth()
    {
        return this.health;
    }

    /**
     * ��������� �������� �������� �������
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
        //TODO �����-�� ������ ��� ������
    }


    /**
     * ��������� ������������ �� ������ �������
     */
    public Effect GetImposedEffect()
    {
        return this.imposedEffect;
    }

    /**
     * ����� ���� ���������� �������� (���������)
     */
    public void SetBeAffectedByEffect(bool isAffectable)
    {
        this.canBeAffectedByEffect = isAffectable;
    }

    /**
    * ����� ���� ���������� �������� (���������)
    */
    public bool GetBeAffectedByEffect()
    {
        return this.canBeAffectedByEffect;
    }

    /**
     * ���������� ������� �� ������ ������
     */
    public void ImposedByEffect(Effect effect = null)
    {
        if (effect != null && canBeAffectedByEffect)
        {
            //��������� ������ ������
            Effect lastEffect = this.imposedEffect;

            //������������� �� ���� ������ 
            this.imposedEffect = effect;

            //�������� ���������
            if(lastEffect != null)
            {
                this.imposedEffect.Synergy(lastEffect);
            }

            //�������� �������� �� ��������� �������
            StartCoroutine(AffectByEffect());
        }   
    }

    /**
     * ���� ������� �� ������� ������� (��������)
     */
    private IEnumerator AffectByEffect()
    {
        if (this.imposedEffect != null)
        {
            //�������� �������
            this.SetHealth(this.GetHealth() - this.imposedEffect.GetDamage());

            //�������� ���� ������� ���� ��� �������� �� �����������
            if (this.imposedEffect.GetDuration() > 0.0f)
            {
                this.imposedEffect.SetDuration(this.imposedEffect.GetDuration() - this.imposedEffect.GetProcTime());
                yield return new WaitForSeconds(this.imposedEffect.GetProcTime());
                StartCoroutine(AffectByEffect());
            }
        } 
    }
}
