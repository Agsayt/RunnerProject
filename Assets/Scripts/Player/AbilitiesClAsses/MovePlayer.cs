using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "Movement", menuName = "PlayerAbilities/Movement", order = 1)]
public class MovePlayer : AbilityBase
{

    public DirectionState direction = DirectionState.right;
    public float movementSpeed = 0.005f;
    private float speedNormalizer = 1000f;

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
        gameObject.GetComponent<Rigidbody2D>().gravityScale = direction is DirectionState.down || direction is DirectionState.up? 0 : 1;

        switch (direction)
        {
            case DirectionState.up:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + movementSpeed / speedNormalizer, 0);      
                break;

            case DirectionState.down:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - movementSpeed / speedNormalizer, 0);
                break;

            case DirectionState.right:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + movementSpeed / speedNormalizer, gameObject.transform.position.y, 0);
                break;

            case DirectionState.left:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - movementSpeed / speedNormalizer, gameObject.transform.position.y, 0);
                break;
        }
    }


}
