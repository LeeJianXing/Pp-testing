using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class UI_Handler : MonoBehaviour
{
    public GameObject Camera;
    public GameObject PlayerStats;
    public GameObject Xbutton;

   

    private Vector3 camMoveLeft;
    private Vector3 camMoveFastLeft;
    private Vector3 camMoveRight;
    private Vector3 camMoveFastRight;

    private Vector3 CamOriPos = new Vector3(0.0f, 0, -2); //cam origial postion
    private Vector3 CamMaxPos =new Vector3(1000.0f, 0, -2);  // cam maxinum pos


    [SerializeField] private float camPosX;
    [SerializeField] private float trackMouseDownTime;

    private float leftBound = 0.0f;
    private float rightBound = 1000.0f;
    private float moveValue = 100.0f;
    private float mouseDownTime = 0.2f;
    private float time;

    private  bool ButtonLeftPressed;
    private  bool ButtonRightPressed;


    private void Start()
    {
        camPosX = 0;
    }
    private void Update()
    {
        if (ButtonLeftPressed)
        {
            MouseDownCamLeft();
     
        }

        if (ButtonRightPressed)
        {
            MouseDownCamRight();

        }

        if (camPosX < leftBound )
        {
           
            Camera.transform.position = CamOriPos;
            camPosX = Camera.transform.position.x;
        }

        if (camPosX > rightBound )
        {
          
            Camera.transform.position = CamMaxPos;
            camPosX = Camera.transform.position.x;
        }

    }

    public void PointRightButtonDown()
    {
        ButtonRightPressed = true;
    }

    public void PointRightButtonUp()
    {
        ButtonRightPressed = false;
        trackMouseDownTime = 0;
        time = 0;
    }
    public void PointLeftButtonDown()
    {
        ButtonLeftPressed = true;
    }

    public void PointLeftButtonUp()
    {
        ButtonLeftPressed = false;
        trackMouseDownTime = 0;
        time = 0;
    }
    public void goOutDoorScene()
    {
        SceneManager.LoadScene("Outdoor");
    }

    public void CameraGoLeft()
    {      
        camMoveLeft = new Vector2(-moveValue, 0);

        if (camPosX > leftBound)
        {
            Camera.transform.position = Camera.transform.position + camMoveLeft;
            camPosX = Camera.transform.position.x;
        }      
    }
    public void CameraGoRight()
    {           
        camMoveRight = new Vector2(moveValue, 0);

        if (camPosX < rightBound)
        {
            Camera.transform.position = Camera.transform.position + camMoveRight;
            camPosX = Camera.transform.position.x;
        }
    }

    public void MouseDownCamLeft()
    {
        time = Time.deltaTime;
        trackMouseDownTime += time;   
       
        camMoveFastLeft = new Vector2(-moveValue * 5, 0);

        if (camPosX > leftBound && trackMouseDownTime > mouseDownTime)
        {
            Camera.transform.position = Camera.transform.position + camMoveFastLeft * Time.deltaTime;
            camPosX = Camera.transform.position.x;
        }
    }
    public void MouseDownCamRight()
    {
        time = Time.deltaTime;
        trackMouseDownTime += time;
       
        camMoveFastRight = new Vector2(moveValue * 5, 0);

        if (camPosX < rightBound && trackMouseDownTime > mouseDownTime)
        {
            Camera.transform.position = Camera.transform.position + camMoveFastRight * Time.deltaTime;
            camPosX = Camera.transform.position.x;
        }
    }

    public void InventoryCilcked()
    { // canvas pos a little weird because is screen space-camera i follow the main canvas coordinate as reference
       float canvasXPos = 960;
       float canvasYUpPos = 640;

       Vector2 PlayerStatsUp = new Vector2(canvasXPos,canvasYUpPos);
       Xbutton.SetActive(true);
       PlayerStats.transform.position = PlayerStatsUp;
    }

    public void InventoryXCilcked()
    {
        float canvasXPos = 960;
        float canvasYOriPos = 540;

        Vector2 PlayerStatsOriPos = new Vector2(canvasXPos,canvasYOriPos);
        Xbutton.SetActive(false);
        PlayerStats.transform.position = PlayerStatsOriPos;
    }

   



}
