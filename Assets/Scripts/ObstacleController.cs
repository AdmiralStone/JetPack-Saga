using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] float obstacleSpeed = 25f;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isGameActive)
        {
            transform.Translate(Vector2.left * obstacleSpeed * Time.deltaTime);

            if (transform.position.x < -10)
            {
                Destroy(gameObject);
            }
        }
        
    }

    
}
