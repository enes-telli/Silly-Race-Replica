using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Compatible with any opponent count, not only 10
public class PlayerRanking : MonoBehaviour
{
    [SerializeField] List<float> waypointsZ;

    private int currentWaypoint = 0;
    private OpponentController[] opponents;
    private int opponentCount;
    private int playerRank;

    private void Start()
    {
        opponents = FindObjectsOfType<OpponentController>();
        opponentCount = opponents.Length;
    }

    private void Update()
    {
        UpdateCurrentWaypoint();
        UpdatePlayerRank();
    }

    private void UpdateCurrentWaypoint()
    {
        if (transform.position.z >= waypointsZ[currentWaypoint])
        {
            currentWaypoint++;
        }
        if (currentWaypoint != 0 && transform.position.z <= waypointsZ[currentWaypoint - 1])
        {
            currentWaypoint--;
        }
    }

    private void UpdatePlayerRank()
    {
        playerRank = opponentCount + 1;
        for (int i = 0; i < opponentCount; i++)
        {
            if (currentWaypoint > opponents[i].GetCurrentWaypoint())
            {
                playerRank--;
            }
            else if (currentWaypoint == opponents[i].GetCurrentWaypoint())
            {
                if (transform.position.z > opponents[i].transform.position.z)
                {
                    playerRank--;
                }
            }
        }
    }

    public int GetCurrentRank()
    {
        return playerRank;
    }

    public void ResetTheProgress()
    {
        currentWaypoint = 0;
    }
}
