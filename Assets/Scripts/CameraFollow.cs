using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject followingTarget;
    [SerializeField] float cameraFollowSpeed;

    private Vector3 bias;

    private void Start()
    {
        this.bias = 
        //���������� ������ � ������� ����������
        this.transform.position = GetNewCameraPosition();
    }
    private void Update()
    {
        //���������� ����
        this.transform.position = Vector3.Lerp(transform.position, GetNewCameraPosition(), cameraFollowSpeed * Time.deltaTime);
    }

    /**
     * ��������� ����� ������ ��������� ��������� ������ �� ��� Z � Y
     */
    private Vector3 GetNewCameraPosition()
    {
        return new Vector3(followingTarget.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
