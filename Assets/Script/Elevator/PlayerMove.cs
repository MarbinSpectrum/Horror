using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public GameObject Memo;
    float alpha = 0;
    public Image Fade;
    public Text t;
    int cnt = 0;
    public Camera MainCamera;
    public GameObject Mouse;
    public AudioSource StepSound;
    float Mouse_Horizontal;            //마우스 세로 위치값
    float Mouse_Vertical;                //마우스 가로 위치값
    float Mouse_Sensitivity;            //마우스 민감도
    float Mouse_Vertical_Range;        //시야각 제한
    public SpriteRenderer Horror;
    void Start ()
    {
        MainCamera.ScreenPointToRay(new Vector2(Screen.width / 2.0f, Screen.height / 2.0f));
        Mouse_Sensitivity = 10f;            //마우스 민감도
        Mouse_Vertical_Range = 90f;        //Y축 각 제한
    }
	
	void FixedUpdate ()
    {
        Mouse_Rotate();
        Move();
        HorrorAct();
	}

    void HorrorAct()
    {
        var MView = Memo.GetComponent<Memo>();
        var MM = Mouse.GetComponent<Mouse>();
        if (MM.i >= 44 && MM.Fail == false)
        {
            Horror.color = new Color(1, 1, 1, 1);
            if (Mouse_Vertical % 360 < -40 && !MView.MemoView)
            {
                transform.position = new Vector3(0, 16, -10);
                Mouse_Horizontal = 180;
                Mouse_Vertical = -90;
                StartCoroutine("End4");
            }
        }
        else
        {
            Horror.color = new Color(1, 1, 1, 0);
        }

    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        float h = x * Mathf.Cos(Mathf.PI / 180 * Mouse_Horizontal) + z * Mathf.Sin(Mathf.PI / 180 * Mouse_Horizontal);
        float w = z * Mathf.Cos(Mathf.PI / 180 * Mouse_Horizontal) - x * Mathf.Sin(Mathf.PI / 180 * Mouse_Horizontal);
        var MM = Mouse.GetComponent<Mouse>();
        var MView = Memo.GetComponent<Memo>();
        if (h * GetComponent<Rigidbody>().velocity.x < 5 && MM.i != 6 && MView.MemoView == false)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * h * 365f);
        }
        if(MM.i == 6 && MM.Act == false)
        {
            Mouse_Vertical = 0;
        }
        if (!(Mathf.Abs(GetComponent<Rigidbody>().velocity.z) > 5) && Mathf.Abs(GetComponent<Rigidbody>().velocity.x) > 5 && MM.i != 6 && MView.MemoView == false)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Sign(GetComponent<Rigidbody>().velocity.x) * 5, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }

        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }

        if (w * GetComponent<Rigidbody>().velocity.z < 5 && MM.i != 6 && MView.MemoView == false)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * w * 365f);
        }

        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.z) > 5 && !(Mathf.Abs(GetComponent<Rigidbody>().velocity.x) > 5) && MM.i != 6 && MView.MemoView == false)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, Mathf.Sign(GetComponent<Rigidbody>().velocity.z) * 5);
        }

        if(Input.GetAxisRaw("Vertical") == 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, 0);
        }

        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.z) > 5 && Mathf.Abs(GetComponent<Rigidbody>().velocity.x) > 5 && MM.i != 6 && MView.MemoView == false)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Sign(GetComponent<Rigidbody>().velocity.x) * 5, GetComponent<Rigidbody>().velocity.y, Mathf.Sign(GetComponent<Rigidbody>().velocity.z) * 5);
        }
        if ((Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0) )
        {
            if (cnt % 30 == 0 && MM.i != 6)
            {
                StepSound.Play();
            }
            cnt++;
        }
        if ((Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0))
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

    private void OnTriggerEnter(Collider other)
    {
        var MM = Mouse.GetComponent<Mouse>();
        var MView = Memo.GetComponent<Memo>();
        if (other.gameObject.transform.name == "EXIT" && MM.i != 444 && MM.Fail == false && MM.End == 0)
        {
            MM.Fail = true;
            MView.MemoView = false;
            t.text = "이런건 안하는 것도 좋은 선택이지...";
            StartCoroutine("FadeIn");
        }
        else if (other.gameObject.transform.name == "EXIT" && MM.i != 444 && MM.Fail == false && MM.End == 1)
        {
            MM.Fail = true;
            MView.MemoView = false;
            t.text = "뭔가 느낌이 이상하다...";
            StartCoroutine("FadeIn");
        }
        else if (other.gameObject.transform.name == "EXIT" && MM.i == 444)
        {
            MM.Fail = true;
            MView.MemoView = false;
            t.text = "여기가 원래 이리 조용했나?";
            StartCoroutine("FadeInExit");
        }
    }

    IEnumerator FadeIn()
    {
        Fade.color = new Color(0, 0, 0, alpha);
        yield return new WaitForSeconds(0.1f);
        alpha += 0.02f;
        if (alpha >= 1)
        {
            var MM = Mouse.GetComponent<Mouse>();
            alpha = 0;
            alpha = 0;
            if (MM.End == 0)
            {
                SceneManager.LoadScene("End0-1");
            }
            else if (MM.End == 1)
            {
                SceneManager.LoadScene("End0-2");
            }
            else if (MM.End == 3)
            {
                SceneManager.LoadScene("End0-4");
            }
        }
        else
        {
            StartCoroutine("FadeIn");
        }
    }

    IEnumerator FadeInExit()
    {
        Fade.color = new Color(0, 0, 0, alpha);
        yield return new WaitForSeconds(0.1f);
        alpha += 0.02f;
        if (alpha >= 2f)
        {
            Fade.color = new Color(1, 1, 1, alpha);
        }
        if (alpha >= 1)
        {
            alpha = 0;
            SceneManager.LoadScene("End0-3");
        }
        else
        {
            StartCoroutine("FadeInExit");
        }
    }

    IEnumerator End4()
    {
        var MM = Mouse.GetComponent<Mouse>();
        yield return new WaitForSeconds(1f);
        MM.Fail = true;
        Fade.color = new Color(0, 0.17f, 0.44f, 1);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("End0-5");
    }
}
