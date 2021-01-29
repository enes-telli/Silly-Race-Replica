using UnityEngine;

public class StickRotation : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float minAngle;
    [SerializeField] float maxAngle;

    private void Update()
    {
        float rotation = Mathf.Lerp(minAngle, maxAngle, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
