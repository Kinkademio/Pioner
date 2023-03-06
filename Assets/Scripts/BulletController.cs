using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    [SerializeField] Text bulletCounter;

    public void UpdateBulletCount(int currentBulletCount, int maxBulletCount)
    {
        this.bulletCounter.text =currentBulletCount.ToString() + "/"+ maxBulletCount.ToString();
    }

   
}
