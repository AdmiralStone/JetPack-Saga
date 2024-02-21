using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1f, 1f);
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void SpawnObstacle()
    {
        if (gameManagerScript.isGameActive)
        {
            int obstacleIdx = Random.Range(0, obstacles.Capacity);
            GameObject obstacle = obstacles[obstacleIdx];

            Instantiate(obstacle, obstacle.transform.position, obstacle.transform.rotation);
        }
        
    }
}
