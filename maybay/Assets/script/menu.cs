using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipClick;
    public GameObject CDskill2;

    public GameObject CDskill;
    public GameObject robot2;
    public GameObject infSkillROBOT2;
    public GameObject infSkillROBOT1;

    public GameObject robot;

    public GameObject PlayMode;
    
    public GameObject pausegame;
    public float savedCameraSize; // Variable to store the adjusted camera size


    public int saveplayer;
    public int selec;
    public GameObject splayer1;
    public GameObject splayer2;
    public GameObject panelselecpler;

    public GameObject setting;

    public Camera mainCamera; // Reference to the main camera


    int coinmenu;
    public GameObject gameover;
    private void Start()
    {

      

        // -1f as default if not saved


        float loadedSize = PlayerPrefs.GetFloat("SavedCameraSize", -1f); // -1f as default if not saved
        if (loadedSize > 0)
        {
            mainCamera.orthographicSize = loadedSize;
        }
        audioSource = GetComponent<AudioSource>();
        mainCamera = Camera.main; // Get the main camera in Start


    }
    private void Update()
    {

        
    }
    public void revival()
    {
       coinmenu = PlayerPrefs.GetInt("savecoin");

        if( coinmenu < 200 )
        {
        
        
        
        }
        else
        {
            coinmenu -= 200;
            PlayerPrefs.SetInt("savecoin", coinmenu);
            PlayerPrefs.Save();

            gameover.SetActive(false);
            Time.timeScale = 1;
        }
      

    }



    public void settings()
    {
        setting.SetActive(true);
    }
    public void UIcong()
    {
        audioSource.PlayOneShot(clipClick);
        mainCamera.orthographicSize += 1; // Decrease orthographic size by 1 unit 6.43912
        if(mainCamera.orthographicSize > 7.53)
        {
            mainCamera.orthographicSize = 7.53f;
            savedCameraSize = mainCamera.orthographicSize; // Save the adjusted size
        }

    }
    public void UItru()
    {
        audioSource.PlayOneShot(clipClick);
        mainCamera.orthographicSize -= 1; // Decrease orthographic size by 1 unit 6.43912
        if (mainCamera.orthographicSize < 6.50)
        {
            mainCamera.orthographicSize = 6.50f;
            savedCameraSize = mainCamera.orthographicSize; // Save the adjusted size
        }

    }

    public void oke()
    {
         PlayerPrefs.SetFloat("SavedCameraSize", savedCameraSize); // Lưu kích thước vào PlayerPrefs
        setting.SetActive(false);
    }
    public void exit()
    {
        Application.Quit();

    }
    public void OpenplayMode()
    {
        PlayMode.SetActive(true);
    }
    public void OffPlayMode()
    {
        PlayMode.SetActive(false);

    }

    public void play()
    {
         mainCamera = Camera.main;
        audioSource.PlayOneShot(clipClick);
        Invoke("plays", 0.4f);
    }
    private void plays()
    {
        mainCamera = Camera.main;
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
        // Load and apply saved camera size if available (optional)
        float loadedSize = PlayerPrefs.GetFloat("SavedCameraSize", -1f); // -1f as default if not saved
        if (loadedSize > 0)
        {
            mainCamera.orthographicSize = loadedSize;
        }
    }
    public void exitmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    

    public void playagain()
    {
        audioSource.PlayOneShot(clipClick);

        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    
    public void pause()
    {
        audioSource.PlayOneShot(clipClick);

        pausegame.SetActive(true);
        Time.timeScale = 0;
    }

    public void resume()
    {
        audioSource.PlayOneShot(clipClick);

        Time.timeScale = 1;
        pausegame.SetActive(false);

    }
    public void Story()
    {
        SceneManager.LoadScene(3);
    }

    // skill của máy bay 1
    public void ROBOT()
    {
        robot.SetActive(true);
        CDskill.SetActive(true);
        Invoke("TurnOffRobot", 5f);
        Invoke("offCDSkill", 18f);
    }

    // skill của máy bay 2
    public void ROBOT2()
    {
        robot2.SetActive(true);
        CDskill2.SetActive(true);
        Invoke("TurnOffRobot2", 9f);
        Invoke("offCDSkill2", 30f);
    }

    public void InFoSkillROBOT2()
    {
        infSkillROBOT2.SetActive(true);
        Invoke("offInFoSkillROBOT2", 10f);
    }
    void offInFoSkillROBOT2()
    {
        infSkillROBOT2.SetActive(false);

    }

    public void InFoSkillROBOT1()
    {
        infSkillROBOT1.SetActive(true);
        Invoke("offInFoSkillROBOT1", 10f);
    }
    void offInFoSkillROBOT1()
    {
        infSkillROBOT1.SetActive(false);

    }

    void TurnOffRobot2()
    {
        robot2.SetActive(false);
    }
    void TurnOffRobot()
    {
        robot.SetActive(false);
    }
     void offCDSkill()
    {
        CDskill.SetActive(false);
    }
    void offCDSkill2()
    {
        CDskill2.SetActive(false);
    }


  public  void player1()
    {
        selec = 1;
        PlayerPrefs.SetInt("saveplayer", selec);
        PlayerPrefs.Save();
        splayer1.SetActive(true);

        splayer2.SetActive(false);
        panelselecpler.SetActive(false);

    }

  public  void player2()
    {
        selec = 2;
        PlayerPrefs.SetInt("saveplayer", selec);
        PlayerPrefs.Save();

        splayer1.SetActive(false);

        splayer2.SetActive(true);
        panelselecpler.SetActive(false);

    }

   public void plane()
    {
        panelselecpler.SetActive(true);
    }

}
