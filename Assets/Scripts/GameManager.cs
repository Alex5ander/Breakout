using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Sprite paddleSprite;
    public Sprite ballSprite;

    public static GameManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
