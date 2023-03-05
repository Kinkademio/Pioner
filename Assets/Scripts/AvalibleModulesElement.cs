using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvalibleModulesElement : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] Text button;
    [SerializeField] GameObject active;


    public void Initialize(Sprite img, string text, bool active)
    {
        this.img.sprite = img;
        this.button.text = text;
        this.active.SetActive(active);
    }

}
