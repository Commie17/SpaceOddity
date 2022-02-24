using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForCheck : MonoBehaviour
{
    public GameObject PreviousPlanet;
    public Vector3 Prev, Next;
    public GameObject NextPlanet;
    public GameObject ObjectOfPlayer;
    public Spawner spawner;
    public MoveControler moveControler;
    public float RangeBetweenObjAndNext, RangeBetweenObjAndPrev;
    // Start is called before the first frame update
    void Start()
    {
        PreviousPlanet = GameObject.Find("MainObject");
        ObjectOfPlayer = GameObject.Find("Object");
        NextPlanet = spawner.PlanetsOnDisplay[1];
    }

    // Update is called once per frame
    void Update()
    {
        Next = new Vector3(ObjectOfPlayer.transform.position.x - NextPlanet.transform.position.x,
        ObjectOfPlayer.transform.position.y - NextPlanet.transform.position.y);
        Prev= new Vector3(ObjectOfPlayer.transform.position.x - PreviousPlanet.transform.position.x,
        ObjectOfPlayer.transform.position.y - PreviousPlanet.transform.position.y);
        RangeBetweenObjAndNext =Vector3.Magnitude(Next);
        RangeBetweenObjAndPrev = Vector3.Magnitude(Prev);
        if (RangeBetweenObjAndNext< RangeBetweenObjAndPrev)
        {
            spawner.NumberOfSpawned--;
        }
    }
}
