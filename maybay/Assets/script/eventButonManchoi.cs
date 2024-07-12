using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class eventButonManchoi : MonoBehaviour
{
    private string manchoix;


    public GameObject ma1;
    public GameObject ma2;
    public GameObject ma3;
    public GameObject ma4;
    public GameObject ma5;
    public GameObject ma6;
    public GameObject ma7;
    public GameObject ma8;
    public GameObject ma9;
    public GameObject ma10;


    int manchoicaonhat;
    int manchoihientai;
    // Start is called before the first frame update
    void Start()
    {
       String name = PlayerPrefs.GetString("savename");
        manchoix = "https://apibanmaybay.onrender.com/api/updatex/" + name;

        manchoicaonhat = PlayerPrefs.GetInt("indexmancaonhat");
        manchoihientai = PlayerPrefs.GetInt("indexmanchoi");
        if (manchoicaonhat < manchoihientai)
        {
            manchoicaonhat  = manchoihientai;
            PlayerPrefs.SetInt("indexmancaonhat", manchoicaonhat);
            PlayerPrefs.SetInt("indexmanchoi", 0);


            string jsonDatax = "{\"x\":\"" + manchoicaonhat + "\"}";
            StartCoroutine(PostRequestx(jsonDatax));


        }

        // Tạo mảng GameObject
        GameObject[] gos = new GameObject[] { ma1, ma2, ma3, ma4, ma5, ma6,ma7,ma8,ma9,ma10};

        // Sử dụng vòng lặp for để setActive("false") cho từng GameObject
        for (int i = 0; i <= manchoicaonhat; i++)
        {
            gos[i].SetActive(true);
        }
    }

    // cập nhật màn chơi cao nhất 
    IEnumerator PostRequestx(string jsonDatax)
    {
        // Tạo request
        using (UnityWebRequest request = new UnityWebRequest(manchoix, "PUT"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            // Gửi dữ liệu JSON
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonDatax);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            // Đợi phản hồi từ server
            yield return request.SendWebRequest();


            // Kiểm tra lỗi
            if (request.result != UnityWebRequest.Result.Success)
            {

                Debug.LogError("Error: " + request.error);
            }
            else
            {
                // Xử lý phản hồi thành công

                //  Debug.Log("Response: " + request.downloadHandler.text);
                string json = request.downloadHandler.text;
                // Debug.Log("Response: " + responseJson);
                try
                {
                    ResponseData responseData = JsonUtility.FromJson<ResponseData>(json);

                    if (responseData.status == 200)
                    {

                        Debug.Log("cập nhật màn chơi cao nhất thành công");

                    }
                    else
                    {

                        Debug.Log("cập nhật màn chơi thất bại");


                    }
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Error parsing JSON response: " + e.Message);
                }



            }
            request.Dispose();
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
        SceneManager.LoadScene(7);

    }
    public void man5()
    {
        SceneManager.LoadScene(8);

    }
    public void man6()
    {
        SceneManager.LoadScene(9);

    }
    public void man7()
    {
        SceneManager.LoadScene(10);

    }
    public void man8()
    {
        SceneManager.LoadScene(11);

    }
    public void man9()
    {
        SceneManager.LoadScene(12);

    }
    public void man10()
    {
        SceneManager.LoadScene(13);

    }


}
