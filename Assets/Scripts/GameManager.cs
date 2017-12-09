using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject prefab;
    public Transform camTransform;
    public float secondSpawnStep;

    private List<GameObject> platforms;
    private float PlatformSpawnHeight = -1;

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
	}

    void AddStep()
    {
        GameObject step = Instantiate(prefab, new Vector3(camTransform.position.x +15, PlatformSpawnHeight, 0), camTransform.rotation);
        platforms.Add(step);
        PlatformSpawnHeight += 2;
    }
}
