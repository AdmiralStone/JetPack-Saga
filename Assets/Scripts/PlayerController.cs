using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] AudioClip coinCollectedAudio;

    private Rigidbody2D playerRb;
    private GameManager gameManagerScript;
    private AudioSource playerAudioSrc;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAudioSrc = GetComponent<AudioSource>();

        gameManagerScript = GameObject.Find("GameManager").GetComponent <GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && gameManagerScript.isGameActive)
        {
            playerRb.velocity = Vector2.up * playerSpeed;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerAudioSrc.PlayOneShot(coinCollectedAudio, 1.0f);

        Destroy(collision.gameObject);
        gameManagerScript.playerScore += 5;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManagerScript.isGameActive = false;
        }
        
    }


}
