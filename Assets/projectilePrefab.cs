using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plev : MonoBehaviour
{
    public float speed = 5f; // Скорость снаряда
    public float forceMagnitude = 10f; // Магнитуда отталкивания

    private Rigidbody2D rb;

    public float destroyDelay = 1f; // Задержка перед уничтожением объекта Water_gen

    // Start is called before the first frame update
    private float cooldown = 0;


    public GameObject projectilePrefab; // Префаб снаряда
    public Transform shootPoint; // Точка, откуда будет выпущен снаряд

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
        // Обработка столкновения снаряда с другим объектом
        // Здесь вы можете добавить эффект взрыва, нанесение урона и т.д.

        // Отталкиваем объект Cat от снаряда
        Rigidbody2D catRb = collision.collider.GetComponent<Rigidbody2D>();
        if (catRb != null && collision.gameObject.CompareTag("Cat"))
        {
            Vector2 direction = collision.transform.position - shootPoint.position;
            direction.Normalize();

            catRb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
        }

        // Уничтожаем снаряд
        Destroy(collision.gameObject);
    }

    void Shoot()
    {

        // Получаем позицию мыши в мировых координатах
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Устанавливаем Z-координату равной 0, чтобы оставаться в 2D-пространстве

        // Вычисляем направление от точки стрельбы до позиции мыши
        Vector3 direction = mousePosition - shootPoint.position;
        direction.Normalize(); // Нормализуем направление, чтобы получить единичный вектор

        // Создаем снаряд на shootPoint позиции и с таким же вращением


        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        // Получаем Rigidbody2D снаряда
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

        // Применяем силу к снаряду для его движения в направлении мыши
        projectileRb.velocity = direction * speed;

        Destroy(projectile, destroyDelay);


    }
   
}
