using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName = "";

    public int playerTotalLives;
    public int playerLivesRemaining;

    public bool playerIsAlive = true;
    public bool playerCanMove = false;

    private GameManager myGameManager;
    // Start is called before the first frame update
    void Start()
    {
        myGameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < myGameManager.levelConstraintTop)
        {
            transform.Translate(new Vector2(0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > myGameManager.levelConstraintBottom)
        {
            transform.Translate(new Vector2(0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.y > myGameManager.levelConstraintLeft)
        {
            transform.Translate(new Vector2(-1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.y < myGameManager.levelConstraintRight)
        {
            transform.Translate(new Vector2(1, 0));
        }
    }
}
