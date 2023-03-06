using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] Text dialogText;

    public void SetDialogText(string text)
    {
        this.dialogText.text = text;
    }
}
