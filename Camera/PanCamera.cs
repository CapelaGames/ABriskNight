using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamera : MonoBehaviour
{
    public int Boundary = 50;
    public int speed = 5;

    private int theScreenWidth;
    private int theScreenHeight;

    private bool IsPaused = false;

    public Vector3 PanLimitBottomLeftCorner;
    public Vector3 PanLimitTopRightCorner;



    void Start()
    {
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;

    }

    void Update()
    {
        Vector3 bottomLeftCorner = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
        Vector3 topRightCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));


        if (Input.GetKeyDown("p"))
        {
            IsPaused = !IsPaused;
        }

        if (IsPaused == false)
        {
            Vector3 tempPosition = transform.position;

            if (topRightCorner.x < PanLimitTopRightCorner.x)
            {
                if (Input.mousePosition.x > theScreenWidth - Boundary)
                {
                    tempPosition.x += speed * Time.deltaTime;
                }
            }
            if (bottomLeftCorner.x > PanLimitBottomLeftCorner.x)
            {
                if (Input.mousePosition.x < 0 + Boundary)
                {
                    tempPosition.x -= speed * Time.deltaTime;
                }
            }

            if (topRightCorner.y < PanLimitTopRightCorner.y)
            {
                if (Input.mousePosition.y > theScreenHeight - Boundary)
                {
                    tempPosition.y += speed * Time.deltaTime;
                }
            }

            if (bottomLeftCorner.y > PanLimitBottomLeftCorner.y)
            {
                if (Input.mousePosition.y < 0 + Boundary)
                {
                    tempPosition.y -= speed * Time.deltaTime;
                }
            }
           

            transform.position = tempPosition;
        }

    }
    /*
    void OnGUI()
    {
        GUI.Box(new Rect((Screen.width / 2) - 140, 5, 280, 25), "Mouse Position = " + Input.mousePosition);
        GUI.Box(new Rect((Screen.width / 2) - 70, Screen.height - 30, 140, 25), "Mouse X = " + Input.mousePosition.x);
        GUI.Box(new Rect(5, (Screen.height / 2) - 12, 140, 25), "Mouse Y = " + Input.mousePosition.y);
    }*/
}
