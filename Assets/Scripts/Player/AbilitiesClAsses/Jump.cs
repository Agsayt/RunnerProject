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

    private void Awake()
    {
        
    }

    public override void Activate(GameObject gameObject)
    {
        base.Activate(gameObject);
        var rb = gameObject.GetComponent<Rigidbody2D>();
        sender = gameObject;
        JumpAction(rb);
    }

    private void JumpAction(Rigidbody2D rb)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            if (Input.GetKeyDown(KeyCode.Space) && checkGround())
            {
                Debug.Log("First jump!");
                jumpTimeCounter = jumpTimeValue;
                rb.AddForce(Vector2.up * jumpForce );
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (jumpTimeCounter > 0)
                {
                    Debug.Log("Second jump!");

                    rb.AddForce(Vector2.up * jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
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
