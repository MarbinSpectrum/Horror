using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {
    public Camera MainCamera;
    public GameObject Me;
    public GameObject Memo;
    public AudioSource PuckSound;
    public Text T;
    public string Item = "";
    void Start ()
    {
        Screen.SetResolution(1024,768,true);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Memo.GetComponent<Memo2>().MemoView == false)
        {
            Me.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Menu()
    {
        Me.SetActive(true);
        Vector2 pos = Input.mousePosition;
        pos.x *= 1024f / Screen.width;
        pos.y *= 768f / Screen.height;
        Me.GetComponent<RectTransform>().position = Input.mousePosition;
    }

    public void Cancle()
    {
        Me.SetActive(false);
        T.text = " ";
    }

    public void Use()
    {
        if(Item.Equals("Knife") && !Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().GetBlood)
        {
            Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().GetBlood = true;
            T.text = "식칼을 사용해서 피를 얻었다.";
            PuckSound.Play();
        }
        else if (Item.Equals("Knife") && Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().GetBlood)
        {
            T.text = "날카로워 보이는 칼이다.";
        }
        else if (Item.Equals("Hair"))
        {
            T.text = "내 머리카락이다.";
        }
        else if (Item.Equals("NailCutter") && !Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().GetNail)
        {
            Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().GetNail = true;
            T.text = "손톱깍기를 사용해서 손톱을 잘랐다.";
        }
        else if (Item.Equals("NailCutter") && Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().GetNail)
        {
            T.text = "손톱을 깍을때 쓰는 손톱깍기다.";
        }
        else if (Item.Equals("Pencil"))
        {
            T.text = "공부할때 사용한 연필이다. 주술에 위험도를 낮추고 싶다면 이걸 쓰는 것도 좋아보인다.";
        }
        else if (Item.Equals("Rice"))
        {
            T.text = "주술에 필요한 쌀이다.";
        }
        else if (Item.Equals("SaltWater"))
        {
            T.text = "귀신을 쫒아내기 위한 소금물이다.";
        }
        else if (Item.Equals("Trap"))
        {
            T.text = "귀신을 붙잡기위한 함정이다.";
        }
        else if(Item.Equals("Charm"))
        {
            T.text = "효과가 강력해 보이는 부적이다.";
        }
        else if (Item.Equals("Blood"))
        {
            T.text = "내 몸에서 나온 피다.";
        }
        else if (Item.Equals("Nail"))
        {
            T.text = "손톱깍기로 자른 손톱이다.";
        }
    }

    public void Knife()
    {
        Item = "Knife";
    }

    public void Hair()
    {
        Item = "Hair";
    }

    public void NailCutter()
    {
        Item = "NailCutter";
    }

    public void Pencil()
    {
        Item = "Pencil";
    }

    public void Rice()
    {
        Item = "Rice";
    }

    public void SaltWater()
    {
        Item = "SaltWater";
    }

    public void Trap()
    {
        Item = "Trap";
    }

    public void Charm()
    {
        Item = "Charm";
    }

    public void Blood()
    {
        Item = "Blood";
    }

    public void Nail()
    {
        Item = "Nail";
    }

    public void ChoiceNail()
    {
        Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().InoutDoll = 1;
    }

    public void ChoiceHair()
    {
        Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().InoutDoll = 2;
    }

    public void ChoiceBlood()
    {
        Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().InoutDoll = 3;
    }

    public void ChoiceKnife()
    {
        Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().InoutDoll2 = 1;
    }

    public void Choicepencil()
    {
        Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().InoutDoll2 = 2;
    }
}
