using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public GameObject DropPrefab;
    public Transform shootPoint; // �����, �� ������� ����� ���������� �����

    private float cooldown = 0;
    private Camera mainCamera;

    public GameObject player; // ������ �� ������

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
                Vector3 spawnPosition = shootPoint.position + (Vector3)(Random.insideUnitCircle * 0.2f); // ������������ Vector2 � Vector3
                                                                                                         // ���������, �� ������������ �� ��������� ������ � �������� ������
                GameObject spawnedObject = Instantiate(DropPrefab, spawnPosition, Quaternion.identity);

                // ������������� �������� ����� ������������ ������� � ������ �� ��������� �����
                StartCoroutine(EnableCollisionAfterDelay(spawnedObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), 1.0f));

                // �������� ������� ����� 1 �������
                Destroy(spawnedObject, 1.0f);
            }
        }
    }

    private IEnumerator EnableCollisionAfterDelay(Collider2D collider1, Collider2D collider2, float delay)
    {
        // ��������� �������� ����� ������������ �� �������� �����
        Physics2D.IgnoreCollision(collider1, collider2, true);

        yield return new WaitForSeconds(delay);
    }
}
