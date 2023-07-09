using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plev : MonoBehaviour
{
    public float speed = 5f; // �������� �������
    public float forceMagnitude = 10f; // ��������� ������������

    private Rigidbody2D rb;

    public float destroyDelay = 1f; // �������� ����� ������������ ������� Water_gen

    // Start is called before the first frame update
    private float cooldown = 0;


    public GameObject projectilePrefab; // ������ �������
    public Transform shootPoint; // �����, ������ ����� ������� ������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        
    }
    void OnProjectileCollisionEnter2D(Collision2D collision)
    {
        // ��������� ������������ ������� � ������ ��������
        // ����� �� ������ �������� ������ ������, ��������� ����� � �.�.

        // ����������� ������ Cat �� �������
        Rigidbody2D catRb = collision.collider.GetComponent<Rigidbody2D>();
        if (catRb != null && collision.gameObject.CompareTag("Cat"))
        {
            Vector2 direction = collision.transform.position - shootPoint.position;
            direction.Normalize();

            catRb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
        }

        // ���������� ������
        Destroy(collision.gameObject);
    }

    void Shoot()
    {

        // �������� ������� ���� � ������� �����������
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // ������������� Z-���������� ������ 0, ����� ���������� � 2D-������������

        // ��������� ����������� �� ����� �������� �� ������� ����
        Vector3 direction = mousePosition - shootPoint.position;
        direction.Normalize(); // ����������� �����������, ����� �������� ��������� ������

        // ������� ������ �� shootPoint ������� � � ����� �� ���������


        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        // �������� Rigidbody2D �������
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

        // ��������� ���� � ������� ��� ��� �������� � ����������� ����
        projectileRb.velocity = direction * speed;

        Destroy(projectile, destroyDelay);


    }
   
}
