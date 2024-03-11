using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    [SerializeField] Settings settings;
    [SerializeField] List<Image> images;
    // Start is called before the first frame update
    void Start()
    {
        UpdateImages();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateImages()
    {
        foreach (Image image in images)
        {
            Color color = Color.white;
            if (image.sprite != settings.paddleSprite && image.sprite != settings.ballSprite)
            {
                color.a = 0.5f;
            }
            image.color = color;
        }
    }

    public void OnPlayClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnSelectPaddle(Sprite sprite)
    {
        settings.paddleSprite = sprite;
        UpdateImages();
    }

    public void OnSelectBall(Sprite sprite)
    {
        settings.ballSprite = sprite;
        UpdateImages();
    }
}
