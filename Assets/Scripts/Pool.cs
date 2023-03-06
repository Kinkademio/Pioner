using System.Collections.Generic;
using UnityEngine;

/**
 * ���������� �������� Pool 
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
     * ����������� ������� � ���
     */
    public void ReturnObjToPool(GameObject entity)
    {
        entity.SetActive(false);
        this.poolObjects.Enqueue(entity);
    }

    /**
     * ������ ������� �� ����
     */
    public GameObject GetObjFromPool(Vector3 position)
    {
        GameObject obj = this.poolObjects.Dequeue();
        obj.transform.position = position;
        obj.SetActive(true);
        return obj;
    }

    /**
     * �������� ���-�� �������� � ����
     */
    public int GetCountOfPoolObjects()
    {
        return this.poolObjects.Count;
    }

    /**
     * ��������� ������ ���-�� �������� ���������� � ����
     */
    public int GetMaxCountOfPoolObjects()
    {
        return this.countOfObjects;
    }
    /**
     * �������������
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
