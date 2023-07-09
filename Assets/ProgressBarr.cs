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
    static public bool isInWater; // соприкасается с водой

    public enum SizeCat // размеры Кота
    {
        Little = 1,
        Middle = 2,
        Big = 3
    }

    public SizeCat sizeCat;


    private void Start()
    {
        progressBar.value = 0;
        circleObject = GameObject.Find("Cat");
        obj = GameObject.Find("rotatingPoint");
        circleLookAtMouse = circleObject.GetComponent<CircleLookAtMouse>();
        dropSpawner = obj.GetComponent<DropSpawner>();
        wat = circleObject.GetComponent<Wat>();


    }

    

    public string targetTag; // Тег объектов, с которыми нужно проверить соприкосновение

   



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
