using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class eventButonManchoi : MonoBehaviour
{


    public GameObject ma1;
    public GameObject ma2;
    public GameObject ma3;
    public GameObject ma4;


    int manchoicaonhat;
    int manchoihientai;
    // Start is called before the first frame update
    void Start()
    {
        manchoicaonhat = PlayerPrefs.GetInt("indexmancaonhat");
        manchoihientai = PlayerPrefs.GetInt("indexmanchoi");
        if (manchoicaonhat < manchoihientai)
        {
            manchoicaonhat  = manchoihientai;
            PlayerPrefs.SetInt("indexmancaonhat", manchoicaonhat);


        }

        // Tạo mảng GameObject
        GameObject[] gos = new GameObject[] { ma1, ma2, ma3, ma4 };

        // Sử dụng vòng lặp for để setActive("false") cho từng GameObject
        for (int i = 0; i <= manchoicaonhat; i++)
        {
            gos[i].SetActive(true);
        }
    }

    public void man1()
    {
        SceneManager.LoadScene(4);
    }
    public void man2()
    {
        SceneManager.LoadScene(5);

    }
    public void man3()
    {
        SceneManager.LoadScene(6);

    }
    public void man4()
    {

    }


}
