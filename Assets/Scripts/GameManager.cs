using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject prefab;
    public Transform camTransform;
    public float secondSpawnStep;
    public Text textPoints;

    private static List<GameObject> platforms;
    private float PlatformSpawnHeight = -3;

	void Start () {
        platforms = new List<GameObject>();
        InvokeRepeating("AddStep", secondSpawnStep, secondSpawnStep);
	}
	
	void Update () {
        if(platforms.Count != 0)
        {
            foreach(var platform in platforms)
            {
                if (platform.transform.position.x < camTransform.position.x - 12 || platform.transform.position.y < camTransform.position.y - 8)
                {
                    Destroy(platform);
                    platforms.Remove(platform);
                }
            }
        }

        UpdatePoints();
	}

    private void UpdatePoints()
    {
        textPoints.text = "Score: " + (int)Time.time;
    }

    void AddStep()
    {
        GameObject step = Instantiate(prefab, new Vector3(camTransform.position.x +15, PlatformSpawnHeight, 0), camTransform.rotation);
        platforms.Add(step);
        PlatformSpawnHeight += 2;
    }

    public static List<Transform> getPlatforms()
    {
        List<Transform> list = new List<Transform>();
        
        foreach(var element in platforms)
        {
            list.Add(element.gameObject.transform);
        }

        return list;
    }
}
