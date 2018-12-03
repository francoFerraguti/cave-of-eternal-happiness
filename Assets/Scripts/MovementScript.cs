using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    GameObject textManager;
    GameObject black;

    bool introFinished = false;
    public bool canMove = true;
    public bool canFly = true;

    bool onlyForwardAllowed = false;

    float movementSpeed = 60.0f;

    void Awake()
    {
        textManager = GameObject.Find("TextManager");
        black = GameObject.Find("Black");
    }

    void Update()
    {
        if (!introFinished || !canMove)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed, Space.Self);

            if (onlyForwardAllowed)
            {
                black.GetComponent<BlackScript>().Advance();
            }
        }

        if (onlyForwardAllowed)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector3.right * Time.deltaTime * movementSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * movementSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * movementSpeed, Space.Self);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (!introFinished) return;

        if (transform.position.y < 10)
        {
            transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        }

        if (other.gameObject.name == "entrance_01")
        {
            checkBoundariesEntrance();
        }

        if (other.gameObject.name == "corridor_01")
        {
            checkBoundariesCorridor01();
        }

        if (other.gameObject.name == "room_01")
        {
            if (!textManager.GetComponent<TextManager>().hasSaidMeetsEye)
            {
                textManager.GetComponent<TextManager>().sayMeetsEye();
            }

            checkBoundariesRoom01();
        }

        if (other.gameObject.name == "corridor_02")
        {
            if (!textManager.GetComponent<TextManager>().hasSaidGhostUseful)
            {
                textManager.GetComponent<TextManager>().sayGhostUseful();
            }

            checkBoundariesCorridor02();
        }

        if (other.gameObject.name == "room_02")
        {
            checkBoundariesRoom02();
        }

        if (other.gameObject.name == "corridor_03")
        {
            checkBoundariesCorridor03();
        }
        if (other.gameObject.name == "room_03")
        {
            if (this.canFly)
            {
                this.canFly = false;
                textManager.GetComponent<TextManager>().sayNoCanFly();
            }
            checkBoundariesRoom03();
        }

        if (other.gameObject.name == "corridor_04")
        {
            if (!textManager.GetComponent<TextManager>().hasSaidName)
            {
                textManager.GetComponent<TextManager>().sayName();
            }

            checkBoundariesCorridor04();
        }
        if (other.gameObject.name == "room_04")
        {
            checkBoundariesRoom04();
        }
        if (other.gameObject.name == "corridor_05")
        {
            checkBoundariesCorridor05();
        }
        if (other.gameObject.name == "room_05")
        {
            if (!onlyForwardAllowed)
            {
                onlyForwardAllowed = true;
            }

            checkBoundariesRoom05();
        }

        if (!canFly)
        {
            transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        }
    }

    void capX(float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
    void capY(float y)
    {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
    void capZ(float z)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }

    void checkBoundariesRoom01()
    {
        if (transform.position.x > 52) capX(52);
        if (transform.position.x < -52) capX(-52);

        if (transform.position.x > 28 && transform.position.z > -240) capZ(-240);
        if (transform.position.x < -28 && transform.position.z > -240) capZ(-240);

        if (transform.position.z < -340 && (transform.position.x < 26 || transform.position.y > 50)) capZ(-340);
    }
    void checkBoundariesCorridor02()
    {
        if (transform.position.x > 55) capX(55);
        if (transform.position.x < 44) capX(44);
        if (transform.position.y > 33) capY(33);

    }
    void checkBoundariesRoom02()
    {
        if (transform.position.x > 101) capX(101);
        if (transform.position.x < -4 && (transform.position.z < -460 || transform.position.y > 23)) capX(-4);
        if (transform.position.y > 113) capY(113);
        if (transform.position.z < -550) capZ(-550);
        if (transform.position.z > -440 && (transform.position.x > 60 || transform.position.x < 40 || transform.position.y > 43)) capZ(-440);

    }
    void checkBoundariesCorridor03()
    {
        if (transform.position.z < -453) capZ(-453);
        if (transform.position.z > -442) capZ(-442);
        if (transform.position.y > 17) capY(17);

    }
    void checkBoundariesRoom03()
    {
        if (transform.position.z < -520) capZ(-520);
        if (transform.position.z > -373) capZ(-373);
        if (transform.position.x < -246 && (transform.position.z < -460 || transform.position.z > -435)) capX(-246);
        if (transform.position.x > -98 && (transform.position.z < -460 || transform.position.z > -435)) capX(-98);
    }
    void checkBoundariesCorridor04()
    {
        if (transform.position.z < -464) capZ(-464);
        if (transform.position.z > -432) capZ(-432);
    }
    void checkBoundariesRoom04()
    {
        if (transform.position.z < -504) capZ(-504);
        if (transform.position.z > -392 && (transform.position.x < -405 || transform.position.x > -387)) capZ(-392);
        if (transform.position.x < -443) capX(-443);
        if (transform.position.x > -333 && (transform.position.z < -460 || transform.position.z > -435)) capX(-333);

    }
    void checkBoundariesCorridor05()
    {
        if (transform.position.x < -402 && transform.position.z < -317) capX(-402);
        if (transform.position.x > -392) capX(-392);
        if (transform.position.z > -305) capZ(-305);
    }
    void checkBoundariesRoom05()
    {

    }

    void checkBoundariesCorridor01()
    {
        if (transform.position.x < -17)
        {
            transform.position = new Vector3(-17, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 17)
        {
            transform.position = new Vector3(17, transform.position.y, transform.position.z);
        }

        if (transform.position.y > 90)
        {
            transform.position = new Vector3(transform.position.x, 90, transform.position.z);
        }
    }

    void checkBoundariesEntrance()
    {

        if (transform.position.y > 200)
        {
            transform.position = new Vector3(transform.position.x, 200, transform.position.z);
        }

        if ((transform.position.z < -113 && transform.position.x > 16) ||
            (transform.position.z < -113 && transform.position.x < -16) ||
            (transform.position.z < -113 && transform.position.y > 93))
        {
            if (!textManager.GetComponent<TextManager>().hasSaidWallText)
            {
                textManager.GetComponent<TextManager>().sayWallText();
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, -113);
        }
        if (transform.position.z > 113)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 113);
        }

        if (transform.position.x < -107)
        {
            if (!textManager.GetComponent<TextManager>().hasSaidWallText)
            {
                textManager.GetComponent<TextManager>().sayWallText();
            }

            transform.position = new Vector3(-107, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 107)
        {
            if (!textManager.GetComponent<TextManager>().hasSaidWallText)
            {
                textManager.GetComponent<TextManager>().sayWallText();
            }

            transform.position = new Vector3(107, transform.position.y, transform.position.z);
        }

    }

    public void SetIntroFinished()
    {
        introFinished = true;
    }
}
