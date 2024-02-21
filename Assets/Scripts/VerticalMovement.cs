using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    private int verticalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        verticalSpeed = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 1.5 || transform.position.y <= -1.5)
        {
            verticalSpeed *= -1;
        }
        
        transform.Translate(Vector2.up * verticalSpeed * Time.deltaTime);
        
    }
}
