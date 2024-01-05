using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class PlayerMovmint : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;
    Animator anim;
    SpriteRenderer sprite;

    [SerializeField] LayerMask jumpGround;


    enum MovingState { idel , running , jumping , falling }


    [SerializeField] float jumpForce =14f;
    [SerializeField] float MovingSpeed = 7f;
    float dirctX = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirctX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (dirctX * MovingSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && OnGround() )
        {
            rb.velocity = new Vector2(0, jumpForce);
        }

        PlayerAnimtion();
    }


    private void PlayerAnimtion()
    {
        MovingState state;
        if (dirctX > 0f)
        {
            state = MovingState.running;
            sprite.flipX = false;
        }
        else if (dirctX < 0f)
        {
            state = MovingState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovingState.idel;
        }
        if (rb.velocity.y > 0.1f)
        {
            state = MovingState.jumping;
        }
        else if (rb.velocity.y < -00.1f)
        {
            state = MovingState.falling;
        }
        anim.SetInteger("state",(int)state);
    }
    bool OnGround()
    {
        return Physics2D.BoxCast(coll.bounds.center , coll.bounds.size , 0f , Vector2.down , .1f ,jumpGround);
    }
}