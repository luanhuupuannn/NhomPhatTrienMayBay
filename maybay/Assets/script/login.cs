using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using Newtonsoft.Json;
using UnityEngine.UI;
using TMPro;
using System;
using Newtonsoft.Json.Linq;
using System.Linq;

public class login : MonoBehaviour
{
    public TextMeshProUGUI messRG;
    public TextMeshProUGUI messLG;
    public GameObject Loading;

    public int Coin;
    public int Score;

    public InputField i_username, i_password;
    private string apiUrl = "https://apibanmaybay.onrender.com/api/checklogin";
     private string apibxh = "https://apibanmaybay.onrender.com/api/leaderboard";



    public InputField usernamerg, passwordrg,confimpasswordrg;
    private string apiUrlRG = "https://apibanmaybay.onrender.com/api/add-user";
    public GameObject loginpanel;
    public GameObject Regispanel;


    public GameObject cavaslogin;
    public GameObject btncavaslogin;

    public void btnLOGINgame()
    {
        cavaslogin.SetActive(true);
        btncavaslogin.SetActive(false);



    }


    public void btnRegister()
    {
        Regispanel.SetActive(true);
        loginpanel.SetActive(false);
    }
    public void btnback()
    {
        loginpanel.SetActive(true);
        Regispanel.SetActive(false);


    }


    public void checkLogin()
    {
        var u = i_username.text;
        var p = i_password.text;
        string jsonData = "{\"username\":\"" + u + "\",\"password\":\"" + p + "\"}";
        StartCoroutine(GetDataFromAPI());

        StartCoroutine(PostRequest(jsonData));
        Loading.SetActive(true);


    }

    public void register()
    {
        var urg = usernamerg.text;
        var prg = passwordrg.text;
        var cfprg = confimpasswordrg.text;

        if(prg != cfprg ) {

            messRG.text = "Không trùng Password";
            Debug.Log("không trùng pass");
        
        }
        else 
        {
            string jsonRegister = "{\"username\":\"" + urg + "\",\"password\":\"" + prg + "\"}";
            StartCoroutine(PostRegister(jsonRegister));
        }
        Loading.SetActive(true);





    }



    IEnumerator GetDataFromAPI()
    {
        // Tạo request để gọi API
        UnityWebRequest request = UnityWebRequest.Get(apibxh);

        // Gửi request và đợi phản hồi
        yield return request.SendWebRequest();

        // Kiểm tra xem có lỗi không
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Lỗi khi gọi API: " + request.error);
        }
        else
        {
            string responseData = request.downloadHandler.text;

            List<UserScore> userScores = ParseUserScores(responseData);

            string username1 = userScores[0].Username;
            string username2 = userScores[1].Username;


            string username3 = userScores[2].Username;
            string username4 = userScores[3].Username;
            string username5= userScores[4].Username;
            string username6 = userScores[5].Username;
            string username7 = userScores[6].Username;
            string username8 = userScores[7].Username;
            string username9 = userScores[8].Username;
            string username10 = userScores[9].Username;
            Debug.Log(username1);
            Debug.Log(username2);
            Debug.Log(username3);
            Debug.Log(username4);
            Debug.Log(username5);
            Debug.Log(username6);
            Debug.Log(username7);
            Debug.Log(username8);

            Debug.Log(username8);
            Debug.Log(username10);


            PlayerPrefs.SetString("user1", username1);
            PlayerPrefs.SetString("user2", username2);
            PlayerPrefs.SetString("user3", username3);
            PlayerPrefs.SetString("user4", username4);
            PlayerPrefs.SetString("user5", username5);

            PlayerPrefs.SetString("user6", username6);
            PlayerPrefs.SetString("user7", username7);
            PlayerPrefs.SetString("user8", username8);
            PlayerPrefs.SetString("user9", username9);
            PlayerPrefs.SetString("user10", username10);
            PlayerPrefs.Save();



            int score1 = userScores[0].Score;
            int score2 = userScores[1].Score;
            int score3 = userScores[2].Score;
            int score4 = userScores[3].Score;
            int score5 = userScores[4].Score;

            int score6 = userScores[5].Score;
            int score7 = userScores[6].Score;
            int score8 = userScores[7].Score;
            int score9 = userScores[8].Score;
            int score10 = userScores[9].Score;

            PlayerPrefs.SetInt("score1", score1);
            PlayerPrefs.SetInt("score2", score2);
            PlayerPrefs.SetInt("score3", score3);
            PlayerPrefs.SetInt("score4", score4);
            PlayerPrefs.SetInt("score5", score5);
            PlayerPrefs.SetInt("score6", score6);
            PlayerPrefs.SetInt("score7", score7);
            PlayerPrefs.SetInt("score8", score8);
            PlayerPrefs.SetInt("score9", score9);
            PlayerPrefs.SetInt("score10", score10);
            PlayerPrefs.Save();
        }

