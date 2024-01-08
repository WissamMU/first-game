using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    Vector2 CheckPointPos;



    Animator anim;
    Rigidbody2D rb;
    [SerializeField] AudioSource deathsound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        CheckPointPos = transform.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("traps"))
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        deathsound.Play();
        Invoke("ResetLevel", 2f);

    }
    private void ResetLevel()
    {

        transform.position = CheckPointPos;
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("Playerappearing");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateCheckPoint(Vector2 pos)
    {
        CheckPointPos = pos;

    }
}
