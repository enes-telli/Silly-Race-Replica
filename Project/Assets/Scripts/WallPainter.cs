using UnityEngine;
using UnityEngine.UI;

public class WallPainter : MonoBehaviour
{
    [Header("Painting")]
    [SerializeField] int brushRadius = 16;
    [SerializeField] Slider paintProgress;
    [SerializeField] Text progressText;
    [SerializeField] Text congratsText;
    [SerializeField] Text infoText;

    private Renderer renderer;
    private Texture2D texture;
    private float totalPixelCount = 16384f; // width * height (128x128)
    private float paintedPixelCount = 0f;
    private float rSquared;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        texture = Instantiate(renderer.material.mainTexture) as Texture2D;
        renderer.material.mainTexture = texture;
        rSquared = brushRadius * brushRadius;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 clickPos = Input.mousePosition;
            float distance = Vector3.Dot(transform.position - Camera.main.transform.position, Camera.main.transform.forward);
            clickPos.z = distance;
            Vector3 pos = Camera.main.ScreenToWorldPoint(clickPos);
            if (pos.x >= -4f && pos.x <= 4f && pos.y >= 1f && pos.y <= 9f)
            {
                int x = Mathf.FloorToInt((pos.x + 4) / 0.1f * 1.6f); // casting world x coordinate to pixel x coordinate
                int y = Mathf.FloorToInt((pos.y - 1) / 0.1f * 1.6f); // casting world y coordinate to pixel y coordinate

                int xLimit = Mathf.Min(x + brushRadius + 1, 128);
                int yLimit = Mathf.Min(y + brushRadius + 1, 128);

                for (int u = 0; u < xLimit; u++)
                {
                    for (int v = 0; v < yLimit; v++)
                    {
                        if ((x - u) * (x - u) + (y - v) * (y - v) < rSquared)
                        {
                            if (texture.GetPixel(u, v).Equals(Color.white))
                            {
                                texture.SetPixel(u, v, Color.red);
                                paintedPixelCount += 1.0f;
                            }
                            
                        }
                    }
                }
                float value = paintedPixelCount / totalPixelCount;
                paintProgress.value = value;
                progressText.text = (value * 100).ToString("F0") + "%";

                if (Mathf.Approximately(paintProgress.value, 1f))
                {
                    SetTheUI();
                }

                texture.Apply();
            }

        }
    }

    private void SetTheUI()
    {
        infoText.enabled = false;
        congratsText.enabled = true;
        Camera.main.GetComponent<FinishCameraSwitch>().enabled = true;
        paintProgress.gameObject.SetActive(false);
    }
}
