using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offObject : MonoBehaviour
{
    public GameObject ogbject;
    float timeoff = 60f;

    // Update is called once per frame
    void Update()
    {
        timeoff -= Time.deltaTime;
        if (timeoff < 0)
        {
            ogbject.SetActive(false);
        }
    }
}
