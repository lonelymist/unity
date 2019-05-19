using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D my_Rigidbody;
    // 抓取角色剛體

    float input_x;
    // 設定玩家鍵盤的左右輸入

    public float MoveSpeed;
    // 設定角色左右移動的速度

    public float Speed;
    // 設定輸送帶影響的速度

    static bool onMoveBrick;
    // 設定角色是否站在輸送帶

    public static bool isDead;
    // 設定角色是否存活

    public Text Hp;
    // 設定血量的Text

    public int TotalHp;
    // 設定血量上限

    int CurrentHp;
    // 設定目前血量

    void Start()
    {
        onMoveBrick = false;
        // 沒站在輸送帶

        isDead = false;
        // 將角色死亡設定為false

        CurrentHp = TotalHp;
        // 將總血量的值給當血量

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick_right"))
        {
            onMoveBrick = true;
            if (Speed < 0)
            {
                Speed = -Speed;
                // 如果影響速度是負的 改成正的
            }
        }
        if (other.gameObject.CompareTag("Brick_left"))
        {
            onMoveBrick = true;
            if (Speed > 0)
            {
                Speed = -Speed;
                // 如果影響速度是正的 改成負的
            }
        }
        if (other.gameObject.CompareTag("Brick_sting"))
        {
            CurrentHp--;
            // 碰到刺扣血
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick_right")|| other.gameObject.CompareTag("Brick_left"))
        {
            onMoveBrick = false;
            // 離開輸送帶 將值改false
        }
    }
    void Update()
    {
        input_x = Input.GetAxis("Horizontal");
        // 偵測玩家輸入左右的按鍵

        Vector2 now_Velocity = new Vector2();
        // 設定新二維座標

        now_Velocity = my_Rigidbody.velocity;
        //取得角色的剛體位置

        if (onMoveBrick)
        {
            now_Velocity.x = MoveSpeed * input_x + Speed * Time.deltaTime * 50;
            // 如果在輸送帶上 就將影響速度加在當前速度上
        }
        else
        {
            now_Velocity.x = MoveSpeed * input_x;
            // 如果無 就只看玩家鍵盤輸入的左右
        }
        my_Rigidbody.velocity = now_Velocity;
        // 將剛設定好的速度替換到角色剛體上

        Hp.text = "血量:" + CurrentHp;
        // 設定血量的Text

        if (CurrentHp == 0)
        {
            Player.isDead = true;
        }
        // 血量歸零時 角色死亡
    }
}
