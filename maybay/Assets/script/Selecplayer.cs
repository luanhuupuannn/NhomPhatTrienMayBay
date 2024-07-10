using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecplayer : MonoBehaviour
{

    public int index;
    public int menuindex;
    public GameObject inplayer1;
    public GameObject inplayer2;
    void Start()
    {
       index = PlayerPrefs.GetInt("saveplayer");
        PlayerPrefs.SetInt("menuindex", index);
        PlayerPrefs.Save();



        if (index == 1)
        {
            inplayer1.SetActive(true);
            inplayer2.SetActive(false);

        }
        if (index == 2)
        {
            inplayer2.SetActive(true);
            inplayer1.SetActive(false);
        }
    }


}
