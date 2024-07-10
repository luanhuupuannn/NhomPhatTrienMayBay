using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class boss : MonoBehaviour
{

    public float moveSpeed = 5;



    public Transform fireadd;
    public GameObject bullet;

    public Transform fireadd2;
    public GameObject bullet2;

    public Transform fireadd3;
    public GameObject bullet3;
    public GameObject lazebulet;
    public float timeLazebullet = 23f;

    public float timeblet = 5f;
    // Start is called before the first frame update

    private void Start()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        // di chuyen
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-0.16f, 6.09f), moveSpeed * Time.deltaTime);
        timeblet -= Time.deltaTime;
        timeLazebullet -= Time.deltaTime;
        if (timeblet < 0)
        {
            firebullet();
            timeblet = 5f;
        }

        if (timeLazebullet < 0)
        {
            lazeblet();
            timeLazebullet = 23f;
        }
       

    }


    void firebullet()
    {
        // tạo đạn
        GameObject bulletInstance = Instantiate(bullet, fireadd.position, fireadd.rotation);

        GameObject bulletInstance2 = Instantiate(bullet2, fireadd2.position, fireadd.rotation);


    }
    private void lazeblet()
    {
        GameObject bulletInstance3 = Instantiate(bullet3, fireadd3.position, fireadd.rotation);

        Destroy(bulletInstance3,3f);
        Invoke("laze", 3f);
        Invoke("destroylaze", 5f);


    }

    void laze()
    {
        lazebulet.SetActive(true);
    }
    void destroylaze()
    {
        lazebulet.SetActive(false);
    }


}
