using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jump", menuName = "PlayerAbilities/Jump", order = 1)]
public class Jump : AbilityBase
{
    public float jumpForce;
    private bool jumpControl;
    private float jumpTime = 0;
    public float jumpControlTime = 0.7f;

   // public bool onGround;
   // public Transform groundCheck = ;
   // public float checkRadius = 0.5f;
   // public LayerMask Ground;

    public override void Activate(GameObject gameObject)
    {
        base.Activate(gameObject);
        var rb = gameObject.GetComponent<Rigidbody2D>();

        //checkhingGround();
        JumpPl(jumpForce, rb, jumpControl, jumpTime, jumpControlTime);              
            
    }

    public static void JumpPl(float jumpForce, Rigidbody2D rb, bool jumpControl, float jumpTime, float jumpControlTime)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jumpControl = true;


        }
        else
            jumpControl = false;

        if (jumpControl)
        {
            if ((jumpTime += Time.deltaTime) < jumpControlTime)
                rb.AddForce(Vector2.up * jumpForce / (jumpTime * 10));
        }
        else
            jumpTime = 0;        
    }


    void checkhingGround()
    {
       // onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Ground);
    }
}
