using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wat : MonoBehaviour
{
    public float speed = 3f;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Получаем позицию мыши в экранных координатах
        Vector3 mousePosition = Input.mousePosition;
        // Преобразуем позицию мыши из экранных координат в мировые координаты
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z));

        // Получаем вектор направления от круга до мыши
        Vector3 direction = worldMousePosition - transform.position;
        direction.Normalize();

        // Задаем нулевое значение для оси Z
        direction.z = 0f;
        direction.y = 0f;

        // Вычисляем новую позицию для движения круга
        Vector3 newPosition = transform.position - direction * speed * Time.deltaTime;

        // Обновляем позицию круга
        transform.position = newPosition;
    }
}
