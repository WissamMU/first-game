using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class PlayerMovmint : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;
    Animation anim;
    SpriteRenderer sprite;


    enum state { idel , running , jumping , falling }

    [SerializeField] float jumpForce =8f;
    [SerializeField] float MovingSpeed = 7f;
    float dirctX = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        dirctX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (dirctX * MovingSpeed, rb.velocity.y);

        PlayerAnimtion();
    }


    private void PlayerAnimtion()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(0, jumpForce);
        }
        
    }
}
