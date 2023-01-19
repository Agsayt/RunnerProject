using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jump", menuName = "PlayerAbilities/Jump", order = 1)]
public class Jump : AbilityBase
{
    public float jumpForce;
    private float jumpTime = 2;
    public float jumpTimeValue = 2f;
    private float jumpTimeCounter;

    public bool onGround;
    public float maxDistance;
    public Vector3 boxSize;
    public LayerMask layerMask;
    private GameObject sender;

    public override void Activate(GameObject gameObject)
    {
        base.Activate(gameObject);
        var rb = gameObject.GetComponent<Rigidbody2D>();
        sender = gameObject;

        jumpTimeCounter = jumpTimeValue;
        JumpPl(jumpForce, rb, jumpTime, jumpTimeCounter);
    }

    public void JumpPl(float jumpForce, Rigidbody2D rb, float jumpTime, float jumpControlTime)
    {
        onGround = checkGround();

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
                rb.AddForce(Vector2.up * jumpForce / (jumpTime * 10));
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(jumpTimeCounter > 0)
            {
                rb.AddForce(Vector2.up * jumpForce / (jumpTime * 10));
                jumpTimeCounter -= Time.deltaTime;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(sender.transform.position - sender.transform.up * maxDistance, boxSize);
    }


    bool checkGround()
    {
        if (Physics2D.BoxCast(sender.transform.position, boxSize, 0, -sender.transform.up, maxDistance, layerMask))
            return true;
        else
            return false;
    }
}
