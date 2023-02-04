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
        if (latestCheckpoint is null)
            return;


        var playerRenderer = playerController.GetComponentInChildren<SpriteRenderer>();
        var newX = latestCheckpoint.transform.position.x + (latestCheckpoint.GetComponent<SpriteRenderer>().bounds.size.x / 2 - playerRenderer.bounds.size.x - playerRenderer.bounds.size.x / 2);
        var newY = latestCheckpoint.transform.position.y - latestCheckpoint.GetComponent<SpriteRenderer>().bounds.size.y + playerRenderer.bounds.size.y;


        playerController.gameObject.transform.position = new Vector3(newX, newY, 0);
        Time.timeScale = 1f;
        playerController.PlayerRevive();

    }

    private void OnLevel()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnRestart();
        }
    }
}
