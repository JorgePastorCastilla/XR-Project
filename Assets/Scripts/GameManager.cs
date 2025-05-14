using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GhostSpawner ghostSpawner;
    public int maxOrbs = 5;
    public int currentOrbs = 0;
    
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (!_instance)
            {
                _instance = new GameObject().AddComponent<GameManager>();
                _instance.name = _instance.GetType().ToString();
                // DontDestroyOnLoad(_instance);
            } 
            return _instance;
        }
    }

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    
    
    

    
}
