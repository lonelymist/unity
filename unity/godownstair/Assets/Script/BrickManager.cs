using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickManager : MonoBehaviour
{
    readonly float leftCreateBorder = -24;
    readonly float rightCreateBorder = 24;
    // 設定左右邊界

    public List<Sprite> BrickType;
    // 將不同種磚塊類型的Sprite加進陣列

    Vector2 BrickVector2 = new Vector2();
    // 設定一個新的二維座標 用來替換當前磚塊座標 

    public float disY;
    // 設定磚塊間距

    public List<Transform> Bricks;
    // 為磚塊編號 加進陣列

    public List<PhysicsMaterial2D> BrickSpring;
    // 將彈簧與其他種方塊的PhysicsMaterial2D 加進陣列

    public int MaxBricks;
    // 設定磚塊數量上限

    int TopBrick;
    // 用來抓取最上面的磚塊

    public Text DisplayCurrentFloor;
    // 計算樓層的Text

    void Start()
    {
        TopBrick = MaxBricks;
        // 之後會用餘數來取得最上面磚塊

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
        // 如果還沒有磚塊 就將它X座標設為0

        return Random.Range(leftCreateBorder, rightCreateBorder);
    }
    float NewBrickPositionY()
    {
        if (Bricks.Count == 0)
        {
            return 0;
        }
        // 如果還沒有磚塊 就將它Y座標設為0

        int lowerIndex = Bricks.Count - 1;
        // 抓取下一個磚塊的編號

        return Bricks[lowerIndex].transform.position.y - disY;
        // 下一個磚塊的Y座標 等於 當前磚塊的Y座標 減固定間距
    }
    void CreateNewBrick()
    {
        GameObject newBrick = Instantiate(Resources.Load<GameObject>("Brick"));
        // 設定新磚塊，從Resource裡複製一個磚塊

        newBrick.transform.position = new Vector2(NewBrickPositionX(), NewBrickPositionY());
        // 設定它的座標為 剛剛設定好的

        Bricks.Add(newBrick.transform);
        // 然後把它加進Bricks陣列

    }
    void ChangeSprite(GameObject ThisBrick, int i)
        // 用來改變磚塊類型 (新的磚塊 ， 是否為第一個磚塊)
    {
        int j = Random.Range(1, 10);
        // 設定隨機變數

        if (i == 0)
        {
            j = 1;
        }
        // 如果是第一個磚塊 必定是一般磚塊

        ThisBrick.GetComponent<BoxCollider2D>().sharedMaterial = BrickSpring[0];
        // 預設磚塊的PhysicsMaterial2D不是彈簧的物理性質

        switch (j)
        {
            default:
                ThisBrick.GetComponent<SpriteRenderer>().sprite = BrickType[0];
                // 改變磚塊的sprite

                ThisBrick.tag = "Untagged";
                // 改變磚塊的tag

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
                // 切換到彈簧的PhysicsMaterial2D

                ThisBrick.tag = "Brick_spring";
                break;
        }
    }
    void Update()
    {
        if (Bricks[TopBrick % MaxBricks].transform.position.y > 56)
            // 如果最上面的磚塊到達設定的最高點
        {
            Bricks[TopBrick % MaxBricks].transform.position = new Vector2(NewBrickPositionX(), Bricks[(TopBrick - 1) % MaxBricks].transform.position.y - disY);
            // 就把它移動到最下面

            ChangeSprite(Bricks[TopBrick % MaxBricks].gameObject,1);
            // 然後隨機改變種類

            TopBrick++;
            // 最上層磚塊編號加1 取餘數就會變成下一個磚塊

        }
        if (!Player.isDead)
            // 如果角色沒死就一直計算
        {
            DisplayCurrentFloor.text = "地下" + (TopBrick / MaxBricks) + "樓";
        }
    }
}
