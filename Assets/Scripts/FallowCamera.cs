using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowCamera : MonoBehaviour
{
    public Transform transformPlayer;
    public Transform backgroundOne;
    public Transform backgroundTwo;

    public float interpolation;

    public static float disappearScreen;

    private Vector3 velocity = Vector3.zero;
    private List<Transform> platformsPosition;
    private Vector3 destination;

    void Awake()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        disappearScreen = height * cam.aspect;
        disappearScreen /= 2;
        disappearScreen += 2;
    }

    void Start()
    {
        platformsPosition = new List<Transform>();
    }

    void Update()
    {
        //backgroundOne.position = new Vector2(backgroundOne.position.x, transform.position.y);
        //backgroundTwo.position = new Vector2(backgroundTwo.position.x, transform.position.y);

        if (backgroundOne.position.x < backgroundTwo.position.x)
        {
            if ((int)backgroundTwo.position.x == (int)transform.position.x)
            {
                backgroundOne.position = new Vector2(backgroundTwo.position.x + 22.5f, backgroundOne.position.y);
            }
        }
        else
        {
            if ((int)backgroundOne.position.x == (int)transform.position.x)
            {
                backgroundTwo.position = new Vector2(backgroundOne.position.x + 22.5f, backgroundTwo.position.y);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 point = GetComponent<Camera>().WorldToViewportPoint(new Vector3(transformPlayer.position.x, transform.position.y, transformPlayer.position.z));
        Vector3 delta = point - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(point.x, 0.5f, point.z));
        destination = transform.position + delta;

        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, interpolation);
        transform.position = new Vector3(transformPlayer.position.x + 4, 5, -10);
    }
}
