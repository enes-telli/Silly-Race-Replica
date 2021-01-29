using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] float rotatingSpeed = 10f;
    [SerializeField] Vector3 rotatingAxis;

    void Update()
    {
        transform.Rotate(rotatingAxis, rotatingSpeed * Time.deltaTime);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
