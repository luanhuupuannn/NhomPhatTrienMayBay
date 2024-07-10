using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybullest : MonoBehaviour
{
    public float thoigianxoa = 2;
   
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        thoigianxoa -= Time.deltaTime;
        if (thoigianxoa < 0)
        {
            Destroy(this.gameObject);
            thoigianxoa = 2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monterA")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "monterC")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "ranhgioi")
        {
            Destroy(this.gameObject);
        }
    }
}
