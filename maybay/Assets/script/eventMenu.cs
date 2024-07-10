using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class eventMenu : MonoBehaviour
{
    public GameObject rankcava;



    public TextMeshProUGUI loadRank1;
    public TextMeshProUGUI loadRank2;
    public TextMeshProUGUI loadRank3;
    public TextMeshProUGUI loadRank4;
    public TextMeshProUGUI loadRank5;
    public TextMeshProUGUI loadRank6;
    public TextMeshProUGUI loadRank7;
    public TextMeshProUGUI loadRank8;
    public TextMeshProUGUI loadRank9;
    public TextMeshProUGUI loadRank10;

    public TextMeshProUGUI loadScore1;
    public TextMeshProUGUI loadScore2;
    public TextMeshProUGUI loadScore3;
    public TextMeshProUGUI loadScore4;
    public TextMeshProUGUI loadScore5;
    public TextMeshProUGUI loadScore6;
    public TextMeshProUGUI loadScore7;
    public TextMeshProUGUI loadScore8;
    public TextMeshProUGUI loadScore9;
    public TextMeshProUGUI loadScore10;



    private void Start()
    {




    }
    private void Update()
    {

        string user1 = PlayerPrefs.GetString("user1");
        string user2 = PlayerPrefs.GetString("user2");
        string user3 = PlayerPrefs.GetString("user3");
        string user4 = PlayerPrefs.GetString("user4");
        string user5 = PlayerPrefs.GetString("user5");
        string user6 = PlayerPrefs.GetString("user6");
        string user7 = PlayerPrefs.GetString("user7");
        string user8 = PlayerPrefs.GetString("user8");
        string user9 = PlayerPrefs.GetString("user9");
        string user10 = PlayerPrefs.GetString("user10");




        loadRank1.text = "1             " + user1;
        loadRank2.text = "2             " + user2;
        loadRank3.text = "3             " + user3;
        loadRank4.text = "4             " + user4;
        loadRank5.text = "5             " + user5;
        loadRank6.text = "6             " + user6;
        loadRank7.text = "7             " + user7;
        loadRank8.text = "8             " + user8;
        loadRank9.text = "9             " + user9;
        loadRank10.text = "10             " + user10;



        int score1 = PlayerPrefs.GetInt("score1");
        int score2 = PlayerPrefs.GetInt("score2");
        int score3 = PlayerPrefs.GetInt("score3");
        int score4 = PlayerPrefs.GetInt("score4");
        int score5 = PlayerPrefs.GetInt("score5");
        int score6 = PlayerPrefs.GetInt("score6");
        int score7 = PlayerPrefs.GetInt("score7");
        int score8 = PlayerPrefs.GetInt("score8");
        int score9 = PlayerPrefs.GetInt("score9");
        int score10 = PlayerPrefs.GetInt("score10");





        loadScore1.text = "" + score1;
        loadScore2.text = "" + score2;
        loadScore3.text = "" + score3;
        loadScore4.text = "" + score4;
        loadScore5.text = "" + score5;
        loadScore6.text = "" + score6;
        loadScore7.text = "" + score7;
        loadScore8.text = "" + score8;
        loadScore9.text = "" + score9;
        loadScore10.text = "" + score10;

    }


    public void openRank()
    {
        rankcava.SetActive(true);
    }

    public void cancelRank()
    {
        rankcava.SetActive(false);
    }

}
