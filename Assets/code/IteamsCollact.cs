using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IteamsCollact : MonoBehaviour
{
    int Strawberry = 0;
    [SerializeField] Text Strawberrycount;
    [SerializeField] AudioSource collactsound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            collactsound.Play();
            Destroy(collision.gameObject);
            Strawberry++;
            Strawberrycount.text = "Strawberry: " + Strawberry;

        }
    }
}
