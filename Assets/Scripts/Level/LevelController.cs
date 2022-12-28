using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] Traps;
    [SerializeField] public LevelStates LevelState;

    //TODO: Think about global level events

    void Start()
    {
        LevelState = LevelStates.Started;
        Traps = GetComponents<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
