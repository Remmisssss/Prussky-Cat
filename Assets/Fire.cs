using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject objectToSpawn; // Префаб объекта, который нужно создать
    public int numberOfObjects = 5; // Количество объектов, которые нужно создать
    public float spawnRadius = 2f; // Радиус спавна новых объектов

    private void Start()
    {
        // Получаем позицию текущего объекта
        Vector3 spawnPosition = transform.position;

        // Создаем новые объекты вокруг текущего объекта
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Генерируем случайное смещение вокруг текущего объекта
            Vector2 offset = Random.insideUnitCircle * spawnRadius;

            // Вычисляем позицию спавна нового объекта
            Vector3 newPosition = spawnPosition + new Vector3(offset.x, offset.y, 0f);

            // Создаем новый объект
            GameObject spawnedObject = Instantiate(objectToSpawn, newPosition, Quaternion.identity);
        }
    }
            private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(gameObject); // Удаление объекта огня
        }
    }
}
