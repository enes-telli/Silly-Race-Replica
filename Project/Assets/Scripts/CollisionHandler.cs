using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private Vector3 startPos = new Vector3(0f, 0.05420721f, -45f);

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Player"))
        {
            go.GetComponent<PlayerRanking>().ResetTheProgress();
            go.transform.position = startPos + new Vector3(Random.Range(-9f, 9f), 0f, 0f);
        }
        else if (go.CompareTag("Opponent"))
        {
            go.GetComponent<OpponentController>().agent.Warp(startPos + new Vector3(Random.Range(-9f, 9f), 0f, 0f));
            go.GetComponent<OpponentController>().agent.SetDestination(new Vector3(Random.Range(-9f, 9f), transform.position.y, 305));
            collision.gameObject.GetComponent<OpponentController>().ResetTheProgress();
        }
    }
}
