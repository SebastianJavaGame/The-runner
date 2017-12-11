using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowCamera : MonoBehaviour {
    public Transform transformPlayer;
    public float interpolation;

    private Vector3 velocity = Vector3.zero;
    private List<Transform> platformsPosition;
    private Vector3 destination;

    void Start()
    {
        platformsPosition = new List<Transform>();
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
    }
}
