using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingControler : MonoBehaviour
{
    public GameObject Player, MainObject, NextPlanet=null,PlanetToDelete,Camera;
    public bool a;
    public Vector2 PlayerForce;  
    public Vector3 Os;
    public float s, b,multiplier=1, xcord,ycord, timer;
    // Start is called before the first frame update
    void Start()
    {
        s = 0;
        b = 1;
        Os.x = MainObject.transform.position.x;
        Os.y=MainObject.transform.position.y;
        Os.z = 1;
        a = true;
        PlayerForce = new Vector2(MainObject.transform.position.x - transform.position.x, MainObject.transform.position.y - transform.position.y);
        NextPlanet = Spawner.Instance.PlanetsOnDisplay[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(NextPlanet==null)
            NextPlanet = Spawner.Instance.PlanetsOnDisplay[0];
        if(a==false)
        {
            GetComponent<Rigidbody2D>().AddForce(PlayerForce * 0.0002f, ForceMode2D.Force);
        }
        if (a==true&&timer==0)//вращение вокруг оси
        {
            PlayerForce = new Vector2(MainObject.transform.position.x- transform.position.x,
            MainObject.transform.position.y - transform.position.y);
            //Os = new Vector3(MainObject.transform.position.x, MainObject.transform.position.y, 1);
            transform.RotateAround(MainObject.transform.position, Vector3.forward, multiplier*2f);
        }
    }
    private void Update()
    {
        if(timer>0)
            timer -= 1;
        if (a == false)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x+transform.position.x - xcord, 
            Camera.transform.position.y + transform.position.y - ycord,Camera.transform.position.z);
        }
        if (Input.GetMouseButtonUp(0) == true)
        {
            b--;
            PlayerForce = new Vector2(multiplier*PlayerForce.y,-1*PlayerForce.x*multiplier);
            a = false;
            GetComponent<Rigidbody2D>().AddForce(PlayerForce * 0.0002f, ForceMode2D.Impulse);
        }
        xcord = transform.position.x;
        ycord = transform.position.y;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger&&b<1)
        {
            PlanetToDelete = MainObject;
            MainObject = NextPlanet;
            NextPlanet = (GameObject)Spawner.Instance.PlanetsOnDisplay[1];
            Os.x = MainObject.transform.position.x;
            Os.y = MainObject.transform.position.y;
            Spawner.Instance.NumberOfSpawned--;
            b++;
            a = true;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            multiplier *= -1;
            timer = 8;
            Destroy(PlanetToDelete, 1);
        }
    }
}
