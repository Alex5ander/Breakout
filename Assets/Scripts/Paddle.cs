using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] Settings settings;
    [SerializeField] float Speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = settings.paddleSprite;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 copyPositon = transform.position;
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        copyPositon.x = Mathf.Clamp(p.x, -2.65f, 2.65f);
        transform.position = copyPositon;
    }
}
