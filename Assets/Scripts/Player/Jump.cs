using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbilityBase
{
    public static void JumpPl(float jump, Rigidbody2D rb)
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05)
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        return;
    }
}
