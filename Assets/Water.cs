using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float repelForce = 10f;

    private void OnParticleCollision(GameObject other)
    {
        // ���������, ��� ������������ ��������� � ��������� ����� ����
        if (other.CompareTag("WaterParticle"))
        {
            // ����������� ��������� � ��������������� �����������
            Vector2 repelDirection = transform.position - other.transform.position;
            GetComponent<Rigidbody2D>().AddForce(repelDirection * repelForce, ForceMode2D.Impulse);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
}
