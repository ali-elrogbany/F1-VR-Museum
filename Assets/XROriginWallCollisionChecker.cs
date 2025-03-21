using UnityEngine;

public class XROriginWallCollisionChecker : MonoBehaviour
{
    private Vector3 lastPosition;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Store the last valid position before movement
        lastPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with a wall
        if (other.CompareTag("Wall"))
        {
            // Move player back to last valid position
            characterController.enabled = false;
            transform.position = lastPosition;
            characterController.enabled = true;
        }
    }
}
