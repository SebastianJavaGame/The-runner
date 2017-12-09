using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStartPlatforms : MonoBehaviour {

	void Start () {
        Invoke("DestroyAll", 10);
	}

    void DestroyAll()
    {
        Destroy(gameObject);
    }
}
