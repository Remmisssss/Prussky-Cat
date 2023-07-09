using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject objectToSpawn; // ������ �������, ������� ����� �������
    public int numberOfObjects = 5; // ���������� ��������, ������� ����� �������
    public float spawnRadius = 2f; // ������ ������ ����� ��������

    private void Start()
    {
        // �������� ������� �������� �������
        Vector3 spawnPosition = transform.position;

        // ������� ����� ������� ������ �������� �������
        for (int i = 0; i < numberOfObjects; i++)
        {
            // ���������� ��������� �������� ������ �������� �������
            Vector2 offset = Random.insideUnitCircle * spawnRadius;

            // ��������� ������� ������ ������ �������
            Vector3 newPosition = spawnPosition + new Vector3(offset.x, offset.y, 0f);

            // ������� ����� ������
            GameObject spawnedObject = Instantiate(objectToSpawn, newPosition, Quaternion.identity);
        }
    }
            private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(gameObject); // �������� ������� ����
        }
    }
}
