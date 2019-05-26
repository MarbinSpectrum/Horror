using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Memo2 : MonoBehaviour {

    public GameObject MemoImage;
    public GameObject Mouse;
    public GameObject Charm;
    public GameObject SaltWater;
    public GameObject Knife;
    public GameObject Hair;
    public GameObject NailCutter;
    public GameObject Pencil;
    public GameObject Rice;
    public GameObject Trap;
    public GameObject Blood;
    public GameObject Nail;

    public Image MemoI;

    public Sprite[] sp = new Sprite[2];

    public bool MemoView = false;

    int NowPage = 0;

    void Start ()
    {

    }

    void Update()
    {
        ItemView();
        MemoI.sprite = sp[Mathf.Abs(NowPage) % sp.Length];
        if(Input.GetKeyDown(KeyCode.Space) && MemoView == false && !Mouse.GetComponent<Mouse2>().Player.GetComponent<PlayerMove2>().StopEvent)
        {
            Cursor.lockState = CursorLockMode.None;
            MemoView = true;
            MemoImage.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && MemoView == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            MemoView = false;
            MemoImage.SetActive(false);
        }
    }

    public void NextPage()
    {
        if(MemoView)
        {
            NowPage++;
        }
    }

    void ItemView()
    {
        if (MemoView)
        {
            var M = Mouse.GetComponent<Mouse2>();
            if (M.GetCharm == true)
            {
                Charm.SetActive(true);
            }
            else
            {
                Charm.SetActive(false);
            }

            if (M.GetSaltWater == true)
            {
                SaltWater.SetActive(true);
            }
            else
            {
                SaltWater.SetActive(false);
            }

            if (M.GetKnife == true)
            {
                Knife.SetActive(true);
            }
            else
            {
                Knife.SetActive(false);
            }

            if (M.GetHair == true)
            {
                Hair.SetActive(true);
            }
            else
            {
                Hair.SetActive(false);
            }

            if (M.GetNailCutter == true)
            {
                NailCutter.SetActive(true);
            }
            else
            {
                NailCutter.SetActive(false);
            }

            if (M.GetPencil == true)
            {
                Pencil.SetActive(true);
            }
            else
            {
                Pencil.SetActive(false);
            }

            if (M.GetRice == true)
            {
                Rice.SetActive(true);
            }
            else
            {
                Rice.SetActive(false);
            }

            if (M.GetTrap == true)
            {
                Trap.SetActive(true);
            }
            else
            {
                Trap.SetActive(false);
            }

            if (M.GetBlood == true)
            {
                Blood.SetActive(true);
            }
            else
            {
                Blood.SetActive(false);
            }

            if (M.GetNail == true)
            {
                Nail.SetActive(true);
            }
            else
            {
                Nail.SetActive(false);
            }
        }
        else
        {
            
            Charm.SetActive(false);
            SaltWater.SetActive(false);
            Knife.SetActive(false);
            Hair.SetActive(false);
            NailCutter.SetActive(false);
            Pencil.SetActive(false);
            Rice.SetActive(false);
            Trap.SetActive(false);
            Blood.SetActive(false);
            Nail.SetActive(false);
        }
    }

}
