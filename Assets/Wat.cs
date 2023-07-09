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
        // �������� ������� ���� � �������� �����������
        Vector3 mousePosition = Input.mousePosition;
        // ����������� ������� ���� �� �������� ��������� � ������� ����������
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z));

        // �������� ������ ����������� �� ����� �� ����
        Vector3 direction = worldMousePosition - transform.position;
        direction.Normalize();

        // ������ ������� �������� ��� ��� Z
        direction.z = 0f;
        direction.y = 0f;

        // ��������� ����� ������� ��� �������� �����
        Vector3 newPosition = transform.position - direction * speed * Time.deltaTime;

        // ��������� ������� �����
        transform.position = newPosition;
    }
}
