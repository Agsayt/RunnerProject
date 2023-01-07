using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jump", menuName = "PlayerAbilities/Jump", order = 1)]
public class Jump : AbilityBase
{
    public float jumpForce;

    public override void Activate(GameObject gameObject)
    {
        base.Activate(gameObject);
        var rb = gameObject.GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05)
            JumpPl(jumpForce, rb);
    }

    public static void JumpPl(float jump, Rigidbody2D rb)
    {
        rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
    }
}
