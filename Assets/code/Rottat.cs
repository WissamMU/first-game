using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rottat : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    void Update()
    {
        transform.Rotate(0,0, 360 *speed * Time.deltaTime);
    }
}
