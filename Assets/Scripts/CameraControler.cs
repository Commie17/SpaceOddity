using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControler : MonoBehaviour
{
    public static CameraControler Instance { get; private set; }
    public GameObject CurrentPlanet,PlayerObject;
    public GameObject Vcam;
    public bool onOrbit, OnWay;
    public GameObject PositionForCamera;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        PositionForCamera.transform.position = new Vector3(CurrentPlanet.transform.position.x, CurrentPlanet.transform.position.y+30, 
           CurrentPlanet.transform.position.z);
        Vcam.GetComponent<CinemachineVirtualCamera>().m_Follow = PositionForCamera.transform;
        onOrbit = false;
    }

    void Update()
    {
        if (MovingControler1.Instance.b == 0 && onOrbit == false)
            FocusOnPlayer();
        else if (MovingControler1.Instance.b == 1 && onOrbit == true)
            FocusOnPlanet();
    }
    public void FocusOnPlanet()
    {
        PositionForCamera.transform.position = new Vector3(CurrentPlanet.transform.position.x, CurrentPlanet.transform.position.y + 30,
          CurrentPlanet.transform.position.z);
        Vcam.GetComponent<CinemachineVirtualCamera>().m_Follow = PositionForCamera.transform;
        onOrbit = false;
    }
    public void FocusOnPlayer()
    {
        Vcam.GetComponent<CinemachineVirtualCamera>().m_Follow = PlayerObject.transform;
        onOrbit = true;
    }
}
