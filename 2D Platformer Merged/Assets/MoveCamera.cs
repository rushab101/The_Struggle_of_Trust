using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MoveCamera : MonoBehaviour
{
    
public CinemachineVirtualCamera vcam;

	public float moveSpeed;
    private float Reset_Y=0.7f;
	void Update () 
	{
      //  Camera.main.transform.position += -Vector3.up * moveSpeed  * Time.deltaTime;

    
      if (Input.GetKey(KeyCode.DownArrow) &&  vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY>0.5f){
       vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY-=moveSpeed * Time.deltaTime;
    }
    else if (Input.GetKey(KeyCode.DownArrow) &&  vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY<=0.5f)
    {
        vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.5f;
    }
    else 
    {
        vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = Reset_Y;
    }
	
	}
}
