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

            CokeBar.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y +0.2f,transform.localScale.z);

        }

    }
    public void ScaleBarSprite()
    {
        float maxy = 1.3f;
        if (CokeBar.transform.localScale.y <= maxy)
        {

            SpriteBar.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.2f, transform.localScale.z);

        }

        

    }

    public void ScaleBarPepsi()
    {
        float maxy = 1.3f;
        if (CokeBar.transform.localScale.y <= maxy)
        {

            PepsiBar.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.2f, transform.localScale.z);

        }
        

    }
}
