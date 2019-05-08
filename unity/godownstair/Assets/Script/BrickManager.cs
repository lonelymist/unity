using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickManager : MonoBehaviour
{
    public float initposotionY;
    readonly float leftCreateBorder = -24;
    readonly float rightCreateBorder = 24;
    string BrickType;
    static int BrickNumber = -1;
    public float disY;
    public List<Transform> Bricks;
    int TopBrick = 0;
    public int MaxBricks;
    public Text DisplayCurrentFloor;

    void Start()
    {
        for(int i = 0; i < MaxBricks; i++)
        {
            CreateNewBrick();
        }
    }
    float NewBrickPositionX()
    {
        if (Bricks.Count == 0)
        {
            return 0;
        }
        return Random.Range(leftCreateBorder, rightCreateBorder);
    }
    float NewBrickPositionY()
    {
        if (Bricks.Count == 0)
        {
            return initposotionY;
        }
        int lowerIndex = Bricks.Count - 1;
        return Bricks[lowerIndex].transform.position.y - disY;
    }
    void CreateNewBrick()
    {
        int i = Random.Range(1, 9);
        if (Bricks.Count == 0)
        {
            i = 1;
        }
        switch (i)
        {
            case 1:case 2:case 3:case 4:case 5:
                BrickType = "Brick_normal";
                break;
            case 6:
                BrickType = "Brick_left";
                break;
            case 7:
                BrickType = "Brick_right";
                break;
            case 8:
                BrickType = "Brick_sting";
                break;
        }
        GameObject newBrick = Instantiate(Resources.Load<GameObject>(BrickType));
        newBrick.transform.position = new Vector2(NewBrickPositionX(), NewBrickPositionY());
        Bricks.Add(newBrick.transform);
        if (Bricks.Count > MaxBricks)
        {
            Destroy(Bricks[0].gameObject);
            Bricks.RemoveAt(0);
            TopBrick++;
        }
    }
    void Update()
    {
        if (Bricks[0].transform.position.y > 56)
        {
            CreateNewBrick();
        }
        DisplayCurrentFloor.text = "地下" + ((TopBrick / MaxBricks) + 1) + "樓";
    }
}
