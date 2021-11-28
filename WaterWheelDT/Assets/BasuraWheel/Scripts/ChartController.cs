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

            CokeBar.transform.localScale = new Vector3(CokeBar.transform.localScale.x, CokeBar.transform.localScale.y +0.2f, CokeBar.transform.localScale.z);

        }

    }
    public void ScaleBarSprite()
    {
        float maxy = 1.3f;
        if (SpriteBar.transform.localScale.y <= maxy)
        {

            SpriteBar.transform.localScale = new Vector3(SpriteBar.transform.localScale.x, SpriteBar.transform.localScale.y + 0.2f, SpriteBar.transform.localScale.z);

        }

        

    }

    public void ScaleBarPepsi()
    {
        float maxy = 1.3f;
        if (PepsiBar.transform.localScale.y <= maxy)
        {

            PepsiBar.transform.localScale = new Vector3(PepsiBar.transform.localScale.x, PepsiBar.transform.localScale.y + 0.2f, PepsiBar.transform.localScale.z);

        }
        

    }
}
