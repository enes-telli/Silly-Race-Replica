using UnityEngine;

public class ObstacleHorizontalMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float minXValue;
    [SerializeField] float maxXValue;

    private Vector3 pos1;
    private Vector3 pos2;

    void Start()
    {
        pos1 = new Vector3(minXValue, transform.localPosition.y, transform.localPosition.z);
        pos2 = new Vector3(maxXValue, transform.localPosition.y, transform.localPosition.z);
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f); // sin: [-1, 1], after addition and division: [0, 1]
    }
}