        Loading.SetActive(false); // Giả định Loading là để phản hồi trực quan
        yield return null;
    }

    private List<UserScore> ParseUserScores(string responseData)
    {
        List<UserScore> userScores = new List<UserScore>();

        try
        {
            // Phân tích dữ liệu JSON (giả sử đây là JSON hợp lệ)
            JObject jsonObj = JObject.Parse(responseData);

            // Kiểm tra trạng thái phản hồi thành công (sửa đổi nếu cần)
            if (jsonObj["status"].ToString() == "200")
            {
                // Trích xuất tên người dùng và điểm số từ mảng "data"
                JArray dataArray = (JArray)jsonObj["data"];

                userScores = dataArray.Select(jToken => new UserScore
                {
                    Username = (string)jToken["username"],
                    Score = (int)jToken["score"] // Giả sử điểm số là số nguyên
                }).ToList();
            }
            else
            {
                Debug.LogError("Trạng thái phản hồi API không phải 200: " + responseData);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Lỗi khi phân tích dữ liệu JSON: " + e.Message);
        }

        return userScores;
    }

    public class UserScore // Định nghĩa lớp tùy chỉnh để chứa tên người dùng và điểm số
    {
        public string Username { get; set; }
        public int Score { get; set; }
    }





    // ham dang nhap
    IEnumerator PostRequest(string jsonData)
    {
        // Tạo request
        using (UnityWebRequest request = new UnityWebRequest(apiUrl, "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            // Gửi dữ liệu JSON
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            // Đợi phản hồi từ server
            yield return request.SendWebRequest();
            Loading.SetActive(true);


            // Kiểm tra lỗi
            if (request.result != UnityWebRequest.Result.Success)
            {
                Loading.SetActive(false);

                Debug.LogError("Error: " + request.error);
            }
            else
            {
                // Xử lý phản hồi thành công
                Loading.SetActive(false);

                //  Debug.Log("Response: " + request.downloadHandler.text);
                string json = request.downloadHandler.text;
               // Debug.Log("Response: " + responseJson);
                try
                {
                    ResponseData responseData = JsonUtility.FromJson<ResponseData>(json);

                    if (responseData.status == 200)
                    {

                        Loading.SetActive(false);

                        // Load Scene 1 (assuming you have a scene named "Scene_1")
                        SceneManager.LoadScene(1);

                        userData[] manguser = responseData.data;
                        userData user = manguser[0];

                        string username = user.username;
                        // lưu coin vô màn hình
                        string iduser = user._id;
                        Score = user.score;
                        Coin = user.coin;
                        Debug.Log(iduser);

                        PlayerPrefs.SetString("saveusername", username);

                        PlayerPrefs.SetInt("savescore", Score);
                        PlayerPrefs.SetInt("savecoin", Coin);

                        PlayerPrefs.SetString("savename", user.username);


                        PlayerPrefs.Save();


                     
                    }
                    else
                    {
                        Loading.SetActive(false);

                        messLG.text = "Sai username hoặc Password";

                        Debug.LogWarning("API response status is not 200: " + responseData.status);
                     
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


    IEnumerator PostRegister(string jsonRegister)
    {
        // Tạo request
        using (UnityWebRequest request = new UnityWebRequest(apiUrlRG, "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            // Gửi dữ liệu JSON
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonRegister);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            // Đợi phản hồi từ server
            yield return request.SendWebRequest();
            Loading.SetActive(true);

            // Kiểm tra lỗi
            if (request.result != UnityWebRequest.Result.Success)
            {
                Loading.SetActive(false);

                Debug.LogError("Error: " + request.error);
            }
            else
            {
                // Xử lý phản hồi thành công
                Loading.SetActive(false);

                //  Debug.Log("Response: " + request.downloadHandler.text);
                string json = request.downloadHandler.text;
                // Debug.Log("Response: " + responseJson);
                try
                {
                    ResponseData responseData = JsonUtility.FromJson<ResponseData>(json);

                    if (responseData.status == 200)
                    {
                        Loading.SetActive(false);

                        loginpanel.SetActive(true);
                        Regispanel.SetActive(false);


                    }
                    else
                    {
                        Loading.SetActive(false);

                        messRG.text = "Tên đăng nhập đã được sử dụng";
                        Debug.LogWarning("API response status is not 200: " + responseData.status);

                    }
                }
                catch (System.Exception e)
                {
                    Loading.SetActive(false);

                    Debug.LogError("Error parsing JSON response: " + e.Message);
                }



            }
            request.Dispose();
        }
    }



}

[System.Serializable]
public class ResponseData
{
    public int status;
    public string message;
    public userData[] data;

  

}

[System.Serializable]
public class userData
{
    public string _id, username, password, createdAt, updatedAt;
    public int score, x, y, coin, __v;


}

