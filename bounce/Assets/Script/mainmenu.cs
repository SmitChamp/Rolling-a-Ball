using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {

	
	public void Play () {
        SceneManager.LoadScene("main");	
	}
	
	
	public void Exit () {
        Application.Quit();
        Debug.Log("Over");
    }
}
