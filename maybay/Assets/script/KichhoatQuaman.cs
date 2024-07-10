using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class kickhoatquaman : MonoBehaviour
{
    public GameObject EndCollider;
     float TimetoaddEndStr = 5f;
    float timeend = 65f;

    float timetoaddmonter;
    public float x1, x2;




    // Start is called before the first frame update
    void Start()
    {
        timetoaddmonter = TimetoaddEndStr;
    }

    // Update is called once per frame
    void Update()
    {
        timeend -= Time.deltaTime;
        if (timeend <0)
        {
            if (timetoaddmonter > 0)
            {
                timetoaddmonter -= Time.deltaTime;

                if (timetoaddmonter <= 0)
                {

                    addmonter();
                    timetoaddmonter = TimetoaddEndStr;
                }
            }
        }
        



    }
    public void addmonter()
    {

        Vector2 montadd = new Vector3(x1,x2,180); //-15 -14 -5 -12
        if (EndCollider)
        {
            Instantiate(EndCollider, montadd, Quaternion.identity);
        }
    }
}
