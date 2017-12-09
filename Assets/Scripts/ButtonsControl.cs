using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControl : MonoBehaviour {

	public void ButtonPause()
    {
        Debug.Log("Exit");
        Application.Quit(); 
    }
}
