using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blBOSS : MonoBehaviour
{
    float moveSpeed = 8;
    public float x, y;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(x, y), moveSpeed * Time.deltaTime);

    }
}
