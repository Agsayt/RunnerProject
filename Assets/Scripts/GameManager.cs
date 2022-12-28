using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    [SerializeField] LevelController levelController;
    [SerializeField] LevelStates levelState { get; set; }

    

    void Start()
    {
        levelController = GetComponent<LevelController>();
        levelState = levelController.LevelState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void DeathInitiation()
    {
        levelController.LevelState = LevelStates.Stopped;
    }

}
