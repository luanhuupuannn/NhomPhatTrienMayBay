using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuaManCollider : MonoBehaviour
{

    public GameObject Win;
    public int indexmanchoi;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "quaman")
        {
            Win.SetActive(true);
            Invoke("backStory", 3f);
            PlayerPrefs.SetInt("indexmanchoi", indexmanchoi);
        }
    }

    void backStory()
    {
        SceneManager.LoadScene(3);
    }
}
