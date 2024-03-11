using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip impactBrickAudio;
    [SerializeField] AudioClip impactPaddleAudio;
    [Header("Game Objects")]
    [SerializeField] GameOver gameOver;
    [SerializeField] Rigidbody2D body;
    [SerializeField] ParticleSystem particles;
    [SerializeField] Transform paddleTransform;
    [SerializeField] Settings settings;
    [Header("UI")]
    [SerializeField] TextMeshProUGUI ScoreTextUI;
    [SerializeField] List<Image> lifeImages;
    [SerializeField] float Speed;
    int score = 0;
    int life = 2;
    Vector2 paddleInitialPosition;
    Vector2 ballInitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = settings.ballSprite;
        ballInitialPosition = transform.localPosition;
        paddleInitialPosition = paddleTransform.position;
        foreach (Image image in lifeImages)
        {
            image.sprite = settings.ballSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            transform.SetParent(null);
            body.velocity = new(new float[] { -Speed, Speed }[Random.Range(0, 2)], Speed);
        }
    }

    void FixedUpdate()
    {
        if (body.position.y < paddleTransform.position.y - 0.25f && transform.parent == null)
        {
            if (life == 0)
            {
                gameOver.Show(false);
                Destroy(gameObject);
            }
            else
            {
                life -= 1;
                lifeImages[life].gameObject.SetActive(false);
                transform.position = ballInitialPosition;
                transform.SetParent(paddleTransform, false);
                body.velocity = Vector2.zero;
                paddleTransform.position = paddleInitialPosition;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Brick"))
        {
            AddScore();
            ParticleSystem p = Instantiate(particles, collision2D.gameObject.transform.position, Quaternion.identity);
            p.GetComponent<Renderer>().material.mainTexture = collision2D.gameObject.GetComponent<SpriteRenderer>().sprite.texture;
            Destroy(collision2D.gameObject);
            Destroy(p.gameObject, p.main.duration);
        }
        if (collision2D.collider.CompareTag("Player"))
        {
            audioSource.PlayOneShot(impactPaddleAudio);
        }
        else
        {
            audioSource.PlayOneShot(impactBrickAudio);
        }
        if (body.velocity.x == 0 || body.velocity.y == 0)
        {
            Vector2 copy = body.velocity;
            copy.x = copy.x == 0 ? Mathf.Sign(collision2D.transform.position.x - transform.position.x) : copy.x;
            copy.y = copy.y == 0 ? Mathf.Sign(collision2D.transform.position.y - transform.position.y) : copy.y;
            body.velocity = copy;
        }
    }

    void AddScore()
    {
        score += 1;
        ScoreTextUI.text = "Score: " + score;
        if (score == BricksGenerator.maxScore)
        {
            gameOver.Show(true);
        }
    }
}
