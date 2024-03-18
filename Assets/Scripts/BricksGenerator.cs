using System.Collections.Generic;
using UnityEngine;

public class BricksGenerator : MonoBehaviour
{
    [SerializeField] List<Sprite> rectangles;
    [SerializeField] List<Sprite> squares;
    [SerializeField] List<Sprite> diamonds;
    [SerializeField] List<Sprite> polygons;
    [SerializeField] int cols;
    [SerializeField] int rows;
    public static int level = 1;
    public static int maxScore;
    // Start is called before the first frame update
    void Start()
    {
        int size = cols * rows;
        int c = cols;
        int r = rows;
        maxScore = 0;

        // int[,] grid = new int[6, 7] {
        //     {-1, -1, 0, 0, 0, -1, -1},
        //     {-1, 0, 1, 1, 1, 0, -1},
        //     {0, 1, 2, 2, 2, 1, 0},
        //     {0, 1, 2, 2, 2, 1, 0},
        //     {-1, 0, 1, 1, 1, 0, -1},
        //     {-1, -1, 0, 0, 0, -1,-1}
        // };
        // c = grid.GetLength(1);
        // r = grid.GetLength(0);
        // size = grid.GetLength(0) * grid.GetLength(1);

        List<List<Sprite>> sprites = new() { rectangles, squares, diamonds, polygons };
        List<Sprite> randomSprites = sprites[Random.Range(0, sprites.Count)];
        for (int i = 0; i < size; i++)
        {
            int x = i % c;
            int y = Mathf.FloorToInt(i / c) % r;

            // int a = grid[y, x];
            // if (a == -1)
            // {
            //     continue;
            // }

            maxScore += 1;
            Sprite sprite = randomSprites[Mathf.RoundToInt(y) % randomSprites.Count];
            float sx = sprite.bounds.size.x;
            float sy = sprite.bounds.size.y;
            CreateBrick(new Vector2(((c / 2) - x - 0.5f) * sx, transform.position.y - ((y - 0.5f) * sy)), sprite);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateBrick(Vector2 position, Sprite sprite)
    {
        GameObject brick = new();
        SpriteRenderer spriteRenderer = brick.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        brick.AddComponent<PolygonCollider2D>();
        brick.transform.position = position;
        brick.tag = "Brick";
    }
}
