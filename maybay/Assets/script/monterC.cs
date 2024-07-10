using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monterC : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipmonterC;
    public float thoigianxoa = 2;

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clipmonterC);

    }

    // Update is called once per frame
    void Update()
    {
        thoigianxoa -= Time.deltaTime;
        if (thoigianxoa < 0)
        {
            Destroy(this.gameObject);
            thoigianxoa = 6f;
        }
    }


}
