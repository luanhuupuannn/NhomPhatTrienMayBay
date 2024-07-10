using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.SocialPlatforms.Impl;

public class DameInBoss : MonoBehaviour
{

    public thanhmau thanhmau;
    public float nowhp;
     float maxhp = 2000;

    public GameObject dark;
    public GameObject again;

    public GameObject coinbox;
    public GameObject scorebox;
    public Transform addcoinscorebox;

    public int dame;

    Animator animator;
    int hptime;


    void Start()
    {
        // lấy hp thời gian cộng vô hp gốc
        hptime = PlayerPrefs.GetInt("hptime");
        maxhp = maxhp + hptime;


        dame = PlayerPrefs.GetInt("damage");

        animator = GetComponent<Animator>();

        // cập nhật thanh máu 
        nowhp = maxhp;
        thanhmau.capnhatthanhmau(nowhp, maxhp);


    }

    private void Update()
    {
        dame = PlayerPrefs.GetInt("damage");


        if (nowhp <= 1000 )
        {
            dark.SetActive(true);
        }
        if(nowhp < 0)
        {
            dark.SetActive(false);
            ADDagain();

            StartCoroutine(DelayedDestroy());


        }


    }


    IEnumerator DelayedDestroy()
    {

        yield return new WaitForSeconds(0.5f);  // Wait for 1 second
        GameObject bulletInstance = Instantiate(scorebox, addcoinscorebox.position, addcoinscorebox.rotation);
      
        GameObject bulletInstance12 = Instantiate(coinbox, addcoinscorebox.position, addcoinscorebox.rotation);

        animator.SetBool("desboss", true);  // Set the animation parameter immediately
        Destroy(this.gameObject);  // Destroy the game object after the delay


    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bulletplayer")
        {
            nowhp -= 2;
            thanhmau.capnhatthanhmau(nowhp, maxhp);
        }
        if (collision.gameObject.tag == "bulletplayer2")
        {

            nowhp -= 4;
            thanhmau.capnhatthanhmau(nowhp, maxhp);
        }
        // player2
        else if (collision.gameObject.tag == "blplayer2")
        {
            nowhp -= dame;
            thanhmau.capnhatthanhmau(nowhp, maxhp);
        }
        else if (collision.gameObject.tag == "bulletROBOT2")
        {          
        }




    }


   
    public void ADDagain()
    {
        if (again)
        {
            Vector2 monsterAdd = new Vector3(8.613373f, 10.04835f, 180);
            Instantiate(again, monsterAdd, Quaternion.identity);
        }
    }

}
