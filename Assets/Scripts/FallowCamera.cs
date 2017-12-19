using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowCamera : MonoBehaviour {
    public Transform transformPlayer;
    public Transform backgroundOne;
    public Transform backgroundTwo;

    public float interpolation;

    private Vector3 velocity = Vector3.zero;
    private List<Transform> platformsPosition;
    private Vector3 destination;

    private float backgroundPosition;

    void Start()
    {
        platformsPosition = new List<Transform>();
        backgroundPosition = (backgroundOne.position.x < backgroundTwo.position.x) ? backgroundTwo.position.x : backgroundOne.position.x; 
    }

    void Update()
    {
        backgroundOne.position = new Vector2(backgroundOne.position.x, transform.position.y);
        backgroundTwo.position = new Vector2(backgroundTwo.position.x, transform.position.y);

        if(backgroundOne.position.x < backgroundTwo.position.x)
        {
            if((int)backgroundTwo.position.x == (int)transform.position.x)
            {
                backgroundPosition += 22.5f;
                backgroundOne.position = new Vector2(backgroundPosition, backgroundOne.position.y);
            }
        }
        else
        {
            if ((int)backgroundOne.position.x == (int)transform.position.x)
            {
                backgroundPosition += 22.5f;
                backgroundTwo.position = new Vector2(backgroundPosition, backgroundTwo.position.y);
            }
        }
    }

    void FixedUpdate()
    {
        platformsPosition = GameManager.GetPlatforms();

        if (transformPlayer.position.x < 18)
        {
            destination = transform.position;
        }
        else
        {
            float averageY = 0;
            int i = 0;

            foreach (var platform in platformsPosition)
            {
                i++;
                averageY += platform.position.y;
            }
            averageY = averageY / i + 2;

            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(new Vector3(transformPlayer.position.x, averageY, transformPlayer.position.z));
            Vector3 delta = point - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(point.x, 0.5f, point.z));
            destination = transform.position + delta;

            destination = new Vector3(0, averageY, 0);
        }

        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, interpolation);
        transform.position = new Vector3(transformPlayer.position.x + 4, transform.position.y, -10);

        if (transform.position.y > transformPlayer.position.y + 5)
        {
            DeathCollision.IsDeath = true;
        }
    }
}
