using UnityEngine;

public class GlobalSpeaker : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    [SerializeField] string text;
    private bool wasSeen;

    private void Start()
    {
        this.wasSeen= false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.OpenDialog();
        }
    }
    
    private void Update()
    {
        if((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Escape)) && this.wasSeen)
        {
            this.CloseDialog();
        }
    }
    private void OpenDialog()
    {
        this.dialog.gameObject.SetActive(true);
        this.dialog.SetDialogText(text);
        Time.timeScale = 0.0f;
        this.wasSeen = true;
    }

    private void CloseDialog()
    {
        this.dialog.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Destroy(this.gameObject);
    }

}
