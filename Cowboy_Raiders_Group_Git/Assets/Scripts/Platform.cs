using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public int moveDirection = 0;
    public float speed;
    public Vector2 startingPosition;
    public Vector2 endPosition;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed * moveDirection);

        if ((transform.position.x * moveDirection) < (endPosition.x * moveDirection))
        {
            transform.position = startingPosition;
        }
    }
}
