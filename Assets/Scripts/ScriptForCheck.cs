using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForCheck : MonoBehaviour
{
    public static ScriptForCheck Instance { get; private set; }
    public GameObject PreviousPlanet;
    public Vector3 Prev, Next;
    public GameObject NextPlanet;
    public GameObject ObjectOfPlayer;
    public float RangeBetweenObjAndNext, RangeBetweenObjAndPrev;
    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PreviousPlanet = Spawner.Instance.PlanetsOnDisplay[0];
        NextPlanet = Spawner.Instance.PlanetsOnDisplay[1];
    }

    // Update is called once per frame
    void Update()
    {
        PreviousPlanet = Spawner.Instance.PlanetsOnDisplay[0];
        NextPlanet = Spawner.Instance.PlanetsOnDisplay[1];
        RangeBetweenObjAndNext = Mathf.Sqrt(Mathf.Pow(NextPlanet.transform.position.x
            - ObjectOfPlayer.transform.position.x, 2) + Mathf.Pow(NextPlanet.transform.position.y
            - ObjectOfPlayer.transform.position.y, 2));
        RangeBetweenObjAndPrev = Mathf.Sqrt(Mathf.Pow(PreviousPlanet.transform.position.x
            - ObjectOfPlayer.transform.position.x, 2) + Mathf.Pow(PreviousPlanet.transform.position.y
            - ObjectOfPlayer.transform.position.y, 2)); 
        if (RangeBetweenObjAndNext< RangeBetweenObjAndPrev)
        {
            Spawner.Instance.NumberOfSpawned--;
        }
        //if (RangeBetweenObjAndNext < RangeBetweenObjAndPrev && Mathf.Sqrt(Mathf.Pow(PreviousPlanet.transform.position.x
        //    - ObjectOfPlayer.transform.position.x, 2) + Mathf.Pow(PreviousPlanet.transform.position.y 
        //    - ObjectOfPlayer.transform.position.y, 2))<PreviousPlanet.transform.localScale.x*2)
        //{
        //    MoveControler.Instance.isOnOrbit = true;
        //    MoveControler.Instance.MainObjectIsChanged = true;
        //    //Destroy(Spawner.Instance.PlanetToDelete);
        //}
    }
}
