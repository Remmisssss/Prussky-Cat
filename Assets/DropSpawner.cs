using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public GameObject DropPrefab;
    public Transform shootPoint; // Точка, из которой будут появляться сферы

    private float cooldown = 0;
    private Camera mainCamera;

    public GameObject player; // Ссылка на игрока

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cooldown -= Time.deltaTime;
            while (cooldown < 0)
            {
                cooldown += 0.01f;
                Vector3 spawnPosition = shootPoint.position + (Vector3)(Random.insideUnitCircle * 0.2f); // Конвертируем Vector2 в Vector3
                                                                                                         // Проверяем, не пересекается ли коллайдер частиц с позицией спавна
                GameObject spawnedObject = Instantiate(DropPrefab, spawnPosition, Quaternion.identity);

                // Игнорирование коллизий между коллайдерами объекта и игрока на некоторое время
                StartCoroutine(EnableCollisionAfterDelay(spawnedObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), 1.0f));

                // Удаление объекта через 1 секунду
                Destroy(spawnedObject, 1.0f);
            }
        }
    }

    private IEnumerator EnableCollisionAfterDelay(Collider2D collider1, Collider2D collider2, float delay)
    {
        // Отключаем коллизии между коллайдерами на заданное время
        Physics2D.IgnoreCollision(collider1, collider2, true);

        yield return new WaitForSeconds(delay);
    }
}
