using UnityEngine;

public class CameraPlace : MonoBehaviour
{
    [SerializeField] Transform Player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.position.x,Player.position.y ,transform.position.z);
    }
}
