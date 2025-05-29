using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GhostSpawner ghostSpawner;
    public OrbSpawner orbSpawner;
    public int maxOrbs = 5;
    public int currentOrbs = 0;
    public bool gameIsReady = false;
    public GameObject gameOverHUD;
    public GameObject gameWinHUD;
    public bool gameIsOver = false;
    
    public OVRInput.RawButton restartButton;
    
    public TextMeshProUGUI currentOrbsText;
    public TextMeshProUGUI ghostsRemainingText;

    public float ghostsRemainingToKill = 20f;
    public float initialGhostsRemainingToKill = 20f;
    
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

    public void Update()
    {
        currentOrbsText.text = currentOrbs.ToString();
        ghostsRemainingText.text = ghostsRemainingToKill.ToString();
        if (gameIsReady && currentOrbs <= 0)
        {
            gameOverHUD.SetActive(true);
            gameIsOver = true;
            gameIsReady = false;
            ghostSpawner.Stop();
        }
        if (gameIsOver && OVRInput.GetDown(restartButton))
        {
            gameOverHUD.SetActive(false);
            StartCoroutine(orbSpawner.SpawnOrbsCoroutine() );
            ghostSpawner.StartAgain();
            gameIsOver = false;
            ghostsRemainingToKill = initialGhostsRemainingToKill;
        }

        if (ghostsRemainingToKill <= 0)
        {
            gameWinHUD.SetActive(true);
            gameIsOver = true;
            gameIsReady = false;
            ghostSpawner.Stop();
        }

        if (ghostsRemainingToKill <= 0 && OVRInput.GetDown(restartButton))
        {
            gameWinHUD.SetActive(false);
            StartCoroutine(orbSpawner.SpawnOrbsCoroutine() );
            ghostSpawner.StartAgain();
            gameIsOver = false;
            ghostsRemainingToKill = initialGhostsRemainingToKill;
        }
    }

    
    
    

    
}
