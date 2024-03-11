using UnityEngine;

public class SafeArea : MonoBehaviour
{
    [SerializeField] RectTransform safeArea;
    void Awake()
    {
        Bounds bounds = new();
        foreach (Collider2D collider in FindObjectsByType<Collider2D>(FindObjectsSortMode.None))
        {
            bounds.Encapsulate(collider.bounds);
        }
        bounds.Expand(1);
        float vertical = bounds.size.y;
        float horizontal = bounds.size.x * Camera.main.pixelHeight / Camera.main.pixelWidth;
        Camera.main.orthographicSize = Mathf.Max(vertical, horizontal) * .5f;
        Camera.main.transform.position = bounds.center + new Vector3(0, 0, -10);
        safeArea.anchorMin = new Vector2(Screen.safeArea.position.x / Screen.width, Screen.safeArea.position.y / Screen.height);
        safeArea.anchorMax = new Vector2((Screen.safeArea.position.x + Screen.safeArea.size.x) / Screen.width, (Screen.safeArea.position.y + Screen.safeArea.size.y) / Screen.height);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
