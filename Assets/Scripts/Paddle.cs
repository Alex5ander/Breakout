using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] Settings settings;
    [SerializeField] float Speed;
    float horizontal = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = settings.paddleSprite;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 copyPositon = transform.position;
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetMouseButton(0))
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            copyPositon.x = Mathf.Clamp(p.x, -2.65f, 2.65f);
            transform.position = copyPositon;
        }
        else
        {
            copyPositon += new Vector2(horizontal * Time.deltaTime * Speed, 0);
            copyPositon.x = Mathf.Clamp(copyPositon.x, -2.65f, 2.65f);
            transform.position = copyPositon;
        }
    }
}
