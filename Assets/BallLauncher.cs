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
        // ��������� ������� ������ ������ ����
        if (Input.GetMouseButtonDown(1))
        {
            // ���������� ���������
            progress += 0.1f;
            progress = Mathf.Clamp01(progress); // ����������� �������� ��������� �� 0 �� 1

            // ���������� ��������-����
            UpdateProgressBar();
        }
    }

    private void UpdateProgressBar()
    {
        slider.value = progress;
    }
}
