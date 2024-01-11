using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    [Header("References")]
    PlayerMovmint pm;
    [SerializeField] Transform gunTip;
    [SerializeField] Transform cam;
    [SerializeField] LayerMask whatCanGrap;
    [SerializeField] LineRenderer lr;

    [Header("References")]
    [SerializeField] float maxGrapplingDistance;
    [SerializeField] float grapplingDelay;

    Vector2 grapplingPoint;

    [Header("Cooldown")]
    [SerializeField] float grapplingCooldown;
    float grapplingCooldownTimer;

    [Header("Input")]
    [SerializeField] KeyCode grapplingKey = KeyCode.Mouse1;

    bool grappling;

    void Start()
    {
        pm = GetComponent<PlayerMovmint>();

        lr.enabled = true;
        lr.SetPosition(1, gunTip.position);
    }

    private void Update()
    {
        if (Input.GetKeyDown(grapplingKey))
            StartGrapple();

        if (grapplingCooldownTimer > 0)
        {
            grapplingCooldownTimer -= Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if (grappling)
        {
            lr.SetPosition(0, gunTip.position);
        }
    }

    void StartGrapple()
    {
        if (grapplingCooldown > 0)
            return;

        grappling = true;

        RaycastHit2D hit = Physics2D.Raycast(cam.position, cam.forward, maxGrapplingDistance, whatCanGrap);
        if (hit.collider != null)
        {
            grapplingPoint = hit.point;

            Invoke(nameof(ExecuteGrappling), grapplingDelay);
        }
        else
        {
            grapplingPoint = (Vector2)cam.position + (Vector2)(cam.forward.normalized * maxGrapplingDistance);

            Invoke(nameof(StopGrappling), grapplingDelay);
        }
    }

    void ExecuteGrappling()
    {
        // Add code to perform actions when grappling is executed
    }

    private void StopGrappling()
    {
        grappling = false;

        grapplingCooldownTimer = grapplingCooldown;

        lr.enabled = false;
    }
}