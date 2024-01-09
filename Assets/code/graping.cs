using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graping : MonoBehaviour
{
    public Camera Gcamers;
    public LineRenderer Glines;
    public DistanceJoint2D Gdesten;

    // Start is called before the first frame update
    void Start()
    {
        Gdesten.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousepos = (Vector2)Gcamers.ScreenToViewportPoint(Input.mousePosition);
            Glines.SetPosition(0, mousepos);
            Glines.SetPosition(1, transform.position);
            Gdesten.connectedAnchor = mousepos;
            Gdesten.enabled = true;
            Glines.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Gdesten.enabled = false;
            Glines.enabled = false;
        }
        
        if (Gdesten.enabled)
        {
            Glines.SetPosition(1,transform.position);
        }
    }
}
