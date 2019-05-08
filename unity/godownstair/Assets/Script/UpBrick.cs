using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBrick : MonoBehaviour
{
    public float upSpeed;
    void Update()
    {
        transform.Translate(0, upSpeed * Time.deltaTime, 0);
    }
}
