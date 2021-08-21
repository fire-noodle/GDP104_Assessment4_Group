using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Scoring")]
    public int currentScore = 0;
    public int highScore = 0;
    public TMP_Text currentScoureUI;

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

    [Header("Effects")]
    public GameObject bonusFX;

    [Header("UI")]
    public TMP_Text uiGameOverMessage;
    public TMP_Text uiScore;

    public UIManager myUI;

    public void Awake()
    {
        myUI = FindObjectOfType<UIManager>();
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    void Start()
    {
        UpdateScore(-currentScore);
        currentScoureUI.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int scoreAmount)
    {
        currentScore += scoreAmount;
        currentScoureUI.text = currentScore.ToString();
    }

    public void CollectBonus (int amount, Vector2 pos)
    {
        UpdateScore(amount);
        Instantiate(bonusFX, pos, Quaternion.identity);
    }

    public void GameOver(bool isWin)
    {
        if (isWin == true)
        {
            uiGameOverMessage.text = "You Won!";
        }
        else
        {
            uiGameOverMessage.text = "You Lost!";
        }
        myUI.uiGameOverWindow.SetActive(true);
        uiScore.text = currentScore.ToString();
    }
}
