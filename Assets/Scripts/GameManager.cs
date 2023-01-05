using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    [SerializeField] LevelController levelController;
    [SerializeField] PlayerController playerController;
    [SerializeField] LevelStates levelState { get; set; }
    public EventZone latestCheckpoint;
    

    void Start()
    {
        levelController = GetComponent<LevelController>();
        levelState = levelController.LevelState;
        Debug.Log("Manager Registered");
        playerController.dieEvent.AddListener(OnPlayerDie);
        levelController.levelEvent.AddListener(OnLevel);
    }

    private void OnPlayerDie()
    {
        Time.timeScale = 0f;
    }

    private void OnRestart()
    {
        Debug.Log("Restart entry");
        Debug.Log("pContrl: " + playerController);

        if (latestCheckpoint is null)
            return;

        Time.timeScale = 1f;
        var playerTransform = playerController.gameObject.transform;
        var playerPosition = playerTransform.position;

        var newX = latestCheckpoint.transform.position.x + (latestCheckpoint.GetComponent<SpriteRenderer>().bounds.size.x / 2 - playerController.GetComponent<SpriteRenderer>().bounds.size.x / 2);

        playerPosition = new Vector2(newX, 2);
    }

    private void OnLevel()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnRestart();
        }
    }
}
