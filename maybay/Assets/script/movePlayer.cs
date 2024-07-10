using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    public bool isMouseDown = false;
    private float deltaX, deltaY;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    Vector2 newPos = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    // Giới hạn vị trí mới trong khu vực cho phép
                    newPos.x = Mathf.Clamp(newPos.x, -3f, 3f);
                    newPos.y = Mathf.Clamp(newPos.y, -4, 10);
                    // Di chuyển vật thể đến vị trí đã giới hạn
                    rb.MovePosition(newPos);
                    break;
                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;
            }
        }

    }
}
