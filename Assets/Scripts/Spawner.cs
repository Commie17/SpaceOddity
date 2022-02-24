using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] PrefabsOfPlanets=new GameObject[5];
    public GameObject[] PlanetsOnDisplay = new GameObject[4];
    public GameObject PointOfSpawn;
    public ScriptForCheck scriptForCheck;
    public MoveControler moveControler;
    public bool isSpawned=false;
    public int NumberOfSpawned, mnojitel=1;
    // Start is called before the first frame update
    void Start()
    {
        PlanetsOnDisplay[0] = GameObject.Find("MainObject");        
        PlanetsOnDisplay[1] = PrefabsOfPlanets[Random.Range(0, 4)];
        PlanetsOnDisplay[2] = PrefabsOfPlanets[Random.Range(0, 4)];
        PlanetsOnDisplay[3] = PrefabsOfPlanets[Random.Range(0, 4)];
        transform.position = new Vector3(transform.position.x +
        Random.Range(6, 10), transform.position.y + Random.Range(10, 15));//начинаем создавать планеты,
        //счита€ от начального объекта
        Instantiate(PlanetsOnDisplay[1], transform.position, transform.rotation);
        transform.position = new Vector3(transform.position.x +
        (-1) * Random.Range(6, 10), transform.position.y + Random.Range(10, 15));//считаем уже от точки по€влени€, создава€ третью планету
        Instantiate(PlanetsOnDisplay[2], transform.position, transform.rotation);
        transform.position = new Vector3(transform.position.x +
        Random.Range(6, 10), transform.position.y + Random.Range(10, 15));//снова от точки по€лвени€, но дл€ четвЄртой планеты
        Instantiate(PlanetsOnDisplay[3], transform.position, transform.rotation);
        mnojitel = -1;//используем данную переменную дл€ смены направлени€ по€влени€ планет, чтобы находитьс€ примерно в одном коридоре
        NumberOfSpawned = 4;//контрольна€ переменна€ дл€ скрипта-спануера
    }

    // Update is called once per frame
    void Update()
    {
        if (NumberOfSpawned<4)//данное условие позвол€ет поддерживать необходимое количество планет на экране 
       {
            moveControler.PlanetToDelete = PlanetsOnDisplay[0];//передаЄм новую планету дл€ удалени€ с экрана, 
            //а далее сдвигаем массив, добавл€€ новую планету
            for (int i = 0; i < 4; i++)//данный цикл сдвигает объекты влево, освобожда€ одно место дл€ новой планеты
            {

                if(i<4)//просто сдвигаем планеты, остающиес€ на экране
                {
                    PlanetsOnDisplay[i] =PlanetsOnDisplay[i+1];
                }
                else if(i==4)//добавл€ем на экран новую планету
                {
                    PlanetsOnDisplay[i] = PrefabsOfPlanets[Random.Range(0, 4)];
                }
            }
            transform.position = new Vector3(transform.position.x +
            mnojitel*Random.Range(6, 10), transform.position.y + Random.Range(10, 15));
            Instantiate(PlanetsOnDisplay[4], transform.position, transform.rotation);
            mnojitel *= -1;
            NumberOfSpawned++;
            scriptForCheck.NextPlanet = PlanetsOnDisplay[1];
            scriptForCheck.PreviousPlanet = PlanetsOnDisplay[0];
            moveControler.CoordCX=
        }
    }
}
