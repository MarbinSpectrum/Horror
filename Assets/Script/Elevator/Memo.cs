using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memo : MonoBehaviour {

    public GameObject MemoImage;
    public GameObject Mouse;
    public bool MemoView = false;

    void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        var MM = Mouse.GetComponent<Mouse>();
        if (MemoView)
        {
            MM.Act = false;
        }
        else
        {
            if(!(MM.i == 6 || MM.i == 44 || MM.i == 444))
            {
                MM.Act = true;
            }
        }
        if (Input.GetMouseButtonUp(0) && MemoView == true)
        {
            MemoView = false;
            MemoImage.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && MemoView == false && MM.Fail == false)
        {
            MemoView = true;
            MemoImage.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && MemoView == true)
        {
            MemoView = false;
            MemoImage.SetActive(false);
        }
    }
}
