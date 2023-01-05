using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventZone : MonoBehaviour
{
    public ZoneType zoneType = ZoneType.Death;

    public enum ZoneType
    {
        Death,
        Freewalk,
        GravityUp,
        GradityDown,
        Checkpoint,
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.TryGetComponent(typeof(PlayerController), out Component component);
        if (component is null)
            return;


        switch (zoneType)
        {
            case ZoneType.Death:
                PlayerDie(component);
                break;
            case ZoneType.Freewalk:
                PlayerFreewalk(component);
                break;
            case ZoneType.GravityUp:
                PlayerGravityUp(component);
                break;
            case ZoneType.GradityDown:
                PlayerGravityDown(component);
                break;
            case ZoneType.Checkpoint:
                PlayerCheckpoint();
                break;
            default:
                break;
        }

    }

    private void PlayerCheckpoint()
    {
        GameManager.Instance.latestCheckpoint = this;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    private void PlayerGravityDown(Component component)
    {
        
    }

    private void PlayerGravityUp(Component component)
    {
        throw new NotImplementedException();
    }

    private void PlayerFreewalk(Component component)
    {
        throw new NotImplementedException();
    }

    private void PlayerDie(Component component)
    {
        Debug.Log("Entered death zone");
        (component as PlayerController).Die();
    }
}
