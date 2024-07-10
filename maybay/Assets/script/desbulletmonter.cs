using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desbulletmonter : MonoBehaviour
{
    public float thoigianxoa = 4;

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
            thoigianxoa = 5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player2")
        {
            Destroy(this.gameObject);
        }
    }
}
