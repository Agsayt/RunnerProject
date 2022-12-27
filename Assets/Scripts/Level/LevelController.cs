using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] Traps;

    void Start()
    {
        Traps = GetComponents<Trap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
