using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProgressBar.isInWater = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ProgressBar.isInWater = false;
    }
}
