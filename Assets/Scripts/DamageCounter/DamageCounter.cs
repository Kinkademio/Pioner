using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCounter : MonoBehaviour
{
    [SerializeField] CounterSymbol counterSymbol;

    public void PrintDamage(int damage)
    {
        CounterSymbol text = Instantiate(counterSymbol, transform.position, counterSymbol.gameObject.transform.rotation);
        text.Initialize(damage.ToString());
    }

}
