using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int speedFoward;
	
	void Start () {
		
	}
	
	void Update () {
        transform.Translate(Vector2.right * speedFoward * Time.deltaTime);
	}
}
