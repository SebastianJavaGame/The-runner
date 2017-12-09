using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowCamera : MonoBehaviour {
    public Transform transformPlayer;

	void Update () {
        transform.position = new Vector3(transformPlayer.position.x +4, transformPlayer.position.y, -10);
	}
}
