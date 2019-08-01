using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 5f;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public SpriteRenderer sr;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            sr.sprite = rightSprite;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            sr.sprite = leftSprite;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector3.up * 1f;
        }
    }
}
