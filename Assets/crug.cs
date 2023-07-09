using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crug : MonoBehaviour
{
    public float speed = 5f; // Скорость движения шарика

    private Rigidbody2D rb;

    public GameObject projectilePrefab; // Префаб снаряда
    public Transform shootPoint; // Точка, откуда будет выпущен снаряд

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Чтение ввода горизонтальной оси (например, клавиши A и D или стрелки влево и вправо)
        float moveInput = Input.GetAxis("Horizontal");

        // Устанавливаем скорость шарика
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

       
    }

}
