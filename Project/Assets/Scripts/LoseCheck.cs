using UnityEngine;

public class LoseCheck : MonoBehaviour
{
    private Vector3 startPos = new Vector3(0f, 0.05420721f, -45f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerRanking>().ResetTheProgress();
            other.transform.position = startPos + new Vector3(Random.Range(-9f, 9f), 0f, 0f);
            other.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (other.gameObject.CompareTag("Opponent"))
        {
            other.gameObject.GetComponent<OpponentController>().ResetTheProgress();
            other.transform.position = startPos + new Vector3(Random.Range(-9f, 9f), 0f, 0f);
            other.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
