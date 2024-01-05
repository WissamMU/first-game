using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypoitMove : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currrintwaypointindex = 0;

    [SerializeField] float PlatformSpeed = 2.0f;
    void Update()
    {
        if (Vector2.Distance(waypoints[currrintwaypointindex].transform.position, transform.position) < 0.1f)
        {
            currrintwaypointindex++;
            if (currrintwaypointindex >= waypoints.Length)
            {
                currrintwaypointindex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currrintwaypointindex].transform.position, Time.deltaTime * PlatformSpeed);
    }
}
