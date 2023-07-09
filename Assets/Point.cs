using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

    public Transform circleCenter;  // —сылка на центральную точку круга
    public float moveSpeed = 5f;    // —корость перемещени€ точки

    private Vector3 mousePosition;  // ѕозици€ мыши

    private void Update()
    {
        // ѕолучаем позицию мыши в мировых координатах
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;  // «адаем значение Z координаты, чтобы она соответствовала плоскости объекта

        // ¬ычисл€ем вектор направлени€ от центра круга до позиции мыши
        Vector3 direction = mousePosition - circleCenter.position;

        // Ќормализуем вектор направлени€, чтобы получить единичный вектор
        direction.Normalize();

        // ѕеремещаем точку по окружности, учитыва€ направление и скорость перемещени€
        transform.position = circleCenter.position + direction * moveSpeed * Time.deltaTime;

        //изменение размера
        int boy = (int)ProgressBar.SizeCat;

        this.transform.localScale = new Vector3((int)ProgressBar.SizeCat, (int)ProgressBar.SizeCat, 0f);
    }
}