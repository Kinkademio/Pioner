using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] Image health;

    /**
     * ��������� �������� �� ����� ��������
     * ���������� ���������� �����������.
     */
    public void SetHealth(float health)
    {
        this.health.transform.localScale = new Vector3(health, this.health.transform.localScale.y, this.health.transform.localScale.z);
    }

}
