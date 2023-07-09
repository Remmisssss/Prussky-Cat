using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public Slider slider;
    private float progress;

    private void Start()
    {
        progress = 0f;
    }

    private void Update()
    {
        // Обработка нажатия правой кнопки мыши
        if (Input.GetMouseButtonDown(1))
        {
            // Увеличение прогресса
            progress += 0.1f;
            progress = Mathf.Clamp01(progress); // Ограничение значения прогресса от 0 до 1

            // Обновление прогресс-бара
            UpdateProgressBar();
        }
    }

    private void UpdateProgressBar()
    {
        slider.value = progress;
    }
}
