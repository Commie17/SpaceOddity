using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


public class MoveControler : MonoBehaviour
{
    public static MoveControler Instance { get; private set; }
    public GameObject Object;
    public GameObject MainObject;
    public float CoordX = 0, CoordY = 0, CoordCX, CoordCY, R, alpha = 0, distant = 0, NumberOfSpirali, koef,a,b;
    public float[] Spirali = new float[5]{5, 4, 6, 3, 7};
    public bool isOnOrbit=true, OnWayBetweenPlanet=false,MainObjectIsChanged=false;
    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //if()
        MainObject = Spawner.Instance.PlanetsOnDisplay[0];
        isOnOrbit = true;
        NumberOfSpirali = float.Parse(MainObject.tag);
        CoordX = transform.position.x;//получаем x координату объекта, который будет двигаться по орбите
        CoordY = transform.position.y;//получаем y координату объекта, который будет двигаться по орбите
        CoordCX = MainObject.transform.position.x;//получаем x координату объекта, по орибте которого будет осуществляться движение
        CoordCY = MainObject.transform.position.y;//получаем y координату объекта, по орибте которого будет осуществляться движение
        distant = Mathf.Sqrt(Mathf.Pow(CoordCX - CoordX, 2) + Mathf.Pow(CoordCY - CoordY, 2));/*рассчитываем дистанцию от объекта до тела, 
        воздействующего на него*/
        R = /*MainObject.transform.localScale.x+*/distant;
        distant = (distant-MainObject.transform.localScale.x/1.1f) / 360/NumberOfSpirali;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) == true)//считываем нажатие на экран 
        {
            a = R * Mathf.Cos(alpha * 3) + CoordCX;
            b = R * Mathf.Sin(alpha * 3) + CoordCX;
            koef = -1 * Mathf.Cos(3 * alpha);
            isOnOrbit = false;
            OnWayBetweenPlanet = true;
        }
        MainObject = Spawner.Instance.PlanetsOnDisplay[0];
        CoordCX = MainObject.transform.position.x;
        CoordCY = MainObject.transform.position.y;
        if (OnWayBetweenPlanet)//проверяем, находится ли объект игрока на пути между планетами по прямой
        {
            CoordX += 3*Time.deltaTime;
            CoordY= koef*(CoordX-a)+b;
            transform.position = new Vector3(CoordX, CoordY);
        }
        if (R < MainObject.transform.localScale.x / 2 || OnWayBetweenPlanet)//проверяем и, если необходимо, останавливаем движение по орбите 
        {
            isOnOrbit = false;
        }
        if (isOnOrbit)//продолжаем движение по орбите
        {
            if(MainObjectIsChanged)
            {
                distant=Mathf.Sqrt(Mathf.Pow(CoordCX - CoordX, 2) + Mathf.Pow(CoordCY - CoordY, 2));
                R = distant;
                NumberOfSpirali = float.Parse(MainObject.tag);
                distant = (distant - MainObject.transform.localScale.x / 1.1f) / 360 / NumberOfSpirali;
                MainObjectIsChanged = false;
            }
            if (alpha == 360)
                alpha = 0;
            alpha += Time.deltaTime;
            R = R - distant;
            CoordX = R * Mathf.Cos(alpha * 3) + CoordCX;
            CoordY = R * Mathf.Sin(alpha * 3) + CoordCY;
            Object.transform.position = new Vector3(CoordX, CoordY);
        }
    }
}
