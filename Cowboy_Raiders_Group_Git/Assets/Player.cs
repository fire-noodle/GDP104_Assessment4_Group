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

    public AudioClip jumpSound;
    public AudioClip deathSound;

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
        if (playerIsAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W) && transform.position.y < myGameManager.levelConstraintTop))
            {
                transform.Translate(new Vector2(0, 1));
                myAudioSource.clip = jumpSound;
                myAudioSource.pitch = 1f;
                myAudioSource.Play();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S) && transform.position.y > myGameManager.levelConstraintBottom))
            {
                transform.Translate(new Vector2(0, -1));
                myAudioSource.clip = jumpSound;
                myAudioSource.pitch = 0.7f;
                myAudioSource.Play();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.A) && transform.position.x > myGameManager.levelConstraintLeft))
            {
                transform.Translate(new Vector2(-1, 0));
                myAudioSource.clip = jumpSound;
                myAudioSource.pitch = 1f;
                myAudioSource.Play();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKeyDown(KeyCode.D) && transform.position.x < myGameManager.levelConstraintRight))
            {
                transform.Translate(new Vector2(1, 0));
                myAudioSource.clip = jumpSound;
                myAudioSource.pitch = 1f;
                myAudioSource.Play();
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
        }
    }

    void KillPlayer()
    {
        GetComponent<SpriteRenderer>().enabled = false;

        myAudioSource.PlayOneShot(deathSound);
        Instantiate(explosionFX, transform.position, Quaternion.identity);

        playerIsAlive = false;
        playerCanMove = false;
        
        print("Dead Cowboy");
    }

}
