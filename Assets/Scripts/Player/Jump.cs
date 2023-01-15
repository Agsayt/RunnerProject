using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Jump", menuName = "PlayerAbilities/Jump", order = 1)]
public class Jump : AbilityBase
{
    public float jumpForce = 210f;
    private bool jumpControl;
    private float jumpTime = 0;
    public float jumpControlTime = 0.7f;

    private GameObject gameObjectCheck;
    public bool onGroind;
    public float radius = 0.5f;

    public override void Activate(GameObject gameObject)
    {        
        gameObjectCheck = gameObject;
        base.Activate(gameObject);
        var rb = gameObject.GetComponent<Rigidbody2D>();

        JumpPl(jumpForce, rb, jumpControl, jumpTime, jumpControlTime);                    
    }

    public void JumpPl(float jumpForce, Rigidbody2D rb, bool jumpControl, float jumpTime, float jumpControlTime)
    {
        checkGroud();
        if (Input.GetKey(KeyCode.Space))
            if (onGroind) jumpControl = true;
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

    private void checkGroud()
    {        
        Collider2D[] collider = Physics2D.OverlapCircleAll(gameObjectCheck.transform.position, radius);        
        onGroind = collider.Length > 1;        
    }
}
