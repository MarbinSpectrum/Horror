using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End1 : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Screen.SetResolution(1024, 768, true);
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("Game1");
        }
    }
}
