using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerLife playerlife;
    private void Awake()
    {
        playerlife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerlife.UpdateCheckPoint(transform.position);
        }
    }

}
