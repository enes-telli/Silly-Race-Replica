using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankVisualiser : MonoBehaviour
{
    [SerializeField] Text rankText;

    private PlayerRanking playerRanking;

    void Start()
    {
        playerRanking = FindObjectOfType<PlayerRanking>();
    }

    void Update()
    {
        UpdateRankText();
    }

    private void UpdateRankText()
    {
        rankText.text = "RANK: " + playerRanking.GetCurrentRank();
    }
}
