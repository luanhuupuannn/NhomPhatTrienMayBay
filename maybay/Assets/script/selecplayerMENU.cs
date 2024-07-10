using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selecplayerMENU : MonoBehaviour
{
    int selecMenu;
    public GameObject splayer1;
    public GameObject splayer2;

    // Start is called before the first frame update
    void Start()
    {

        selecMenu = PlayerPrefs.GetInt("menuindex");

        if (selecMenu == 1)
        {
            splayer1.SetActive(true); splayer2.SetActive(false);

        }
        if (selecMenu == 2)
        {
            splayer1.SetActive(false); splayer2.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
