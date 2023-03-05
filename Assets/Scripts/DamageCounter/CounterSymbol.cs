using System.Collections;
using UnityEngine;

public class CounterSymbol : MonoBehaviour
{
    private TextMesh text;
    private Animator animator;

    public void Initialize(string symbol)
    {
        this.text = this.GetComponent<TextMesh>();
        this.animator = this.GetComponent<Animator>();
        this.text.text = symbol;
        StartCoroutine(DestroyAfterAnimate());
    }

    private IEnumerator DestroyAfterAnimate()
    {
        yield return new WaitForSeconds(this.animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(this.gameObject);
    }
    
}
