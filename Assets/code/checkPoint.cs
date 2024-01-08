using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerLife playerlife;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        playerlife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("PlayerCheck");
            playerlife.UpdateCheckPoint(transform.position);
        }
    }
}
