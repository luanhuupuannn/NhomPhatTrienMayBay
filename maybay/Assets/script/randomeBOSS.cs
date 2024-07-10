using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomeBOSS : MonoBehaviour
{
    public GameObject monster;
    public float timeToAddMonster;

    float timeToAddMonsterInternal;

    public GameObject warning;
    public GameObject autouRboss;



    public GameObject A; // Giả sử đây là đối tượng đại diện cho con quái vật bị tiêu diệt

    // Start is called before the first frame update
    void Start()
    {
        timeToAddMonsterInternal = timeToAddMonster;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToAddMonsterInternal > 0)
        {
            timeToAddMonsterInternal -= Time.deltaTime;


            if (timeToAddMonsterInternal <= 5)
            {
                warning.SetActive(true);
            }

            if (timeToAddMonsterInternal <= 0)
            {
                warning.SetActive(false);
                AddMonster();
                // Đặt cờ sau khi tạo thành công
                A.SetActive(false);

            }
        }

       
    }

    public void AddMonster()
    {
        if (monster)
        {
            Vector2 monsterAdd = new Vector3(-0.06f, 13.3f, 180);
            Instantiate(monster, monsterAdd, Quaternion.identity);
            autouRboss.SetActive(false);
            timeToAddMonsterInternal = timeToAddMonster;


        }
    }

  

}
