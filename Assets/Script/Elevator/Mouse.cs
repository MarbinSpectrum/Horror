using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mouse : MonoBehaviour
{
    public GameObject Memo;
    public int End = 0;
    public bool Fail = false;
    public AudioSource StepSound;
    public AudioSource UpDownSound;
    public AudioSource BGM;
    public GameObject Light;
    float alpha = 0;
    public Image Fade;
    public Text t;
    public bool Act = true;
    public Texture2D cursorTexture0;
    public Texture2D cursorTexture1;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Animator RDoor;
    public Animator LDoor;
    public Camera MainCamera;
    public bool DoorState = false;
    public bool SelectFloor = false;
    public int NowFloor = 1;
    public int GoFloor = 1;
    public Sprite[] Num = new Sprite[11];
    public Sprite[] ArrowState = new Sprite[3];
    public SpriteRenderer UpDownFloor;
    public SpriteRenderer NowFloor_1;
    public SpriteRenderer NowFloor_2;
    public SpriteRenderer ClickFloor;
    public SpriteRenderer ClickFloor_sub;
    public SpriteRenderer ClickFloor_sub_sub;
    int[] Order = new int[6] { 4, 2, 6, 2, 10 , 5};
    public int i = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(cursorTexture0, hotSpot, cursorMode);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        SetFloor();

        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 30f))
        {
            int tag = hitInfo.transform.gameObject.layer;
            if (tag == 8)
            {
                Cursor.SetCursor(cursorTexture1, hotSpot, cursorMode);
            }
            else
            {
                Cursor.SetCursor(cursorTexture0, hotSpot, cursorMode);
            }
            if (Input.GetMouseButtonUp(0))
            {
                string name = hitInfo.transform.gameObject.name;
                if (name.Equals("Open") && !DoorState && NowFloor == GoFloor && Act)
                {
                    DoorState = true;
                    SpriteRenderer sp0 = hitInfo.transform.gameObject.GetComponent<SpriteRenderer>();
                    SpriteRenderer sp1 = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    sp0.color = Color.green;
                    sp1.color = Color.green;
                    RDoor.SetBool("Open", true);
                    RDoor.SetBool("Close", false);
                    LDoor.SetBool("Open", true);
                    LDoor.SetBool("Close", false);
                    StartCoroutine("Open");
                }
                else if (name.Equals("Close") && DoorState && Act)
                {
                    DoorState = false;
                    SpriteRenderer sp0 = hitInfo.transform.gameObject.GetComponent<SpriteRenderer>();
                    SpriteRenderer sp1 = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    sp0.color = Color.green;
                    sp1.color = Color.green;
                    RDoor.SetBool("Open", false);
                    RDoor.SetBool("Close", true);
                    LDoor.SetBool("Open", false);
                    LDoor.SetBool("Close", true);
                    StartCoroutine("Close");
                }

                if (name.Equals("1 Floor") && !SelectFloor && NowFloor != 1 && Act)
                {
                    if (DoorState)
                    {
                        DoorState = false;
                        RDoor.SetBool("Open", false);
                        RDoor.SetBool("Close", true);
                        LDoor.SetBool("Open", false);
                        LDoor.SetBool("Close", true);
                    }
                    UpDownSound.Play();
                    SelectFloor = true;
                    GoFloor = 1;
                    ClickFloor = hitInfo.transform.gameObject.GetComponent<SpriteRenderer>();
                    ClickFloor_sub = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    ClickFloor.color = Color.green;
                    ClickFloor_sub.color = Color.green;
                    StartCoroutine("GFloor");
                }
                else if (name.Equals("1 Floor") && i == 44)
                {
                    if (DoorState)
                    {
                        DoorState = false;
                        RDoor.SetBool("Open", false);
                        RDoor.SetBool("Close", true);
                        LDoor.SetBool("Open", false);
                        LDoor.SetBool("Close", true);
                    }
                    UpDownSound.Play();
                    GoFloor = 10;
                    ClickFloor = hitInfo.transform.gameObject.GetComponent<SpriteRenderer>();
                    ClickFloor_sub = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    ClickFloor.color = Color.green;
                    ClickFloor_sub.color = Color.green;
                    StartCoroutine("GFloor");
                }
                else if (name.Equals("2 Floor") && !SelectFloor && NowFloor != 2 && Act)
                {
                    if (DoorState)
                    {
                        DoorState = false;
                        RDoor.SetBool("Open", false);
                        RDoor.SetBool("Close", true);
                        LDoor.SetBool("Open", false);
                        LDoor.SetBool("Close", true);
                    }
                    UpDownSound.Play();
                    SelectFloor = true;
                    GoFloor = 2;
                    ClickFloor = hitInfo.transform.gameObject.GetComponent<SpriteRenderer>();
                    ClickFloor_sub = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    ClickFloor.color = Color.green;
                    ClickFloor_sub.color = Color.green;
                    StartCoroutine("GFloor");
                }
                else if (name.Equals("3 Floor") && !SelectFloor && NowFloor != 3 && Act)
                {
                    if (DoorState)
                    {
                        DoorState = false;
                        RDoor.SetBool("Open", false);
                        RDoor.SetBool("Close", true);
                        LDoor.SetBool("Open", false);
                        LDoor.SetBool("Close", true);
                    }
                    UpDownSound.Play();
                    SelectFloor = true;
                    GoFloor = 3;
                    ClickFloor = hitInfo.transform.gameObject.GetComponent<SpriteRenderer>();
                    ClickFloor_sub = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    ClickFloor.color = Color.green;
                    ClickFloor_sub.color = Color.green;
                    StartCoroutine("GFloor");
                }
                else if (name.Equals("4 Floor") && !SelectFloor && NowFloor != 4 && Act)
                {
                    if (DoorState)
                    {
                        DoorState = false;
                        RDoor.SetBool("Open", false);
                        RDoor.SetBool("Close", true);
                        LDoor.SetBool("Open", false);
                        LDoor.SetBool("Close", true);
                    }
                    UpDownSound.Play();
                    SelectFloor = true;
                    GoFloor = 4;
                    ClickFloor = hitInfo.transform.gameObject.GetComponent<SpriteRenderer>();
                    ClickFloor_sub = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    ClickFloor.color = Color.green;
                    ClickFloor_sub.color = Color.green;
                    StartCoroutine("GFloor");
                }
                else if (name.Equals("5 Floor") && !SelectFloor && NowFloor != 5 && Act)
                {
                    if (DoorState)
                    {
                        DoorState = false;
                        RDoor.SetBool("Open", false);
                        RDoor.SetBool("Close", true);
                        LDoor.SetBool("Open", false);
                        LDoor.SetBool("Close", true);
                    }
                    UpDownSound.Play();
                    SelectFloor = true;
                    GoFloor = 5;
                    ClickFloor = hitInfo.transform.gameObject.GetComponent<SpriteRenderer>();
                    ClickFloor_sub = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    ClickFloor.color = Color.green;
                    ClickFloor_sub.color = Color.green;
                    StartCoroutine("GFloor");
                }
                else if (name.Equals("6 Floor") && !SelectFloor && NowFloor != 6 && Act)
                {
                    if (DoorState)
                    {
                        DoorState = false;
                        RDoor.SetBool("Open", false);
                        RDoor.SetBool("Close", true);
                        LDoor.SetBool("Open", false);
                        LDoor.SetBool("Close", true);
                    }
                    UpDownSound.Play();
                    SelectFloor = true;
                    GoFloor = 6;
                    ClickFloor = hitInfo.transform.gameObject.GetComponent<SpriteRenderer>();
                    ClickFloor_sub = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    ClickFloor.color = Color.green;
                    ClickFloor_sub.color = Color.green;
                    StartCoroutine("GFloor");
                }
                else if (name.Equals("7 Floor") && !SelectFloor && NowFloor != 7 && Act)
                {
                    if (DoorState)
                    {
                        DoorState = false;
                        RDoor.SetBool("Open", false);
                        RDoor.SetBool("Close", true);
                        LDoor.SetBool("Open", false);
                        LDoor.SetBool("Close", true);
                    }
                    UpDownSound.Play();
                    SelectFloor = true;
                    GoFloor = 7;
                    ClickFloor = hitInfo.transform.gameObject.GetComponent<SpriteRenderer>();
                    ClickFloor_sub = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    ClickFloor.color = Color.green;
                    ClickFloor_sub.color = Color.green;
                    StartCoroutine("GFloor");
                }
                else if (name.Equals("8 Floor") && !SelectFloor && NowFloor != 8 && Act)
                {
                    if (DoorState)
                    {
                        DoorState = false;
                        RDoor.SetBool("Open", false);
                        RDoor.SetBool("Close", true);
                        LDoor.SetBool("Open", false);
                        LDoor.SetBool("Close", true);
                    }
                    UpDownSound.Play();
                    SelectFloor = true;
                    GoFloor = 8;
                    ClickFloor = hitInfo.transform.gameObject.GetComponent<SpriteRenderer>();
                    ClickFloor_sub = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    ClickFloor.color = Color.green;
                    ClickFloor_sub.color = Color.green;
                    StartCoroutine("GFloor");
                }
                else if (name.Equals("9 Floor") && !SelectFloor && NowFloor != 9 && Act)
                {
                    if (DoorState)
                    {
                        DoorState = false;
                        RDoor.SetBool("Open", false);
                        RDoor.SetBool("Close", true);
                        LDoor.SetBool("Open", false);
                        LDoor.SetBool("Close", true);
                    }
                    UpDownSound.Play();
                    SelectFloor = true;
                    GoFloor = 9;
                    ClickFloor = hitInfo.transform.gameObject.GetComponent<SpriteRenderer>();
                    ClickFloor_sub = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    ClickFloor.color = Color.green;
                    ClickFloor_sub.color = Color.green;
                    StartCoroutine("GFloor");
                }
                else if (name.Equals("10 Floor") && !SelectFloor && NowFloor != 10 && Act)
                {
                    if (DoorState)
                    {
                        DoorState = false;
                        RDoor.SetBool("Open", false);
                        RDoor.SetBool("Close", true);
                        LDoor.SetBool("Open", false);
                        LDoor.SetBool("Close", true);
                    }
                    UpDownSound.Play();
                    SelectFloor = true;
                    GoFloor = 10;
                    ClickFloor = hitInfo.transform.GetComponent<SpriteRenderer>();
                    ClickFloor_sub = hitInfo.transform.GetChild(0).GetComponent<SpriteRenderer>();
                    ClickFloor_sub_sub = hitInfo.transform.GetChild(1).GetComponent<SpriteRenderer>();
                    ClickFloor.color = Color.green;
                    ClickFloor_sub.color = Color.green;
                    ClickFloor_sub_sub.color = Color.green;
                    StartCoroutine("GFloor");
                }
            }
        }
    }

    void SetFloor()
    {
        if (NowFloor != 10)
        {
            NowFloor_1.sprite = Num[10];
            NowFloor_2.sprite = Num[NowFloor];
        }
        else
        {
            NowFloor_1.sprite = Num[1];
            NowFloor_2.sprite = Num[0];
        }
        if (GoFloor > NowFloor)
        {
            UpDownFloor.sprite = ArrowState[1];
        }
        else if (GoFloor < NowFloor)
        {
            UpDownFloor.sprite = ArrowState[2];
        }
        else
        {
            UpDownFloor.sprite = ArrowState[0];
        }
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(1f);
        GameObject open = GameObject.Find("Open");
        SpriteRenderer sp0 = open.transform.gameObject.GetComponent<SpriteRenderer>();
        SpriteRenderer sp1 = open.transform.GetChild(0).GetComponent<SpriteRenderer>();
        sp0.color = Color.red;
        sp1.color = Color.red;
    }

    IEnumerator Close()
    {
        yield return new WaitForSeconds(1f);
        GameObject open = GameObject.Find("Close");
        SpriteRenderer sp0 = open.transform.gameObject.GetComponent<SpriteRenderer>();
        SpriteRenderer sp1 = open.transform.GetChild(0).GetComponent<SpriteRenderer>();
        sp0.color = Color.red;
        sp1.color = Color.red;
    }

    IEnumerator GFloor()
    {
        yield return new WaitForSeconds(1f);
        if (GoFloor > NowFloor)
        {
            NowFloor++;
        }
        else if (GoFloor < NowFloor)
        {
            NowFloor--;
        }

        if (NowFloor != GoFloor)
        {
            StartCoroutine("GFloor");
        }
        else
        {
            ClickFloor.color = Color.red;
            ClickFloor_sub.color = Color.red;
            if (NowFloor == 10 && i != 44)
            {
                ClickFloor_sub_sub.color = Color.red;
            }
            if (NowFloor == 10 && i == 44)
            {
                i = 444;
            }
            DoorState = true;
            RDoor.SetBool("Open", true);
            RDoor.SetBool("Close", false);
            LDoor.SetBool("Open", true);
            LDoor.SetBool("Close", false);
            SelectFloor = false;
            if(NowFloor == 10 && i != 444)
            {
                End = 1;
                t.text = "더 이상 진행하면 돌이킬 수 없을 것 같은 기분이 든다.";
                StartCoroutine("Emp");
            }
            else if (NowFloor == 10 && i == 444)
            {
                t.text = "성공한건가?";
                StartCoroutine("Emp");
            }
            if (i < 6)
            {
                if (NowFloor == Order[i])
                {
                    i++;
                }
                else
                {
                    var MView = Memo.GetComponent<Memo>();
                    Fail = true;
                    MView.MemoView = false;
                    t.text = "순서가 틀렸다 처음부터 다시 해야할것 같다.";
                    End = 3;
                    StartCoroutine("FadeIn");
                }
            }

            if(i == 6)
            {
                Act = false;
                Light.SetActive(false);
                t.text = "갑자기 전등이 나갔다.";
                BGM.Stop();
                StartCoroutine("Ghost");
            }
        }
    }

    IEnumerator Emp()
    {
        yield return new WaitForSeconds(2f);
        t.text = " ";
    }

    IEnumerator Ghost()
    {
        StepSound.Play();
        yield return new WaitForSeconds(1f);
        StepSound.Play();
        yield return new WaitForSeconds(1f);
        StepSound.Play();
        t.text = "누군가가 걸어오는 소리가 들린다.";
        yield return new WaitForSeconds(1f);
        StepSound.Play();
        yield return new WaitForSeconds(1f);
        StepSound.Play();
        t.text = " ";
        yield return new WaitForSeconds(1f);
        StepSound.Play();
        yield return new WaitForSeconds(1f);
        StepSound.Play();
        yield return new WaitForSeconds(1f);
        StepSound.Play();
        yield return new WaitForSeconds(1f);
        DoorState = false;
        RDoor.SetBool("Open", false);
        RDoor.SetBool("Close", true);
        LDoor.SetBool("Open", false);
        LDoor.SetBool("Close", true);
        i = 44;
        yield return new WaitForSeconds(1f);
        t.text = "갑자기 문이 닫혔다.";
        yield return new WaitForSeconds(2f);
        t.text = "머리위에서 이상한 기분이 느껴진다.";
        yield return new WaitForSeconds(2f);
        t.text = " ";
    }

    IEnumerator FadeIn()
    {
        Fade.color = new Color(0, 0,0, alpha);
        yield return new WaitForSeconds(0.1f);
        alpha += 0.02f;
        if(alpha >= 1)
        {
            alpha = 0;
            if(End == 0)
            {
                SceneManager.LoadScene("End0-1");
            }
            else if(End == 1)
            {
                SceneManager.LoadScene("End0-2");
            }
            else if (End == 3)
            {
                SceneManager.LoadScene("End0-4");
            }
        }
        else
        {
            StartCoroutine("FadeIn");
        }
    }
}
