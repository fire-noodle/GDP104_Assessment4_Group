using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scoring")]
    public int currentScore = 0;
    public int highScore = 0;

    [Header("Playable Area")]
    public float levelConstraintTop;
    public float levelConstraintBottom;
    public float levelConstraintLeft;
    public float levelConstraintRight;

    [Header("Gameplay Loop")]
    public bool isGameRunning;
    public float totalGameTime;
    public float gameTimeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
