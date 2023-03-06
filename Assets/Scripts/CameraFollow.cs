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
        //Перемещаем кумеру к объекту следования
        this.transform.position = GetNewCameraPosition();
    }
    private void Update()
    {
        //Приследуем цель
        this.transform.position = Vector3.Lerp(transform.position, GetNewCameraPosition(), cameraFollowSpeed * Time.deltaTime);
    }

    /**
     * Формируем новый вектор игронируя отдаление камеры по оси Z и Y
     */
    private Vector3 GetNewCameraPosition()
    {
        return new Vector3(followingTarget.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
