using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bl2Boss : MonoBehaviour
{
    public bool isArrived = false;
    public GameObject bigbang;

    public float speed; // Tốc độ di chuyển của viên đạn
    public Transform player; // Biến để lưu trữ vị trí của object player
    private Vector3 targetPosition; // Vị trí đầu tiên của player

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Tìm kiếm object player và lưu trữ vị trí của nó
        targetPosition = player.position; // Lưu trữ vị trí đầu tiên của player
    }

    void Update()
    {
        // Di chuyển viên đạn về phía vị trí đầu tiên của player
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Kiểm tra xem viên đạn đã đến đích hay chưa
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isArrived = true;
        }

        // Xóa viên đạn nếu đã đến đích
        if (isArrived)
        {
            bigbang.SetActive(true);

            Destroy(gameObject,2f);
        }
    }


}
