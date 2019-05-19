using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBrick : MonoBehaviour
{
    public float upSpeed;
    // 設定磚塊速度

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (tag == "Brick_sting")
            {
                tag = "used_Brick_sting";
            }
        }
    }
    // 設定角色離開尖刺時 將尖刺功能去除 避免二次碰撞 重複扣血

    void Update()
    {
        Vector2 upBrick = new Vector2();
        // 設定一個新二維座標

        upBrick.y = upSpeed * Time.deltaTime;
        // 將速度乘上時間

        transform.Translate(0, upBrick.y, 0);
        // 替換掉Y座標

    }
}
