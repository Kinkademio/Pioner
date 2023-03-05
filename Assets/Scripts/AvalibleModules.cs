using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvalibleModules : MonoBehaviour
{
    [SerializeField] GameObject menuElement;
    private List<GameObject> menuElements;
    private Image background;

    private void Start()
    {
        this.menuElements = new List<GameObject>();
        background = this.gameObject.GetComponent<Image>();
    }
    /**
     * ������������� ����
     */
    public void Initialize(List<Module> modules, Module activeModule)
    {
        this.RemoveAllElements();
        if (modules.Count > 0)
        {
            int counter = 1;
            foreach (var module in modules)
            {
                GameObject newListElement = Instantiate(menuElement, transform);
                bool active = activeModule == module;
                newListElement.GetComponent<AvalibleModulesElement>().Initialize(module.GetEffect().GetIcon(), counter.ToString(), active);
                menuElements.Add(newListElement);
                counter++;
            }
            //��������� ������
            this.gameObject.SetActive(true);
            return;
        }
        //�������� ������
        this.gameObject.SetActive(false);
    }

    /**
     * ������� ���� �� ���������
     */
    public void RemoveAllElements()
    {
        foreach(var element in menuElements)
        {
            Destroy(element);
        }
        this.menuElements.Clear();
    }
}
