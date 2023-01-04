using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject[] Traps;
    [SerializeField] public LevelStates LevelState;
    [SerializeField] public CustomEvent[] LevelEvents;

    public UnityEvent levelEvent = new UnityEvent();
    //TODO: Think about global level events

    void Start()
    {
        LevelState = LevelStates.Started;
        //Traps = GetComponents<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
