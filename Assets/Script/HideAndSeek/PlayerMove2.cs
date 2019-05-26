using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove2 : MonoBehaviour
{
    public AudioSource StepSound;
    public AudioSource FindSound;

    public Camera MainCamera;


    public GameObject Memo;
    public GameObject DollPoint;
    public GameObject DollPoint2;
    public GameObject DollPoint3;
    public GameObject DollPoint4;

    public bool DollEvent = false;
    public bool DollEvent2 = false;
    public bool DollEvent3 = false;
    public bool DollEvent4 = false;
    public bool Danger = false;
    public bool StopEvent = false;

    public float Mouse_Horizontal;            //마우스 세로 위치값
    public float Mouse_Vertical;                //마우스 가로 위치값

    float Mouse_Sensitivity;            //마우스 민감도
    float Mouse_Vertical_Range;        //시야각 제한
    float MoveSpeed = 20f;

    int cnt = 0;

    void Start()
    {
        MainCamera.ScreenPointToRay(new Vector2(Screen.width / 2.0f, Screen.height / 2.0f));
        Mouse_Sensitivity = 10f;            //마우스 민감도
        Mouse_Vertical_Range = 90f;        //Y축 각 제한
    }

    void Update()
    {
        if (DollEvent)
        {
            transform.position = DollPoint.transform.position;
            MainCamera.transform.localRotation = Quaternion.Euler(28.5f, 0, 0);
            DollEvent = false;
        }
        if (DollEvent2)
        {
            transform.position = DollPoint2.transform.position;
            MainCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
            DollEvent2 = false;
        }
        if (DollEvent3)
        {
            transform.position = DollPoint3.transform.position;
            MainCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
            DollEvent3 = false;
        }
        if (DollEvent4)
        {
            transform.position = DollPoint4.transform.position;
            MainCamera.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void FixedUpdate()
    {
        var MemoView = Memo.GetComponent<Memo2>();
        if (!(MemoView.MemoView || StopEvent))
        {
            Mouse_Rotate();
            Move();
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        float h = x * Mathf.Cos(Mathf.PI / 180f * Mouse_Horizontal) + z * Mathf.Sin(Mathf.PI / 180f * Mouse_Horizontal);
        float w = z * Mathf.Cos(Mathf.PI / 180f * Mouse_Horizontal) - x * Mathf.Sin(Mathf.PI / 180f * Mouse_Horizontal);

        GetComponent<Rigidbody>().velocity = new Vector3(MoveSpeed * h, GetComponent<Rigidbody>().velocity.y, MoveSpeed * w);

        if (x != 0 || z != 0)
        {
            cnt++;
            if (cnt % 30 == 0)
            {
                StepSound.Play();
            }
        }
        else
        {
            cnt = 0;
        }
    }

    void Mouse_Rotate()
    {
        Mouse_Horizontal += Input.GetAxis("Mouse X") * Mouse_Sensitivity;
        Mouse_Vertical -= Input.GetAxis("Mouse Y") * Mouse_Sensitivity;

        Mouse_Vertical = Mathf.Clamp(Mouse_Vertical, -Mouse_Vertical_Range, Mouse_Vertical_Range);
        MainCamera.transform.localRotation = Quaternion.Euler(Mouse_Vertical, Mouse_Horizontal, 0f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.name.Equals("피난소로!") && Danger)
        {
            if(Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().Danger > 5)
            {
                Danger = false;
                StopEvent = true;
                StartCoroutine("FindEnd");
            }
            else if (Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().Danger <= 5)
            {
                Danger = false;
                StartCoroutine("NothingEnd");
            }

        }
    }

    IEnumerator FindEnd()
    {
        Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().T.text = "몸이 안움직인다.";
        yield return new WaitForSeconds(4f);
        Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().T.color = new Color(1, 0, 0, 1);
        Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().T.text = "찾았다";
        FindSound.Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("End1-1");
    }

    IEnumerator NothingEnd()
    {
        Memo.GetComponent<Memo2>().Mouse.GetComponent<Mouse2>().T.text = "뭐야? 아무일도 안일어나네?";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("End1-2");
    }
}