using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderQuaMan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monterA"|| collision.gameObject.tag == "boss")
        {
            Destroy(this.gameObject);
        }
    }
}
