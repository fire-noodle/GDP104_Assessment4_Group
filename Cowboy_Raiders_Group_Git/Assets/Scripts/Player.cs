using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName = "";

    public int playerTotalLives;
    public int playerLivesRemaining;

    public bool playerIsAlive = true;
    public bool playerCanMove = true;

    public bool isOnPlatform = false;
    public bool isInPit = false;

    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip pickupSound;

    public GameObject explosionFX;

    private GameManager myGameManager;
    private AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myGameManager = GameObject.FindObjectOfType<GameManager>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerIsAlive == true) && (playerCanMove == true))
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && transform.position.y < myGameManager.levelConstraintTop)
            {
                transform.Translate(new Vector2(0, 1));
                myAudioSource.clip = jumpSound;
                myAudioSource.pitch = 1f;
                myAudioSource.Play();
            }
            else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && transform.position.y > myGameManager.levelConstraintBottom)
            {
                transform.Translate(new Vector2(0, -1));
                myAudioSource.clip = jumpSound;
                myAudioSource.pitch = 0.7f;
                myAudioSource.Play();
            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && transform.position.x > myGameManager.levelConstraintLeft)
            {
                transform.Translate(new Vector2(-1, 0));
                myAudioSource.clip = jumpSound;
                myAudioSource.pitch = 1f;
                myAudioSource.Play();
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && transform.position.x < myGameManager.levelConstraintRight)
            {
                transform.Translate(new Vector2(1, 0));
                myAudioSource.clip = jumpSound;
                myAudioSource.pitch = 1f;
                myAudioSource.Play();
            }
        }
    }

    private void LateUpdate()
    {
        if (playerIsAlive == true)
        {
            if (isInPit == true && isOnPlatform == false)
            {
                KillPlayer();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerIsAlive == true)
        {
            if (collision.transform.GetComponent<Vehicle>() != null)
            {
                KillPlayer();
            }
            else if (collision.transform.GetComponent<Platform>() != null)
            {
                transform.SetParent(collision.transform);
                isOnPlatform = true;
            }
            else if (collision.transform.tag == "Pit")
            {
                isInPit = true;
            }
            else if (collision.transform.tag == "Bonus")
            {
                myGameManager.CollectBonus(10, collision.transform.position);
                Destroy(collision.gameObject);
                myAudioSource.PlayOneShot(pickupSound);
            }
            else if (collision.transform.tag == "ExtraBonus")
            {
                myGameManager.CollectBonus(50, collision.transform.position);
                Destroy(collision.gameObject);
                myAudioSource.PlayOneShot(pickupSound);
            }
            else if (collision.transform.tag == "Goal")
            {
                playerCanMove = false;               
                myGameManager.GameOver(true);                
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (playerIsAlive == true)
        {
            if (collision.transform.GetComponent<Platform>() != null)
            {
                transform.SetParent(null);
                isOnPlatform = false;
            }
            else if (collision.transform.tag == "Pit")
            {
                isInPit = false;
            }
        }
    }

    void KillPlayer()
    {
        if (playerIsAlive)
        {
            GetComponent<SpriteRenderer>().enabled = false;

            myAudioSource.PlayOneShot(deathSound);
            Instantiate(explosionFX, transform.position, Quaternion.identity);

            playerIsAlive = false;
            playerCanMove = false;

            if (playerIsAlive != true)
            {
                myGameManager.GameOver(false);
            }
        }
    }

}
