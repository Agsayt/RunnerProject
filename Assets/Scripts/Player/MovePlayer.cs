using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : AbilityBase
{
    public static void MovePl(float speed, Transform transform)
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0) * speed * Time.deltaTime;
        return;
    }
}
