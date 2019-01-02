using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChange : MonoBehaviour {

    public string nextScene;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
