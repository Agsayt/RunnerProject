using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "Movement", menuName = "PlayerAbilities/Movement", order = 1)]
public class MovePlayer : AbilityBase
{

    public DirectionState direction = DirectionState.right;
    public float movementSpeed = 0.01f;

    public enum DirectionState
    {
        up,
        down,
        right,
        left
    }

    public override void Activate(GameObject gameObject)
    {
        base.Activate(gameObject);
        directionChange(gameObject);
    }  
    
    private void directionChange(GameObject gameObject)
    {           
        switch (direction)
        {
            case DirectionState.up:
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + movementSpeed, 0);      
                break;

            case DirectionState.down:
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - movementSpeed, 0);
                break;

            case DirectionState.right:
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + movementSpeed, gameObject.transform.position.y, 0);
                break;

            case DirectionState.left:
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - movementSpeed, gameObject.transform.position.y, 0);
                break;
        }
    }


}
