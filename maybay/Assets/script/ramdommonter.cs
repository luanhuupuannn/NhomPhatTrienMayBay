using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ramdommonter : MonoBehaviour
{
    public GameObject monter;
    public float Timetoaddmonter;

     float timetoaddmonter ;
   public float x1, x2, y1, y2;

    


    // Start is called before the first frame update
    void Start()
    {
        timetoaddmonter = Timetoaddmonter;
    }

    // Update is called once per frame
    void Update()
    {
        if( timetoaddmonter > 0)
        {
            timetoaddmonter -= Time.deltaTime;

            if( timetoaddmonter <=0)
            {

                addmonter();
                timetoaddmonter = Timetoaddmonter;
            }
        }



    }


    public void addmonter()
    {

        Vector2 montadd = new Vector3(Random.Range(x1, x2), Random.Range(y1, y2),180); //-15 -14 -5 -12
        if (monter)
        {
            Instantiate(monter, montadd, Quaternion.identity);
        }

    }
}
