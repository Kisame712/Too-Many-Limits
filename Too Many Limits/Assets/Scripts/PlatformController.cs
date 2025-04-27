using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform platform;
    public float moveSpeed;
    int direction = 1;


    // Update is called once per frame
    void Update()
    {
        Vector2 currentTarget = GetCurrentTarget();

        platform.position = Vector2.Lerp(platform.position, currentTarget, moveSpeed * Time.deltaTime);

        if(Vector2.Distance(platform.position, currentTarget) < 0.1f)
        {
            direction *= -1;
        }
        
    }

    Vector2 GetCurrentTarget()
    {
        if(direction == 1)
        {
            return endPos.position;
        }
        else
        {
            return startPos.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.SetParent(this.transform);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.SetParent(null);

        }

    }
}
