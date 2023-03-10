using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBase : MonoBehaviour
{
    [SerializeField] bool IsEnabled = false;
    [SerializeField] bool IsDestructable = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent(typeof(PlayerController), out Component player);

        if (player is null)
            return;

        //TODO: Connect with player
        //player.Die();
    }
}
