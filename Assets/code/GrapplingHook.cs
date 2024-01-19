using UnityEngine;


public class GrapplingHook : MonoBehaviour
{
    [SerializeField] float launchSpeed = 10f;
    [SerializeField] float pullSpeed = 15f;
    [SerializeField] LayerMask groundLayer;  // Define a LayerMask for ground objects
    [SerializeField] Rigidbody2D playerRigidbody;

    private bool isGrappling = false;
    private Transform grapplePoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray to check for ground objects
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, Mathf.Infinity, groundLayer);

            if (hit.collider != null && hit.collider.gameObject.tag == "Ground")
            {
                grapplePoint = hit.transform;
                isGrappling = true;

                // Launch the hook (visually or through a projectile)
                LaunchHook();
            }
        }

        if (isGrappling)
        {
            PullPlayer();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isGrappling = false;
            grapplePoint = null;
        }
    }

    void LaunchHook()
    {
        // Add code to visualize the hook launch here
    }

    void PullPlayer()
    {
        Vector2 direction = (grapplePoint.position - transform.position).normalized;
        playerRigidbody.velocity = direction * pullSpeed;
    }
}