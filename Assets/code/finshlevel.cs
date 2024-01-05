using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class finshlevel : MonoBehaviour
{
    AudioSource finshingsound;
    void Start()
    {
        finshingsound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            finshingsound.Play();
            finshingLevel();
        }
    }
    private void finshingLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
