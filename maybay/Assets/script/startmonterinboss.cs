using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmonterinboss : MonoBehaviour
{
    public GameObject automon;
    public GameObject autoboss;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "again") { 
        
            autoboss.SetActive(true);
            automon.SetActive(true);

           // Invoke("des", 1f);
            Destroy(collision.gameObject);

        }
    }

    private void des()
    {

    }
}
