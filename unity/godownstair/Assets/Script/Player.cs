using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D my_Rigidbody;
    float input_x;
    public float MoveSpeed;
    public float NowSpeed;
    float Speed;
    public static bool isDead;
    public Text Hp;
    public int TotalHp;
    int CurrentHp;
    void Start()
    {
        Speed = NowSpeed;
        NowSpeed = 0;
        isDead = false;
        CurrentHp = TotalHp;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick_right"))
        {
            if(NowSpeed <= 0)
            {
                NowSpeed = Speed;
            }
        }
        if (other.gameObject.CompareTag("Brick_left"))
        {
            if (NowSpeed >= 0)
            {
                NowSpeed = -Speed;
            }
        }
        if (other.gameObject.CompareTag("Brick_sting"))
        {
            CurrentHp--;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick_right") || other.gameObject.CompareTag("Brick_left"))
        {
            NowSpeed = 0;
        } 
    }
    void Update()
    {
        input_x = Input.GetAxis("Horizontal");

        Vector2 now_Velocity = new Vector2();
        now_Velocity = my_Rigidbody.velocity;
        now_Velocity.x = MoveSpeed * input_x + NowSpeed * Time.deltaTime * 50;
        my_Rigidbody.velocity = now_Velocity;

        Hp.text = "血量:" + CurrentHp;
        if (CurrentHp == 0)
        {
            Player.isDead = true;
        }
    }
}
