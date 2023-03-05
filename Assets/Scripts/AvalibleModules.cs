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
     * Инициализация меню
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
            //Проявляем объект
            this.gameObject.SetActive(true);
            return;
        }
        //Скрываем объект
        this.gameObject.SetActive(false);
    }

    /**
     * Очистка меню от элементов
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
