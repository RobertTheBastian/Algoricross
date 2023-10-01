using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursorBlink : MonoBehaviour
{



    void Update()
    {
        if (Time.fixedTime % 1 < .3)
        {
            GetComponent<CanvasRenderer>().SetAlpha(0f);
        }
        else
        {
            GetComponent<CanvasRenderer>().SetAlpha(1f);
        }
    }
}
