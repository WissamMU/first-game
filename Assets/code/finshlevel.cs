using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class finshlevel : MonoBehaviour
{
    AudioSource finshingsound;

    bool LeveledFinshed = false;

    void Start()
    {
        
        finshingsound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && LeveledFinshed == false)
        {
            GetComponent<Animator>().SetTrigger("winTrigger");
            finshingsound.Play();
            LeveledFinshed=true;
            Invoke("finshingLevel", 2f);
        }
    }
    private void finshingLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
