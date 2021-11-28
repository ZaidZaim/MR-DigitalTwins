using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public GameObject diagramm;

    public void SetStatus()
    {
        diagramm.SetActive(true);
    }

}
