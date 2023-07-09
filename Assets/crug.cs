using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crug : MonoBehaviour
{
    public float speed = 5f; // �������� �������� ������

    private Rigidbody2D rb;

    public GameObject projectilePrefab; // ������ �������
    public Transform shootPoint; // �����, ������ ����� ������� ������

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ����� �������������� ��� (��������, ������� A � D ��� ������� ����� � ������)
        float moveInput = Input.GetAxis("Horizontal");

        // ������������� �������� ������
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

       
    }

}
