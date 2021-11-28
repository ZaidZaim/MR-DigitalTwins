using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleDetector : MonoBehaviour
{
    public int counterCoke = 0;
    public int counterSprite= 0;
    public int counterPepsi= 0;
    ChartController scaleBars;

    void OnTriggerEnter(Collider targetObj)
    {

        if (targetObj.CompareTag("Sprite"))
        {
            counterSprite++;
            scaleBars.ScaleBarSprite();
            
        }


        if (targetObj.CompareTag("Coke"))
        {
            counterCoke++;
            scaleBars.ScaleBarCoke();

        }


        if (targetObj.CompareTag("Pepsi"))
        {
            counterPepsi++;
            scaleBars.ScaleBarPepsi();

        }

    }
}
