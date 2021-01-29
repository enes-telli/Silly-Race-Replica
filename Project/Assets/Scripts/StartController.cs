using UnityEngine;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    [SerializeField] Text startText;
    [SerializeField] Text rankText;
    [SerializeField] OpponentController[] opponents;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < opponents.Length; i++)
            {
                opponents[i].enabled = true;
            }
            startText.enabled = false;
            rankText.enabled = true;
            Destroy(this);
        }
    }
}
