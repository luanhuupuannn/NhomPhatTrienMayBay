using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class monterB : MonoBehaviour
{
    public GameObject hieuungtrungdon;
    public GameObject hieuungtrungdon2;


    public GameObject enegry;
    public GameObject coin;
    public GameObject score;
    public Transform addenegry;
    public Transform addenegry2;

    public int raceenegry;

    Animator animator;

    public GameObject bullet;
    public Transform fireadd;
    public float speedfire = 10;

    private Vector2 targetPosition;
    public float moveSpeed;
    public int hp = 100;
   // public float Timehp;

    float timebullet = 5f;


    public AudioSource audioSource;
    public AudioClip clipdie;
    public AudioClip clipfiremonter;


    public int dame;

    int hptime;

    private void Start()
    {
        dame = PlayerPrefs.GetInt("damage");

        // lấy hp thời gian cộng vô hp gốc
        hptime = PlayerPrefs.GetInt("hptime");
        hp = hp + hptime;


        audioSource = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        targetPosition = new Vector2(Random.Range(-2.48f, 2.45f), Random.Range(8.67f, 5.5f));
        // ram dome tỷ lệ ra êngry
        raceenegry = Random.Range(1, 5);



    }

    void Update()
    {
        dame = PlayerPrefs.GetInt("damage");
        hptime = PlayerPrefs.GetInt("hptime");


        ////  Timehp -= Time.deltaTime;
        // if (Timehp < 0)
        // {
        //     hp += 5;
        //     Timehp = 10f;
        //  }
        timebullet -= Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);



        if (Vector2.Distance(transform.position, targetPosition) < 0.1f )
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            if ( timebullet < 0)
            {
                Firebullet();

            }


        }


      


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bulletplayer")
        {
            hp -= 2;
            GameObject trungdon = Instantiate(hieuungtrungdon,
            this.transform.position, this.transform.rotation);
            Destroy(trungdon, 0.5f);
            if (hp <= 0)
            {
                audioSource.PlayOneShot(clipdie);

                StartCoroutine(DelayedDestroy());  // Start the coroutine for delayed destruction
            }
        }
        else if (collision.gameObject.tag == "bulletplayer2")
        {
            hp -= 4;
            GameObject trungdon = Instantiate(hieuungtrungdon,
            this.transform.position, this.transform.rotation);
            Destroy(trungdon, 0.5f);
            if (hp <= 0)
            {
                audioSource.PlayOneShot(clipdie);

                StartCoroutine(DelayedDestroy());  // Start the coroutine for delayed destruction
            }
        }


        // blplayer2
        else if (collision.gameObject.tag == "blplayer2")
        {
            hp -= dame;
            GameObject trungdon = Instantiate(hieuungtrungdon2,
            this.transform.position, this.transform.rotation);
            Destroy(trungdon, 0.5f);
            if (hp <= 0)
            {
                audioSource.PlayOneShot(clipdie);

                StartCoroutine(DelayedDestroy());  // Start the coroutine for delayed destruction


            }
        }


        else if (collision.gameObject.tag == "bulletROBOT")
        {
            hp = 0;
            GameObject trungdon = Instantiate(hieuungtrungdon,
            this.transform.position, this.transform.rotation);
            Destroy(trungdon, 0.5f);
            if (hp <= 0)
            {
                audioSource.PlayOneShot(clipdie);

                StartCoroutine(DelayedDestroy());  // Start the coroutine for delayed destruction
            }
        }
        else if (collision.gameObject.tag == "bulletROBOT2")
        {
            hp = 4;
            GameObject trungdon = Instantiate(hieuungtrungdon,
            this.transform.position, this.transform.rotation);
            Destroy(trungdon, 0.5f);
            if (hp <= 0)
            {
                audioSource.PlayOneShot(clipdie);

                StartCoroutine(DelayedDestroy());  // Start the coroutine for delayed destruction
            }
        }

    }
    //độ trễ của destroy
    IEnumerator DelayedDestroy()
    {
        animator.SetBool("desm", true);  // Set the animation parameter immediately
        yield return new WaitForSeconds(0.8f);  // Wait for 1 second
        if (raceenegry <= 2)
        {
            GameObject bulletInstance = Instantiate(score, addenegry.position, addenegry.rotation);
            GameObject bulletInstance2 = Instantiate(score, addenegry2.position, addenegry2.rotation);

        }
        if (raceenegry == 2)
        {
            GameObject bulletInstance = Instantiate(coin, addenegry.position, addenegry.rotation);

        }
        if (raceenegry == 3)
        {
            GameObject bulletInstance = Instantiate(score, addenegry.position, addenegry.rotation);

        }
        if (raceenegry >= 3)
        {
            GameObject bulletInstance = Instantiate(coin, addenegry.position, addenegry.rotation);
            GameObject bulletInstance2 = Instantiate(coin, addenegry2.position, addenegry2.rotation);

        }
        // chọn tí lệ mong muốn 
        if (raceenegry >= 4)
        {
            //  tạo ra enegry
            GameObject bulletInstance = Instantiate(enegry, addenegry.position, addenegry.rotation);
        }
        Destroy(this.gameObject);  // Destroy the game object after the delay
    }


    void Firebullet()
    {
        audioSource.PlayOneShot(clipfiremonter);

        timebullet = 5f;
        // Create a bullet instance
        GameObject bulletInstance = Instantiate(bullet, fireadd.position, fireadd.rotation);
        // Set initial bullet velocity
        Rigidbody2D bulletRigidbody = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = Vector2.down * speedfire; // Fire downwards


    }




    public void exit()
    {
        targetPosition = new Vector2(0, -10);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(this.gameObject);

        }


    }
}
