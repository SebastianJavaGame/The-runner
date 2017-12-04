using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject prefab;
    public Transform camTransform;

	void Start () {
		
	}
	
	void Update () {
        Instantiate(prefab, camTransform.position, camTransform.rotation);
        Debug.Log("created");
	}
}
