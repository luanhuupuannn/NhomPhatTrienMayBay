using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ROBOT2 : MonoBehaviour
{
    public Transform fireadd;
    GameObject bulletRobot2;
    public float random;
    public GameObject bulletROBOT2;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "bulletmonter" || collision.gameObject.tag == "bulletmonter")
        {
            random = Random.Range(1, 10);
            if(random <= 5f)
            {

            }
            if(random > 5f)
            {
                // tạo một viện đạn lvup
                 bulletRobot2 = Instantiate(bulletROBOT2, fireadd.position, Quaternion.identity);

                // lực viên đạn lvup
                Rigidbody2D rb = bulletRobot2.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
            }
        }
    }
}
