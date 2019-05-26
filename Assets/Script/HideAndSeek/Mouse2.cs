using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Mouse2 : MonoBehaviour
{
    public AudioSource GetSound;
    public AudioSource PuckSound;
    public AudioSource RiceSound;
    public AudioSource WaterSound;
    public AudioSource FindSound;
    public AudioSource SwitchSound;
    public AudioSource GhostSound;
    public GameObject DoorSound;

    public bool FindTheDoll = false;
    public bool DollSet = false;
    public bool LampLight = true;
    public bool TvPower = false;
    public bool GetDoll = false;
    public bool GetCharm = false;
    public bool GetSaltWater = false;
    public bool GetKnife = false;
    public bool GetHair = false;
    public bool GetNailCutter = false;
    public bool GetPencil = false;
    public bool GetRice = false;
    public bool GetTrap = false;
    public bool GetBlood = false;
    public bool GetNail = false;
    public bool SetTrap = false;
    public bool SetCharm = false;
    public bool DangerDoll = false;
    public bool NotExit = false;
    public bool CleanDoll = false;
    public bool HouseExit = false;
    public bool noke = false;
    public Camera MainCamera;

    public CursorMode cursorMode = CursorMode.Auto;

    public GameObject CharmPoint;
    public GameObject Player;
    public GameObject Pillow;
    public GameObject TvLight;
    public GameObject TrapPoint;
    public GameObject Memo;
    public GameObject SaltWaterDoll;
    public GameObject SWDoll;
    public GameObject RiceWaterDoll;
    public GameObject NailDoll;
    public GameObject HairDoll;
    public GameObject BloodDoll;
    public GameObject KnifeDoll;
    public GameObject PencilDoll;
    public GameObject RiceDoll;
    public GameObject ChoiceBlood;
    public GameObject ChoiceHair;
    public GameObject ChoiceNail;
    public GameObject ChoiceKnife;
    public GameObject ChoicePencil;
    public GameObject InputName;
    public GameObject Fade;
    public GameObject Door;
    public GameObject TV;
    public GameObject doll;
    public GameObject Chair;
    public GameObject Ghost;
    public GameObject Ghost2;
    public GameObject Dollnormalface;
    public GameObject Dollhorrorface;
    GameObject Drag;

    public InputField ip;

    public int Danger = 0;
    public int InoutDoll = 0;
    public int InoutDoll2 = 0;
    public int Time = 180;
    public int cnt = 0;

    string ipstring = "";

    public Text T;
    public Text TimeT;

    public Texture2D cursorTexture0;
    public Texture2D cursorTexture1;

    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(cursorTexture0, hotSpot, cursorMode);
    }

    void Update()
    {
        Find();
        SettingDoll2();
        SettingDoll7();
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 25f))
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

            if (tag == 8 && Input.GetMouseButtonDown(0) && !Memo.GetComponent<Memo2>().MemoView)
            {
                Drag = hitInfo.transform.gameObject;
                string name = hitInfo.transform.name;

                if (name.Equals("LampButton"))
                {
                    if (DollSet)
                    {
                        SwitchSound.Play();
                        hitInfo.transform.parent.gameObject.SetActive(false);
                        LampLight = false;
                        if (TvPower)
                        {
                            TvLight.SetActive(true);
                        }
                        if (!LampLight && TvPower)
                        {
                            StartCoroutine("SettingDoll5");
                        }
                    }
                    else
                    {
                        T.text = "일단 인형부터 준비하자.";
                    }
                }
                else if (name.Equals("TV-box"))
                {
                    if (DollSet)
                    {
                        hitInfo.transform.gameObject.layer = 1;
                        hitInfo.transform.GetChild(0).gameObject.SetActive(true);
                        TvPower = true;
                        if (!LampLight)
                        {
                            TvLight.SetActive(true);
                        }
                        if (!LampLight && TvPower)
                        {
                            StartCoroutine("SettingDoll5");
                        }
                    }
                    else
                    {
                        T.text = "일단 인형부터 준비하자.";
                    }
                }
                else if (name.Equals("부적"))
                {
                    hitInfo.transform.gameObject.SetActive(false);
                    CharmPoint.transform.gameObject.SetActive(true);
                    GetCharm = true;
                    GetSound.Play();
                    T.text = "부적을 획득했다.";
                }
                else if (name.Equals("부적위치") && GetCharm)
                {
                    GetCharm = false;
                    SetCharm = true;
                    hitInfo.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    T.text = "부적을 붙였다.";
                }
                else if (name.Equals("쌀") && !DollSet)
                {
                    hitInfo.transform.gameObject.SetActive(false);
                    GetSound.Play();
                    GetRice = true;
                    T.text = "쌀을 획득했다.";
                }
                else if (name.Equals("식칼") && !DollSet)
                {
                    hitInfo.transform.gameObject.SetActive(false);
                    GetSound.Play();
                    GetKnife = true;
                    T.text = "식칼을 획득했다.";
                }
                else if (name.Equals("연필") && !DollSet)
                {
                    hitInfo.transform.gameObject.SetActive(false);
                    GetSound.Play();
                    GetPencil = true;
                    T.text = "연필을 획득했다.";
                }
                else if (name.Equals("소금물") && !DollSet)
                {
                    hitInfo.transform.gameObject.SetActive(false);
                    GetSound.Play();
                    GetSaltWater = true;
                    T.text = "소금물을 획득했다.";
                }
                else if (name.Equals("머리카락") && !DollSet)
                {
                    hitInfo.transform.gameObject.SetActive(false);
                    GetSound.Play();
                    GetHair = true;
                    T.text = "머리카락을 획득했다.";
                }
                else if (name.Equals("손톱깍기") && !DollSet)
                {
                    hitInfo.transform.gameObject.SetActive(false);
                    GetSound.Play();
                    GetNailCutter = true;
                    T.text = "손톱깍기를 획득했다.";
                }
                else if (name.Equals("배개"))
                {
                    hitInfo.transform.gameObject.SetActive(false);
                    Pillow.transform.gameObject.SetActive(true);
                    GetSound.Play();
                }
                else if (name.Equals("끈끈이") && !DollSet)
                {
                    hitInfo.transform.gameObject.SetActive(false);
                    TrapPoint.transform.gameObject.SetActive(true);
                    GetSound.Play();
                    GetTrap = true;
                    T.text = "끈끈이를 획득했다.";
                }
                else if (name.Equals("끈끈이위치") && GetTrap && !DollSet)
                {
                    GetTrap = false;
                    hitInfo.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                    hitInfo.transform.gameObject.layer = 1;

                    T.text = "끈끈이를 설치했다.";
                    SetTrap = true;
                }
                else if (name.Equals("인형"))
                {
                    if (SetTrap && GetRice && GetSaltWater && (GetPencil || GetKnife) && (GetHair || GetBlood || GetNail))
                    {
                        if (!DollSet)
                        {
                            Player.GetComponent<PlayerMove2>().DollEvent = true;
                            Player.GetComponent<PlayerMove2>().StopEvent = true;
                            DollSet = true;
                            StartCoroutine("SettingDoll");
                        }
                        else if (FindTheDoll)
                        {
                            FindTheDoll = false;
                            Player.GetComponent<PlayerMove2>().DollEvent = true;
                            Player.GetComponent<PlayerMove2>().StopEvent = true;
                            StartCoroutine("SettingDoll6");
                        }
                        else if (DangerDoll && !NotExit)
                        {
                            DangerDoll = false;
                            StartCoroutine("SettingDoll9");
                        }
                        else if (CleanDoll)
                        {
                            CleanDoll = false;
                            StartCoroutine("SettingDoll10");
                        }
                        else if(HouseExit)
                        {
                            hitInfo.transform.gameObject.SetActive(false);
                            GetSound.Play();
                            T.text = "인형을 얻었다.";
                            GetDoll = true;
                        }
                    }
                    else
                    {
                        T.text = "아직 필요한 준비가 덜 됬다.";
                    }
                }
                else if (name.Equals("출구"))
                {
                    if (!NotExit)
                    {
                        if (!HouseExit && !DollSet)
                        {
                            T.text = "바보짓은 안하는게 최고지";
                            hitInfo.transform.gameObject.SetActive(false);
                            StartCoroutine("End3");
                        }
                        else if (!HouseExit && CleanDoll && !DangerDoll)
                        {
                            T.text = "집을 버리다니 기분이 좋지않군";
                            hitInfo.transform.gameObject.SetActive(false);
                            StartCoroutine("End4");
                        }
                        else if (!HouseExit && !CleanDoll && DangerDoll)
                        {
                            NotExit = true;
                        }
                        else if (HouseExit && !GetDoll)
                        {
                            T.text = "인형을 챙겨야한다.";
                        }
                        else if (HouseExit && GetDoll)
                        {
                            T.text = "문이 열렸다 빨리나가자.";
                            hitInfo.transform.gameObject.SetActive(false);
                            StartCoroutine("End5");
                        }
                    }
                    else
                    {
                        T.text = "왜 안열리지?";
                        StartCoroutine("GhostEnd");
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                Drag = null;
            }

            if (Drag != null && Drag.name.Equals("OpenDoor"))
            {
                var Hor = Player.GetComponent<PlayerMove2>();
                float Horizontal = Hor.Mouse_Horizontal;
                if ((Horizontal % 360 >= -90 && Horizontal % 360 <= 90) || (Horizontal % 360 <= -270) || (Horizontal % 360 >= 270))
                {
                    if (Input.GetAxis("Mouse X") > 0)
                    {
                        Drag.transform.GetComponent<Rigidbody>().velocity = new Vector3(+30, Drag.transform.GetComponent<Rigidbody>().velocity.y, Drag.transform.GetComponent<Rigidbody>().velocity.z);
                    }
                    else if (Input.GetAxis("Mouse X") < 0)
                    {
                        Drag.transform.GetComponent<Rigidbody>().velocity = new Vector3(-30, Drag.transform.GetComponent<Rigidbody>().velocity.y, Drag.transform.GetComponent<Rigidbody>().velocity.z);
                    }
                    else
                    {
                        if (Input.GetAxisRaw("Horizontal") > 0)
                        {
                            Drag.transform.GetComponent<Rigidbody>().velocity = new Vector3(+30, Drag.transform.GetComponent<Rigidbody>().velocity.y, Drag.transform.GetComponent<Rigidbody>().velocity.z);
                        }
                        else if (Input.GetAxisRaw("Horizontal") < 0)
                        {
                            Drag.transform.GetComponent<Rigidbody>().velocity = new Vector3(-30, Drag.transform.GetComponent<Rigidbody>().velocity.y, Drag.transform.GetComponent<Rigidbody>().velocity.z);
                        }
                        else
                        {
                            Drag.transform.GetComponent<Rigidbody>().velocity = new Vector3(0, Drag.transform.GetComponent<Rigidbody>().velocity.y, Drag.transform.GetComponent<Rigidbody>().velocity.z);
                        }
                    }
                }
                else
                {
                    if (Input.GetAxis("Mouse X") < 0)
                    {
                        Drag.transform.GetComponent<Rigidbody>().velocity = new Vector3(+30, Drag.transform.GetComponent<Rigidbody>().velocity.y, Drag.transform.GetComponent<Rigidbody>().velocity.z);
                    }
                    else if (Input.GetAxis("Mouse X") > 0)
                    {
                        Drag.transform.GetComponent<Rigidbody>().velocity = new Vector3(-30, Drag.transform.GetComponent<Rigidbody>().velocity.y, Drag.transform.GetComponent<Rigidbody>().velocity.z);
                    }
                    else
                    {
                        if (Input.GetAxisRaw("Horizontal") < 0)
                        {
                            Drag.transform.GetComponent<Rigidbody>().velocity = new Vector3(+30, Drag.transform.GetComponent<Rigidbody>().velocity.y, Drag.transform.GetComponent<Rigidbody>().velocity.z);
                        }
                        else if (Input.GetAxisRaw("Horizontal") > 0)
                        {
                            Drag.transform.GetComponent<Rigidbody>().velocity = new Vector3(-30, Drag.transform.GetComponent<Rigidbody>().velocity.y, Drag.transform.GetComponent<Rigidbody>().velocity.z);
                        }
                        else
                        {
                            Drag.transform.GetComponent<Rigidbody>().velocity = new Vector3(0, Drag.transform.GetComponent<Rigidbody>().velocity.y, Drag.transform.GetComponent<Rigidbody>().velocity.z);
                        }
                    }
                }
            }
        }
    }

    IEnumerator SettingDoll()
    {
        Cursor.lockState = CursorLockMode.None;
        T.text = "준비가 모두 끝났다.";
        yield return new WaitForSeconds(2f);
        T.text = "이제 나홀로 술래잡기를 하기위한 의식을 시작한다.";
        yield return new WaitForSeconds(2f);
        T.text = "준비한 인형에 쌀을 넣고";
        yield return new WaitForSeconds(2f);
        RiceWaterDoll.SetActive(true);
        for (int i = 0; i < 80; i++)
        {
            RiceWaterDoll.transform.position -= new Vector3(0, 0.2f, 0);
            yield return new WaitForSeconds(0.02f);
        }
        for (int i = 0; i < 40; i++)
        {
            RiceWaterDoll.transform.localRotation = Quaternion.Euler(-90f + i * 3, -90, -172);
            yield return new WaitForSeconds(0.02f);
        }
        RiceDoll.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            RiceSound.Play();
            RiceDoll.transform.position -= new Vector3(0, 0.2f, 0);
            yield return new WaitForSeconds(0.02f);
        }
        for (int i = 0; i < 6; i++)
        {
            RiceSound.Play();
            yield return new WaitForSeconds(1f);
        }
        RiceWaterDoll.SetActive(false);
        RiceDoll.SetActive(false);
        T.text = "준비한 자신의 신체 일부를 인형에 주자.";
        yield return new WaitForSeconds(2f);
        T.text = "어떤걸 넣지?";
        ChoiceBody();
    }

    void ChoiceBody()
    {
        if (GetBlood)
        {
            ChoiceBlood.SetActive(true);
        }
        if (GetHair)
        {
            ChoiceHair.SetActive(true);
        }
        if (GetNail)
        {
            ChoiceNail.SetActive(true);
        }
    }

    void SettingDoll2()
    {
        if (InoutDoll > 0 && Danger == 0)
        {
            ChoiceBlood.SetActive(false);
            ChoiceHair.SetActive(false);
            ChoiceNail.SetActive(false);
            if (InoutDoll == 1)
            {
                NailDoll.SetActive(true);
                StartCoroutine("InputNail");
                Danger = 1;
            }
            else if (InoutDoll == 2)
            {
                HairDoll.SetActive(true);
                StartCoroutine("InputHair");
                Danger = 3;
            }
            else if (InoutDoll == 3)
            {
                BloodDoll.SetActive(true);
                StartCoroutine("InputBlood");
                Danger = 10;
            }
        }
    }

    IEnumerator InputNail()
    {
        T.text = "";
        for (int i = 0; i < 40; i++)
        {
            NailDoll.transform.position -= new Vector3(0, 0.5f, 0);
            yield return new WaitForSeconds(0.02f);
        }
        NailDoll.SetActive(false);
        yield return new WaitForSeconds(2f);
        StartCoroutine("SettingDoll3");
    }

    IEnumerator InputHair()
    {
        T.text = "";
        for (int i = 0; i < 40; i++)
        {
            HairDoll.transform.position -= new Vector3(0, 0.5f, 0);
            yield return new WaitForSeconds(0.02f);
        }
        HairDoll.SetActive(false);
        yield return new WaitForSeconds(2f);
        StartCoroutine("SettingDoll3");
    }

    IEnumerator InputBlood()
    {
        T.text = "";
        for (int i = 0; i < 40; i++)
        {
            BloodDoll.transform.position -= new Vector3(0, 0.5f, 0);
            yield return new WaitForSeconds(0.02f);
        }
        BloodDoll.SetActive(false);
        yield return new WaitForSeconds(2f);
        StartCoroutine("SettingDoll3");
    }

    IEnumerator SettingDoll3()
    {

        T.text = "인형에게 이름을 지어주자.";
        yield return new WaitForSeconds(2f);
        InputName.SetActive(true);

    }

    public void SettingDoll4()
    {
        ipstring = ip.text + "";
        if (!String.IsNullOrEmpty(ipstring))
        {
            InputName.SetActive(false);
            T.text = "불을끄고 텔레비전을 키자.";
            Player.GetComponent<PlayerMove2>().DollEvent = false;
            Player.GetComponent<PlayerMove2>().StopEvent = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    IEnumerator SettingDoll5()
    {
        T.text = "첫번째 술레는 나";
        yield return new WaitForSeconds(2f);
        T.text = "눈을 감고 10초를 센다.";
        yield return new WaitForSeconds(2f);
        Fade.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        Player.GetComponent<PlayerMove2>().StopEvent = true;
        for (int i = 10; i > 0; i--)
        {
            T.text = i + "";
            yield return new WaitForSeconds(1f);
        }
        Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Player.GetComponent<PlayerMove2>().StopEvent = false;
        T.text = "";
        yield return new WaitForSeconds(2f);
        T.text = "이제 인형을 찾아서 뾰족한 도구로 찌른다.";
        FindTheDoll = true;
    }

    IEnumerator SettingDoll6()
    {
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitForSeconds(2f);
        T.text = ipstring + " 찾아 냈다.";
        yield return new WaitForSeconds(2f);
        T.text = "뭘로 찌르지?";
        ChoiceWeapon();
    }

    void ChoiceWeapon()
    {
        if (GetKnife)
        {
            ChoiceKnife.SetActive(true);
        }
        if (GetPencil)
        {
            ChoicePencil.SetActive(true);
        }
    }

    void SettingDoll7()
    {
        if (InoutDoll2 > 0)
        {
            ChoiceKnife.SetActive(false);
            ChoicePencil.SetActive(false);
            if (InoutDoll2 == 1)
            {
                KnifeDoll.SetActive(true);
                StartCoroutine("InputKnife");
                InoutDoll2 = 0;
                Danger += 5;
            }
            else if (InoutDoll2 == 2)
            {
                PencilDoll.SetActive(true);
                StartCoroutine("InputPencil");
                InoutDoll2 = 0;
                Danger += 2;
            }
        }
    }

    IEnumerator InputKnife()
    {
        T.text = "";
        for (int i = 0; i < 28; i++)
        {
            KnifeDoll.transform.position -= new Vector3(0, 0.5f, 0);
            yield return new WaitForSeconds(0.02f);
            if (i == 26)
            {
                PuckSound.Play();
            }
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine("SettingDoll8");
    }

    IEnumerator InputPencil()
    {
        T.text = "";
        for (int i = 0; i < 28; i++)
        {
            PencilDoll.transform.position -= new Vector3(0, 0.5f, 0);
            yield return new WaitForSeconds(0.02f);
            if (i == 26)
            {
                PuckSound.Play();
            }
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine("SettingDoll8");
    }

    IEnumerator SettingDoll8()
    {
        StartCoroutine("TimeLimit");
        T.text = "두 번째 술레는 " + ipstring + "!!";
        yield return new WaitForSeconds(2f);
        T.text = "(피난처로 숨어서 상황을 지켜보자!!)";
        Player.GetComponent<PlayerMove2>().DollEvent = false;
        Player.GetComponent<PlayerMove2>().StopEvent = false;
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(10f);
        T.text = " ";
        Player.GetComponent<PlayerMove2>().Danger = true;
        yield return new WaitForSeconds(6f);
        if (Danger > 5)
        {
            TV.SetActive(false);
            TvLight.SetActive(false);
            T.text = "갑자기 Tv가 꺼졋다";
        }

        yield return new WaitForSeconds(6f);

        if (Danger > 10)
        {
            doll.transform.position = TrapPoint.transform.position;
            doll.transform.localRotation = Quaternion.Euler(-90, 180, 0);
            KnifeDoll.SetActive(false);
            PencilDoll.SetActive(false);
            T.text = "인형이 사라진것같다";
        }
        else if (Danger > 5)
        {
            T.text = "뭔가가 쓰러지는 소리가 들렸다.";
            Chair.transform.position += new Vector3(0, 5f, 0);
            Chair.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        yield return new WaitForSeconds(6f);

        if (Danger > 5)
        {
            if (!SetCharm)
            {
                T.text = "누군가가 문을 두드린다.";
                noke = true;
            }
            else
            {
                yield return new WaitForSeconds(2f);
                T.text = "나가서 상황을 확인해보자";
                if (Danger > 10)
                {
                    DangerDoll = true;
                }
                else if (Danger > 5)
                {
                    CleanDoll = true;
                }
                Player.GetComponent<PlayerMove2>().Danger = false;
            }
        }
    }


    void Find()
    {
        if(noke)
        {
            DoorSound.SetActive(true);
        }
        if (Player.GetComponent<PlayerMove2>().Danger && Door.transform.position.x < -18f && Danger > 5 && noke == false)
        {
            Player.GetComponent<PlayerMove2>().Danger = false;
            Player.GetComponent<PlayerMove2>().StopEvent = true;
            StartCoroutine("FindEnd");

        }
        if (Player.GetComponent<PlayerMove2>().Danger && Door.transform.position.x < -15f && Danger > 5 && noke == true)
        {
            Ghost.SetActive(true);
            Player.GetComponent<PlayerMove2>().Danger = false;
            Player.GetComponent<PlayerMove2>().StopEvent = true;
            StartCoroutine("FindEnd");

        }
        else if (Player.GetComponent<PlayerMove2>().Danger && Door.transform.position.x < -18f && Danger <= 5)
        {
            Player.GetComponent<PlayerMove2>().Danger = false;
            StartCoroutine("NothingEnd");

        }
    }

    IEnumerator FindEnd()
    {
        T.text = "몸이 안움직인다.";
        yield return new WaitForSeconds(4f);
        T.color = new Color(1, 0, 0, 1);
        T.text = "찾았다";
        FindSound.Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("End1-1");
    }

    IEnumerator NothingEnd()
    {
        T.text = "뭐야? 아무일도 안일어나네?";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("End1-2");
    }

    IEnumerator TimeLimit()
    {
        if (Time <= 300)
        {
            if ((Time - (Time / 60) * 60) == 0)
            {
                TimeT.text = "AM " + Time / 60 + " : 00";
            }
            else
            {
                TimeT.text = "AM " + Time / 60 + " : " + (Time - (Time / 60) * 60);
            }
            Time += 15;
            yield return new WaitForSeconds(30f);
            StartCoroutine("TimeLimit");
        }
        else
        {
            TimeT.text = "";
            NotExit = true;
        }

    }

    IEnumerator SettingDoll9()
    {
        Cursor.lockState = CursorLockMode.None;
        Player.GetComponent<PlayerMove2>().DollEvent2 = true;
        Player.GetComponent<PlayerMove2>().StopEvent = true;
        T.text = "인형이 왜 여기있지?";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i <= 5; i++)
        {
            doll.transform.localRotation = Quaternion.Euler(-90, 180 - i * 36, 0);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        Dollhorrorface.SetActive(true);
        Dollnormalface.SetActive(false);
        yield return new WaitForSeconds(1f);
        FindSound.Play();
        T.color = new Color(1, 0, 0, 1);
        T.text = "찾았다";
        yield return new WaitForSeconds(2f);
        FindSound.Play();
        T.color = new Color(1, 0, 0, 1);
        T.text = "찾았다찾았다";
        yield return new WaitForSeconds(1f);
        FindSound.Play();
        T.color = new Color(1, 0, 0, 1);
        T.text = "찾았다찾았다";
        yield return new WaitForSeconds(0.5f);
        FindSound.Play();
        T.color = new Color(1, 0, 0, 1);
        T.text = "찾았다찾았다찾았다";
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 100; i++)
        {
            FindSound.Play();
            T.color = new Color(1, 0, 0, 1);
            T.text = "찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다" +
                "찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다" +
                "찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다" +
                "찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다찾았다";
            yield return new WaitForSeconds(0.02f);
        }
        Time += 500;
        TimeT.text = "";
        Fade.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        Player.GetComponent<PlayerMove2>().DollEvent2 = false;
        T.text = "";
        yield return new WaitForSeconds(5f);
        Player.GetComponent<PlayerMove2>().DollEvent3 = true;
        doll.SetActive(false);
        yield return new WaitForSeconds(2f);
        NotExit = true;
        Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Player.GetComponent<PlayerMove2>().StopEvent = false;
        T.color = new Color(1, 1, 1, 1);
        Cursor.lockState = CursorLockMode.Locked;
        T.text = "나한테 도대체 무슨일이 일어나고있는거지?";
        yield return new WaitForSeconds(2f);
        T.text = "어찌 됬든 이집은 위험해 나가야해";

    }

    IEnumerator GhostEnd()
    {
        GhostSound.Play();
        Player.GetComponent<PlayerMove2>().StopEvent = true;
        yield return new WaitForSeconds(2f);
        T.text = "";
        yield return new WaitForSeconds(2f);
        Player.GetComponent<PlayerMove2>().DollEvent4 = true;
        Ghost2.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("End1-1");

    }

    IEnumerator SettingDoll10()
    {
        Cursor.lockState = CursorLockMode.None;
        Player.GetComponent<PlayerMove2>().DollEvent = true;
        Player.GetComponent<PlayerMove2>().StopEvent = true;
        T.text = "놀이를 끝내기 위해 소금물을 뿌린다.";
        yield return new WaitForSeconds(2f);
        SaltWaterDoll.SetActive(true);
        for (int i = 0; i < 80; i++)
        {
            SaltWaterDoll.transform.position -= new Vector3(0, 0.2f, 0);
            yield return new WaitForSeconds(0.02f);
        }
        for (int i = 0; i < 40; i++)
        {
            SaltWaterDoll.transform.localRotation = Quaternion.Euler(-90f + i * 3, -90, -172);
            yield return new WaitForSeconds(0.02f);
        }
        SWDoll.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            SWDoll.transform.position -= new Vector3(0, 0.2f, 0);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(6f);
        SaltWaterDoll.SetActive(false);
        SWDoll.SetActive(false);
        T.text = "내가 이겼다!";
        yield return new WaitForSeconds(1f);
        T.text = " ";
        yield return new WaitForSeconds(1f);
        T.text = "내가 이겼다!";
        yield return new WaitForSeconds(1f);
        T.text = " ";
        yield return new WaitForSeconds(1f);
        T.text = "내가 이겼다!";
        yield return new WaitForSeconds(1f);
        T.text = " ";
        yield return new WaitForSeconds(1f);
        T.text = "이제 인형을 가져가서 불에 태우자!!";
        HouseExit = true;
        Player.GetComponent<PlayerMove2>().DollEvent = false;
        Player.GetComponent<PlayerMove2>().StopEvent = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator End3()
    {
        for (int i = 0; i < 25; i++)
        { 
            Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0.04f * i);
            yield return new WaitForSeconds(0.2f);
        }
        SceneManager.LoadScene("End1-3");
    }

    IEnumerator End4()
    {
        for (int i = 0; i < 25; i++)
        {
            Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0.04f * i);
            yield return new WaitForSeconds(0.2f);
        }
        SceneManager.LoadScene("End1-4");
    }

    IEnumerator End5()
    {
        for (int i = 0; i < 25; i++)
        {
            Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0.04f * i);
            yield return new WaitForSeconds(0.2f);
        }
        SceneManager.LoadScene("End1-5");
    }
}