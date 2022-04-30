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
        //------------��������! ���, ��� ������� ����, ������ �� �����------------------- 
        //PlanetsOnDisplay[0] = PrefabsOfPlanets[Random.Range(0, 4)];        
        //Instantiate(PlanetsOnDisplay[0], transform.position, transform.rotation);
        //������ ������ ������� ������������� ����� ������� �� ������� ��� ��������������� ������, �� ����������� �� ������ ��������
        //�� ���� ������ PlanetsOnDisplay[0] � ������, ��������� ������� Instantiate(PlanetsOnDisplay[0], transform.position, transform.rotation)
        //����� ���������� �������
        //-------------------------------------�����-------------------------------------
        transform.position = new Vector3(transform.position.x +
        Random.Range(10, 12), transform.position.y + Random.Range(48,52));//�������� ��������� �������,
        //������ �� ���������� �������

        PlanetsOnDisplay[0]=Instantiate(PrefabsOfPlanets[Random.Range(0, 4)], transform.position, transform.rotation);
        transform.position = new Vector3(transform.position.x +
        (-1) * Random.Range(10, 12), transform.position.y + Random.Range(48, 52));//������� ��� �� ����� ���������, �������� ������ �������
        PlanetsOnDisplay[1] = Instantiate(PrefabsOfPlanets[Random.Range(0, 4)], transform.position, transform.rotation);
        transform.position = new Vector3(transform.position.x +
        Random.Range(10, 12), transform.position.y + Random.Range(48, 52));
        //����� �� ����� ���������, �� ��� �������� �������
        PlanetsOnDisplay[2]=Instantiate(PrefabsOfPlanets[Random.Range(0, 4)], transform.position, transform.rotation);
        transform.position = new Vector3(transform.position.x +
        (-1)*Random.Range(10, 12), transform.position.y + Random.Range(48, 52));
        PlanetsOnDisplay[3]=Instantiate(PrefabsOfPlanets[Random.Range(0, 4)], transform.position, transform.rotation);
        mnojitel = -1;//���������� ������ ���������� ��� ����� ����������� ��������� ������, ����� ���������� �������� � ����� ��������
        NumberOfSpawned = 4;//����������� ���������� ��� �������-��������
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (NumberOfSpawned<4)//������ ������� ��������� ������������ ����������� ���������� ������ �� ������ 
       {
            transform.position = new Vector3(transform.position.x +
            mnojitel*Random.Range(10, 12), transform.position.y + Random.Range(48, 52));
            NumberOfSpawned++; 
            //� ����� �������� ������, �������� ����� �������
            for (int i = 0; i < 4; i++)//������ ���� �������� ������� �����, ���������� ���� ����� ��� ����� �������
            {

                if(i<3)//������ �������� �������, ���������� �� ������
                {
                    PlanetsOnDisplay[i] =PlanetsOnDisplay[i+1];
                }
                else if(i==3)//��������� �� ����� ����� �������
                {
                    PlanetsOnDisplay[i] = Instantiate(PrefabsOfPlanets[Random.Range(0, 4)], transform.position, transform.rotation);
                }
            }
            mnojitel *= -1;
        }
    }
}
