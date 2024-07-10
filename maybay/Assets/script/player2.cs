using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class player2 : MonoBehaviour
{


    // bl
    GameObject butllettmonter;
    //blup2
    GameObject bulletlvup;
    GameObject bulletlvup2;

    public Transform fireaddlvup;
    bool lvup;
    public Transform fireaddlvup2;



    public GameObject bullet;
    public Transform fireadd1;

    public float TimeFire = 3f;
    public float speedfire = 10;
    private float timefire;



    Animator animator;
    //over
    Rigidbody2D rb1;
    public GameObject gameover;
    // dame hp
    public int damage;
    // âm thanh
    public AudioSource br;
    public AudioSource audioSource;
    public AudioClip Clipdie;
    public AudioClip cliplvup;
    // ani
    Animator ni;
    int random;

    public GameObject checkrobot;


    // thời gian càng lâu hp con quái càng lớn
    int hptheothoigian;
    float timehp = 30;

    // Start is called before the first frame update
    void Start()
    {
        // thời gian càng lâu hp con quái càng lớn
        hptheothoigian = 0;
        PlayerPrefs.SetInt("hptime", hptheothoigian);
        PlayerPrefs.Save();


        Time.timeScale = 1;
        ni = GetComponent<Animator>();
        damage = 30;
        PlayerPrefs.SetInt("damage", 30);
        PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update()
    {
        // thời gian càng lâu hp con quái càng lớn
        timehp -= Time.deltaTime;
        if (timehp < 0)
        {
            hptheothoigian += 10;
            PlayerPrefs.SetInt("hptime", hptheothoigian);
            PlayerPrefs.Save();
            timehp = 30;
        }


        if (checkrobot.activeInHierarchy)
        {
            ni.SetBool("ROBOT2", true);

        }
        else
        {

            ni.SetBool("ROBOT2", false);


        }


        // thời gian bắn đạn
        timefire -= Time.deltaTime;

        if (timefire < 0)
        {
            firebullet();
        }


    }

    void firebullet()
    {
        timefire = TimeFire;
        // tạo một viện đạn 
        butllettmonter = Instantiate(bullet, fireadd1.position, Quaternion.identity);
        // lực viên đạn chạy 
        rb1 = butllettmonter.GetComponent<Rigidbody2D>();
        rb1.AddForce(transform.up * speedfire, ForceMode2D.Impulse);
        if (lvup)
        {
            bulletlvup = Instantiate(bullet, fireaddlvup.position, Quaternion.identity);
            // lực đạn
            rb1 = bulletlvup.GetComponent<Rigidbody2D>();
            rb1.AddForce(transform.up * speedfire, ForceMode2D.Impulse);


            bulletlvup2 = Instantiate(bullet, fireaddlvup2.position, Quaternion.identity);
            // lực đạn
            rb1 = bulletlvup2.GetComponent<Rigidbody2D>();
            rb1.AddForce(transform.up * speedfire, ForceMode2D.Impulse);
        }
    }


    void tatlvup()
    {
        ni.SetBool("uplvpl2", false);

        lvup = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "leverup")
        {
            audioSource.PlayOneShot(cliplvup);
            if (damage < 70)
            {
                damage += 10;

                PlayerPrefs.SetInt("damage", damage);
                PlayerPrefs.Save();
            }
            if (damage >= 70)
            {
                float tat = 9f;
                lvup = true;
                ni.SetBool("uplvpl2", true);
                Invoke("tatlvup", tat);
            }
        }





        if (collision.gameObject.tag == "bulletmonter")
        {
            if (checkrobot.activeInHierarchy)
            {
                rand();

            }
            else
            {
                Gover();
            }

        }

        void rand()
        {
            // bất tử thánh thân
            // khi trúng đạn có 80% tỷ lệ không nhận sát thương 
            random = Random.Range(1, 10);
            if (random <= 8)
            {
                damage += 5;

                PlayerPrefs.SetInt("damage", damage);
                PlayerPrefs.Save();
            }
            if (random > 8)
            {
                Gover();
            }
        }


        void Gover()
        {
            gameover.SetActive(true);
            Time.timeScale = 0;
            audioSource.PlayOneShot(Clipdie);
            br.Pause();
        }
    }
}
        
