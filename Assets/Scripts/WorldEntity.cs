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
     * ��������� �������� �������� �������� �������
     */
    public int GetHealth()
    {
        return this._currentHealth;
    }

    /**
     * ��������� �������� �������� �������
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
        //TODO �����-�� ������ ��� ������
    }


    /**
     * ��������� ������������ �� ������ �������
     */
    public Effect GetImposedEffect()
    {
        return this._imposedEffect;
    }

    /**
     * ����� ���� ���������� �������� (���������)
     */
    public void SetBeAffectedByEffect(bool isAffectable)
    {
        this._canBeAffectedByEffect = isAffectable;
    }

    /**
    * ����� ���� ���������� �������� (���������)
    */
    public bool GetBeAffectedByEffect()
    {
        return this._canBeAffectedByEffect;
    }

    /**
     * ���������� ������� �� ������ ������
     */
    public void ImposedByEffect(Effect effect = null)
    {
        //������������� ��� �������� � ���������� ���� ���� � �������� �������� �� �� ����� ��������� 
        if(this.renderer != null)
        {
            this.renderer.color = this.baseColor;
        }
        StopCoroutine("AffectByEffect");

        if (effect != null && _canBeAffectedByEffect)
        {
            //��������� ������ ������
            Effect lastEffect = this._imposedEffect;

            //������������� �� ���� ������ 
            this._imposedEffect = effect;

            //�������� ���������
            if(lastEffect != null)
            {
                this._imposedEffect  =  this._imposedEffect.Synergy(lastEffect);
            }
            float duration = this._imposedEffect.GetDuration();
            //�������� �������� �� ��������� �������    
            StartCoroutine(AffectByEffect(duration));
        }   
    }

    /**
     * ���� ������� �� ������� ������� (��������)
     */
    private IEnumerator AffectByEffect(float duration)
    {
        if (this._imposedEffect != null)
        {
            //�������� �������
            this.TakeDamage(this._imposedEffect.GetDamage());
            
            
            //�������� ���� ������� ���� ��� �������� �� �����������
            if (duration > 0.0f)
            {
                duration -= this._imposedEffect.GetProcTime();
                yield return new WaitForSeconds(this._imposedEffect.GetProcTime());
                StartCoroutine(AffectByEffect(duration));
            }
        } 
    }

    /**
     * ��������� �����
     */
    public void TakeDamage(int damage)
    {
        
        if(damage > 0)
        {
            Debug.Log(damage);
            StartCoroutine(DamageTaked(damage));
            this.SetHealth(this.GetHealth() - damage);
            Debug.Log("�����");
        }
    }

    /**
     * ������ ��� ���������� �����
     */
    private IEnumerator DamageTaked(int damage)
    {


        //���������� ����������� ���� � �������
        if(this.renderer!= null)
        {
            this.renderer.color = new Color(0.7924f, 0.3625846f, 0.3625846f);
        }
        //������� ������ � ������
        if (this.damageCounter != null)
        {
            this.damageCounter.PrintDamage(damage);
        }
        yield return new WaitForSeconds(0.1f);
        //���������� ������� ����
        if (this.renderer != null)
        {
            this.renderer.color = this.baseColor;
        }  
    }
    /**
     * ���������� ������� ���������
     */
    public void Die()
    {
        Debug.Log("���������� � ��������.");
        Destroy(gameObject);
    }
}
