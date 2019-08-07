using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 0;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public SpriteRenderer sr;
    public Rigidbody rb;
    private Animator anim;
    //public bool grounded;
    public LayerMask floor;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        print(isGrounded());
        speed = Input.GetAxis("Horizontal") * 15f;
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
        {
            anim.enabled = true;
            anim.SetInteger("Direction", 2);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.enabled = true;
            anim.SetInteger("Direction", 1);
        }
        else
        {
            anim.enabled = false;
            if (anim.GetInteger("Direction") == 1)
            {
                sr.sprite = leftSprite;
            }
            else if (anim.GetInteger("Direction") == 2)
            {
                sr.sprite = rightSprite;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 14), ForceMode2D.Impulse);
        }
    }

    bool isGrounded()
    {
        return GetComponent<BoxCollider2D>().IsTouchingLayers(floor);
    }

}
