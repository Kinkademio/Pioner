using System.Collections.Generic;
using UnityEngine;

/**
 * Реализация паттерна Pool 
 */
public class Pool : MonoBehaviour
{
    [SerializeField] int countOfObjects;
    [SerializeField] GameObject poolEntityType;
    private Queue<GameObject> poolObjects;
        
    private void Start()
    {
        this.InitializePool();
    }

    /**
     * Возвращение объекта в пул
     */
    public void ReturnObjToPool(GameObject entity)
    {
        entity.SetActive(false);
        this.poolObjects.Enqueue(entity);
    }

    /**
     * Взятие объекта из пула
     */
    public GameObject GetObjFromPool(Vector3 position)
    {
        GameObject obj = this.poolObjects.Dequeue();
        obj.transform.position = position;
        obj.SetActive(true);
        return obj;
    }

    /**
     * Получить кол-во объектов в пуле
     */
    public int GetCountOfPoolObjects()
    {
        return this.poolObjects.Count;
    }

    /**
     * Получение общего кол-ва объектов хранящихся в пуле
     */
    public int GetMaxCountOfPoolObjects()
    {
        return this.countOfObjects;
    }
    /**
     * Инициализация
     */
    private void InitializePool()
    {
        this.poolObjects = new Queue<GameObject>();

        for(int i=0; i<this.countOfObjects; i++)
        {
            GameObject newGameObj = Instantiate(poolEntityType.gameObject, this.gameObject.transform);
            this.poolObjects.Enqueue(newGameObj);
            newGameObj.SetActive(false);
        }
    }

}
