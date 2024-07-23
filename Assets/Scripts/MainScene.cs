using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    [SerializeField] Image ball;
    [SerializeField] Image paddle;
    [SerializeField] List<Sprite> balls;
    [SerializeField] List<Sprite> paddles;
    int ballIndex = 0;
    int paddleIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        ball.sprite = GameManager.Instance.ballSprite;
        paddle.sprite = GameManager.Instance.paddleSprite;
        ballIndex = balls.FindIndex(e => e == ball.sprite);
        paddleIndex = paddles.FindIndex(e => e == paddle.sprite);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayClick()
    {
        SceneManager.LoadScene(1);
    }

    public void NextBall()
    {
        ballIndex += 1;
        if (ballIndex > balls.Count - 1)
        {
            ballIndex = 0;
        }
        ball.sprite = balls[ballIndex];
        GameManager.Instance.ballSprite = ball.sprite;
    }
    public void PreviousBall()
    {
        ballIndex -= 1;
        if (ballIndex < 0)
        {
            ballIndex = balls.Count - 1;
        }
        ball.sprite = balls[ballIndex];
        GameManager.Instance.ballSprite = ball.sprite;
    }

    public void NextPaddle()
    {
        paddleIndex += 1;
        if (paddleIndex > paddles.Count - 1)
        {
            paddleIndex = 0;
        }
        paddle.sprite = paddles[paddleIndex];
        GameManager.Instance.paddleSprite = paddle.sprite;
    }
    public void PreviousPaddle()
    {
        paddleIndex -= 1;
        if (paddleIndex < 0)
        {
            paddleIndex = paddles.Count - 1;
        }
        paddle.sprite = paddles[paddleIndex];
        GameManager.Instance.paddleSprite = paddle.sprite;
    }
}
