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

        Time.timeScale = 1f;
        var playerRenderer = playerController.GetComponentInChildren<SpriteRenderer>();
        var newX = latestCheckpoint.transform.position.x + (latestCheckpoint.GetComponent<SpriteRenderer>().bounds.size.x / 2 - playerRenderer.bounds.size.x / 2);
        var newY = latestCheckpoint.transform.position.y + playerRenderer.bounds.size.y;


        playerController.gameObject.transform.position = new Vector3(newX, newY, 0); 
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
