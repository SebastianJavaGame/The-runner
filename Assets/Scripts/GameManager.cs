using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject prefab;
    public Transform camTransform;
    public float secondSpawnStep = 1.5f;

    private List<GameObject> platforms;

	void Start () {
        platforms = new List<GameObject>();
        InvokeRepeating("AddStep", 0, secondSpawnStep);
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
        GameObject step = Instantiate(prefab, new Vector3(camTransform.position.x, camTransform.position.y -4, 0), camTransform.rotation);
        platforms.Add(step);
        Debug.Log("created");
    }
}
