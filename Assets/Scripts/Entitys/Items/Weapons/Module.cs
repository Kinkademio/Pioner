using UnityEngine;
using UnityEngine.UI;

public class Module : Item
{
    protected Effect effect;
    public Effect GetEffect()
    {
        return effect;
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInParent<Player>().GetAlternativWeapon().AddModule(this);
            //Скрываем обьект после сбора игроком
            this.gameObject.SetActive(false);
        }
    }

}
