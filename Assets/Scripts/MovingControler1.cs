using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingControler1 : MonoBehaviour
{
    public GameObject Player, MainObject, NextPlanet = null, PlanetToDelete, Camera, pointForOrientation;
    public static MovingControler1 Instance { get; private set; }
    public Vector2 PlayerForce;
    public Touch touch = Input.GetTouch(0);
    public float b, multiplier = 1;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        multiplier = 1;
        touch.position = pointForOrientation.transform.position;
        b = 1;
        PlayerForce = new Vector2(MainObject.transform.position.x - transform.position.x, MainObject.transform.position.y - transform.position.y);
    }

    void FixedUpdate()
    {
        if (NextPlanet == null)
            NextPlanet = Spawner.Instance.PlanetsOnDisplay[0];
        if (b == 0)//moving between planets
        {
            MoveBetweenPlanets();
        }
        if (b == 1)//Rotation around planet in case when b==1
        {
            MoveAroundPlanet();
        }
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, PlayerForce, Color.red);
        //touch = Input.GetTouch(0);
        if (Input.GetMouseButtonDown(0) == true && b == 1)//jump to space from planet's orbit
        {
            b--;
            CameraControler.Instance.onOrbit = false;
            PlayerForce = new Vector2(multiplier * PlayerForce.y, -1 * PlayerForce.x * multiplier);
            PlayerForce = 10*PlayerForce.normalized;
            GetComponent<Rigidbody2D>().AddForce(PlayerForce * 0.0002f, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//it describes what happend in case of entiring to new orbit
    {
        if (collision.isTrigger && b < 1)
        {
            PlanetToDelete = MainObject;
            MainObject = NextPlanet;
            NextPlanet = (GameObject)Spawner.Instance.PlanetsOnDisplay[1];
            CameraControler.Instance.CurrentPlanet = MainObject;
            Spawner.Instance.NumberOfSpawned--;
            b++;
            CameraControler.Instance.onOrbit = true;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            multiplier *= -1;
            Destroy(PlanetToDelete, 1);
        }
    }

    public void ChamgingOfMovingVector()//this function changes vector of velocity of player's object
    {
        GetComponent<Rigidbody2D>().velocity += PlayerForce/3;
    }

    void MoveAroundPlanet()//to fly by planet's orbit
    {
        PlayerForce = new Vector2(MainObject.transform.position.x - transform.position.x,
        MainObject.transform.position.y - transform.position.y);
        transform.RotateAround(MainObject.transform.position, Vector3.forward, multiplier * 2f);
    }

    void MoveBetweenPlanets()
    {
        GetComponent<Rigidbody2D>().AddForce(PlayerForce * 0.00002f, ForceMode2D.Force);
        if (Input.GetTouch(0).position.x > pointForOrientation.transform.position.x && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            PlayerForce = Quaternion.Euler(0, 0, -1f) * PlayerForce;
            GetComponent<Rigidbody2D>().velocity = PlayerForce;
        }
        if (Input.GetTouch(0).position.x < pointForOrientation.transform.position.x && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            PlayerForce = Quaternion.Euler(0, 0, 1f) * PlayerForce;
            GetComponent<Rigidbody2D>().velocity = PlayerForce;
        }
    }
    //To use mouse as a directing instrument use this piece of code
    //if (Input.GetMouseButton(0) == true)
    //        {
    //            PlayerForce = Quaternion.Euler(0, 0, 1f) * PlayerForce;
    //            GetComponent<Rigidbody2D>().velocity = PlayerForce;
    //        }
    //    if (Input.GetMouseButton(1) == true)
    //{
    //    PlayerForce = Quaternion.Euler(0, 0, -1f) * PlayerForce;
    //    GetComponent<Rigidbody2D>().velocity = PlayerForce;
    //}
}