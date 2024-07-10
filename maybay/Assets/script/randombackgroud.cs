using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class randombackgroud : MonoBehaviour
{
    int so;
    public GameObject br1;
    public GameObject br2;
    public GameObject br3;

    void Start()
    {
        so = UnityEngine.Random.Range(1, 6);

        if (so == 1 || so == 2 )
        {
            br1.SetActive(true);
        }
        else if (so == 3 || so == 4)
        {
            br2.SetActive(true);

        }
        else  { br3.SetActive(true);}

           }
   

}
