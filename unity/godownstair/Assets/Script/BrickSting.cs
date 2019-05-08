using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSting : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.tag = "used_Brick_sting";
        }
    }
}
