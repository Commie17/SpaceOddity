using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }
    public GameObject[] PrefabsOfPlanets=new GameObject[5];
    public GameObject[] PlanetsOnDisplay = new GameObject[4];
    public GameObject PointOfSpawn;
    public bool isSpawned=false;
    public int NumberOfSpawned, mnojitel=1;
    // Start is called before the first frame update
    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //------------Внимание! так, как указано ниже, делать не стоит------------------- 
        //PlanetsOnDisplay[0] = PrefabsOfPlanets[Random.Range(0, 4)];        
        //Instantiate(PlanetsOnDisplay[0], transform.position, transform.rotation);
        //данный способ создаст исключительно копию объекта из массива как самостоятельный объект, не ссылающийся на объект исходный
        //то есть объект PlanetsOnDisplay[0] и объект, созданный методом Instantiate(PlanetsOnDisplay[0], transform.position, transform.rotation)
        //будут совершенно РАЗНЫМИ
        //-------------------------------------Конец-------------------------------------
        transform.position = new Vector3(transform.position.x +
        Random.Range(10, 12), transform.position.y + Random.Range(48,52));//начинаем создавать планеты,
        //считая от начального объекта

        PlanetsOnDisplay[0]=Instantiate(PrefabsOfPlanets[Random.Range(0, 4)], transform.position, transform.rotation);
        transform.position = new Vector3(transform.position.x +
        (-1) * Random.Range(10, 12), transform.position.y + Random.Range(48, 52));//считаем уже от точки появления, создавая третью планету
        PlanetsOnDisplay[1] = Instantiate(PrefabsOfPlanets[Random.Range(0, 4)], transform.position, transform.rotation);
        transform.position = new Vector3(transform.position.x +
        Random.Range(10, 12), transform.position.y + Random.Range(48, 52));
        //снова от точки поялвения, но для четвёртой планеты
        PlanetsOnDisplay[2]=Instantiate(PrefabsOfPlanets[Random.Range(0, 4)], transform.position, transform.rotation);
        transform.position = new Vector3(transform.position.x +
        (-1)*Random.Range(10, 12), transform.position.y + Random.Range(48, 52));
        PlanetsOnDisplay[3]=Instantiate(PrefabsOfPlanets[Random.Range(0, 4)], transform.position, transform.rotation);
        mnojitel = -1;//используем данную переменную для смены направления появления планет, чтобы находиться примерно в одном коридоре
        NumberOfSpawned = 4;//контрольная переменная для скрипта-спануера
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (NumberOfSpawned<4)//данное условие позволяет поддерживать необходимое количество планет на экране 
       {
            transform.position = new Vector3(transform.position.x +
            mnojitel*Random.Range(10, 12), transform.position.y + Random.Range(48, 52));
            NumberOfSpawned++; 
            //а далее сдвигаем массив, добавляя новую планету
            for (int i = 0; i < 4; i++)//данный цикл сдвигает объекты влево, освобождая одно место для новой планеты
            {

                if(i<3)//просто сдвигаем планеты, остающиеся на экране
                {
                    PlanetsOnDisplay[i] =PlanetsOnDisplay[i+1];
                }
                else if(i==3)//добавляем на экран новую планету
                {
                    PlanetsOnDisplay[i] = Instantiate(PrefabsOfPlanets[Random.Range(0, 4)], transform.position, transform.rotation);
                }
            }
            mnojitel *= -1;
        }
    }
}
