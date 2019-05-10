using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickManager : MonoBehaviour
{
    readonly float leftCreateBorder = -24;
    readonly float rightCreateBorder = 24;
    public List<Sprite> BrickType;
    Vector2 BrickVector2 = new Vector2();
    public float disY;
    public List<Transform> Bricks;
    public List<PhysicsMaterial2D> BrickSpring;
    public int MaxBricks;
    int TopBrick;
    public Text DisplayCurrentFloor;

    void Start()
    {
        TopBrick = MaxBricks;
        for(int i = 0; i < MaxBricks; i++)
        {
            CreateNewBrick();
            ChangeSprite(Bricks[i].gameObject,i);
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
            return 0;
        }
        int lowerIndex = Bricks.Count - 1;
        return Bricks[lowerIndex].transform.position.y - disY;
    }
    void CreateNewBrick()
    {
        GameObject newBrick = Instantiate(Resources.Load<GameObject>("Brick"));
        newBrick.transform.position = new Vector2(NewBrickPositionX(), NewBrickPositionY());
        Bricks.Add(newBrick.transform);
    }
    void ChangeSprite(GameObject ThisBrick, int i)
    {
        int j = Random.Range(1, 10);
        if (i == 0)
        {
            j = 1;
        }
        ThisBrick.GetComponent<BoxCollider2D>().sharedMaterial = BrickSpring[0];
        switch (j)
        {
            default:
                ThisBrick.GetComponent<SpriteRenderer>().sprite = BrickType[0];
                ThisBrick.tag = "Untagged";
                break;
            case 6:
                ThisBrick.GetComponent<SpriteRenderer>().sprite = BrickType[1];
                ThisBrick.tag = "Brick_left";
                break;
            case 7:
                ThisBrick.GetComponent<SpriteRenderer>().sprite = BrickType[2];
                ThisBrick.tag = "Brick_right";
                break;
            case 8:
                ThisBrick.GetComponent<SpriteRenderer>().sprite = BrickType[3];
                ThisBrick.tag = "Brick_sting";
                break;
            case 9:
                ThisBrick.GetComponent<SpriteRenderer>().sprite = BrickType[4];
                ThisBrick.GetComponent<BoxCollider2D>().sharedMaterial = BrickSpring[1];
                ThisBrick.tag = "Brick_spring";
                break;
        }
    }
    void Update()
    {
        if (Bricks[TopBrick % MaxBricks].transform.position.y > 56)
        {
            Bricks[TopBrick % MaxBricks].transform.position = new Vector2(NewBrickPositionX(), Bricks[(TopBrick - 1) % MaxBricks].transform.position.y - disY);
            ChangeSprite(Bricks[TopBrick % MaxBricks].gameObject,1);
            TopBrick++;
        }
        DisplayCurrentFloor.text = "地下" + (TopBrick / MaxBricks) + "樓";
    }
}
