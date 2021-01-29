using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    [SerializeField] Text rankText;
    [SerializeField] Text infoText;
    [SerializeField] GameObject progressBar;

    private GameObject camera;
    private GameObject player;

    private void Start()
    {
        camera = FindObjectOfType<CameraMovement>().gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Animator>().SetBool("isRunning", false);

            camera.GetComponent<CameraMovement>().enabled = false;
            camera.GetComponent<CameraSwitch>().enabled = true;

            rankText.enabled = false;
            infoText.enabled = true;
            progressBar.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Opponent"))
        {
            other.GetComponent<OpponentController>().enabled = false;
            other.GetComponent<Animator>().SetBool("isRunning", false);
            other.GetComponent<OpponentController>().agent.Stop();
        }
    }
}
