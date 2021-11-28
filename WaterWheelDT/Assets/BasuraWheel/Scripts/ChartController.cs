using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartController : MonoBehaviour
{
    public GameObject diagramm;
    public GameObject CokeBar;
    public GameObject SpriteBar;
    public GameObject PepsiBar;

   

    public void SetStatus()
    {
        diagramm.SetActive(true);
    }

    public void ScaleBarCoke()
    {
        
        float maxy = 1.3f;
        if (CokeBar.transform.localScale.y <= maxy)
        {

            CokeBar.transform.localScale = new Vector3(transform.localScale.y, 0.2f);

        }
        else
        {
            
        }

    }
    public void ScaleBarSprite()
    {
        SpriteBar.transform.localScale = new Vector3(transform.localScale.y,0.2f);

    }

    public void ScaleBarPepsi()
    {
        PepsiBar.transform.localScale = new Vector3(transform.localScale.y,0.2f);

    }
}
