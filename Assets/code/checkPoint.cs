using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    private GameMaster gm;
    void Start()
    {
        gm = GetComponent<GameMaster>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            gm.LastCheckPoinrpos = transform.position;
        }
    }
}
