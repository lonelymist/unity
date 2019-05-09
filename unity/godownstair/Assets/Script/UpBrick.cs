using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBrick : MonoBehaviour
{
    public float upSpeed;
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
    void Update()
    {
        Vector2 upBrick = new Vector2();
        upBrick.y = upSpeed * Time.deltaTime;
        transform.Translate(0, upBrick.y, 0);
    }
}
