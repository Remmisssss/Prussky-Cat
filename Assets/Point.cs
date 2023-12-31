using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

    public Transform circleCenter;  // ������ �� ����������� ����� �����
    public float moveSpeed = 5f;    // �������� ����������� �����

    private Vector3 mousePosition;  // ������� ����

    private void Update()
    {
        // �������� ������� ���� � ������� �����������
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;  // ������ �������� Z ����������, ����� ��� ��������������� ��������� �������

        // ��������� ������ ����������� �� ������ ����� �� ������� ����
        Vector3 direction = mousePosition - circleCenter.position;

        // ����������� ������ �����������, ����� �������� ��������� ������
        direction.Normalize();

        // ���������� ����� �� ����������, �������� ����������� � �������� �����������
        transform.position = circleCenter.position + direction * moveSpeed * Time.deltaTime;

        //��������� �������
       // this.transform.localScale = 
    }
}