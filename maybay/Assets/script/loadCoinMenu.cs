using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class loadCoinMenu : MonoBehaviour
{

    public TextMeshProUGUI loadcoin;
    public TextMeshProUGUI loadscore;
    public TextMeshProUGUI loadusername;


    string name;
    private string apiudatecoin ;
    private string apiudatescore;


    int coinmenu;
    int coinmanchoi;
    int scoremenu;
    int scoremanchoi;
    int cointong;

    // Start is called before the first frame update
    void Start()
    {
        name = PlayerPrefs.GetString("savename");
        apiudatescore = "https://apibanmaybay.onrender.com/api/updatescore/" + name;
        apiudatecoin = "https://apibanmaybay.onrender.com/api/updatecoin/" + name;

        scoremenu = PlayerPrefs.GetInt("savescore");
        scoremanchoi = PlayerPrefs.GetInt("savescoremanchoi");
        string username = PlayerPrefs.GetString("saveusername");
        loadusername.text = username;
        
        if (scoremenu < scoremanchoi)
        {
            scoremenu = scoremanchoi;
            PlayerPrefs.SetInt("savescore", scoremenu);
            PlayerPrefs.SetInt("savescoremanchoi", 0);
            PlayerPrefs.Save();
        }
        loadscore.text = "X" + scoremenu;



        coinmenu = PlayerPrefs.GetInt("savecoin");
        coinmanchoi = PlayerPrefs.GetInt("savecoinmanchoi");
         coinmenu = coinmenu + coinmanchoi ;
        PlayerPrefs.SetInt("savecoin", coinmenu);
        PlayerPrefs.SetInt("savecoinmanchoi", 0);
        PlayerPrefs.Save();
        loadcoin.text = "X" + coinmenu;





        // cointong = coinmenu + coinmanchoi;
        ;

        string jsonDatacoin = "{\"coin\":\"" + coinmenu + "\"}";
        StartCoroutine(PostRequestcoin(jsonDatacoin));



        string jsonDatascore = "{\"score\":\"" + scoremenu + "\"}";
        StartCoroutine(PostRequest(jsonDatascore));


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // cap nhat score
    IEnumerator PostRequest(string jsonDatascore)
    {
        // Tạo request
        using (UnityWebRequest request = new UnityWebRequest(apiudatescore, "PUT"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            // Gửi dữ liệu JSON
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonDatascore);
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

                        Debug.Log("thành công");

                    }
                    else
                    {

                        Debug.Log("thất bại");


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

    // cap nhat coin
    IEnumerator PostRequestcoin(string jsonDatacoin)
    {
        // Tạo request
        using (UnityWebRequest request = new UnityWebRequest(apiudatecoin, "PUT"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            // Gửi dữ liệu JSON
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonDatacoin);
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

                        Debug.Log("thành công");

                    }
                    else
                    {

                        Debug.Log("thất bại");


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

}
