using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 Offset;
    [SerializeField] private float CameraSpeed;
    private Vector3 playerFowrard;

    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        playerFowrard = (playerRb.linearVelocity + player.forward).normalized;
        transform.position = Vector3.Lerp(transform.position, player.position + player.transform.TransformVector(Offset) + playerFowrard * (-5f), CameraSpeed * Time.deltaTime);
        transform.LookAt(player);
    }
}
