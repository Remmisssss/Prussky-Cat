using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject obj;
    public GameObject circleObject;
    CircleLookAtMouse circleLookAtMouse;
    DropSpawner dropSpawner;
    Wat wat;


    public Slider progressBar;
    private int currentValue = 1;
    private bool isFilling = false;
    public static bool isInWater; // соприкасается с водой

    public string targetTag; // Тег объектов, с которыми нужно проверить соприкосновение


    public enum SizeCat // размеры Кота
    {
        Little = 10,
        Middle = 20,
        Big = 30
    }

    public static SizeCat sizeCat = SizeCat.Little;


    private void Start()
    {
        progressBar.value = 0;
        circleObject = GameObject.Find("Cat");
        obj = GameObject.Find("rotatingPoint");
        circleLookAtMouse = circleObject.GetComponent<CircleLookAtMouse>();
        dropSpawner = obj.GetComponent<DropSpawner>();
        wat = circleObject.GetComponent<Wat>();


    }

   



    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isInWater)
        {
            if (currentValue < 10)
            {
                if (circleLookAtMouse != null)
                {
                    circleLookAtMouse.enabled = true;
                    wat.enabled = false;
                    dropSpawner.enabled = true;
                }
                currentValue++;
                StartCoroutine(UpdateProgressBar());
               
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentValue > 0)
            {
                if (circleLookAtMouse != null)
                {
                    circleLookAtMouse.enabled = true;
                    wat.enabled = false;
                    dropSpawner.enabled = true;
                }

                currentValue--;
                StartCoroutine(UpdateProgressBar());
            }
            if (currentValue <= 0)
            {
                
                if (circleLookAtMouse != null)
                {
                    circleLookAtMouse.enabled = false;
                    wat.enabled = true;
                    dropSpawner.enabled = false;
                }

            }
        }

        //изменение размеров кота
        if (currentValue <= (int) SizeCat.Little)
            sizeCat = SizeCat.Little;
        if (currentValue > (int)SizeCat.Little && currentValue <= (int)SizeCat.Middle)
            sizeCat = SizeCat.Middle;
        if(currentValue > (int)SizeCat.Middle)
            sizeCat = SizeCat.Big;

         
    }

    private IEnumerator UpdateProgressBar()
    {
        isFilling = true;

        float targetValue = (float)currentValue / 10f;
        float fillSpeed = 0.5f; // Скорость заполнения/уменьшения прогресс-бара

        if (targetValue > progressBar.value)
        {
            while (progressBar.value < targetValue)
            {
                progressBar.value += fillSpeed * Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            while (progressBar.value > targetValue)
            {
                progressBar.value -= fillSpeed * Time.deltaTime;
                yield return null;
            }
        }

        progressBar.value = targetValue;
        isFilling = false;
    }
}
