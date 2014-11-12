using UnityEngine;
using System.Collections;

public class ItemDropManipulator : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Collider colliderToDisable;

    AutoTimer countdownTimer;
    bool hasStoppedMovement = false;

    Vector3 rotation = Vector3.up;

    void Start()
    {
        countdownTimer = new AutoTimer(3);

        Vector3 force = new Vector3(Random.Range(-10, 10), 15, Random.Range(-10, 10));
        rigidbody.AddForce(force * 10);

        rotation.y *= rotationSpeed;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if (countdownTimer.IsDone())
            {
                hasStoppedMovement = true;
            }
        }
        else
        {
            Vector3 force = new Vector3(Random.Range(-10, 10), 5, Random.Range(-10, 10));
            rigidbody.AddForce(force * 10);
        }
    }

    void LateUpdate()
    {
        transform.Rotate(rotation);

        if (hasStoppedMovement)
        {
            hasStoppedMovement = false;
            colliderToDisable.enabled = false;
            Destroy(gameObject.rigidbody);
        }
    }
}
