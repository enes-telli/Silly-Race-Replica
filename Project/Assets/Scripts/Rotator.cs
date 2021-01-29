using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float pushForce = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = transform.position - collision.contacts[0].point;
        collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 5, (direction.z <= 0) ? 5 : -5) * pushForce;
    }
}
