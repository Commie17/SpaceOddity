using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


public class MoveControler : MonoBehaviour
{
    public GameObject Object;
    public GameObject MainObject;
    public GameObject PlanetToDelete;
    public float CoordX = 0, CoordY = 0, CoordCX, CoordCY, R, alpha = 0, distant = 0, NumberOfSpirali;
    public float[] Spirali = new float[5]{5, 4, 6, 3, 7};
    public bool isOnOrbit, OnWayBetweenPlanet=false;
    // Start is called before the first frame update
    void Start()
    {
        //if()
        isOnOrbit = true;
        NumberOfSpirali = float.Parse(MainObject.tag);
        CoordX = transform.position.x;//�������� x ���������� �������, ������� ����� ��������� �� ������
        CoordY = transform.position.y;//�������� y ���������� �������, ������� ����� ��������� �� ������
        CoordCX = MainObject.transform.position.x;//�������� x ���������� �������, �� ������ �������� ����� �������������� ��������
        CoordCY = MainObject.transform.position.y;//�������� y ���������� �������, �� ������ �������� ����� �������������� ��������
        distant = Mathf.Sqrt(Mathf.Pow(CoordCX - CoordX, 2) + Mathf.Pow(CoordCY - CoordY, 2));/*������������ ��������� �� ������� �� ����, 
        ��������������� �� ����*/
        R = /*MainObject.transform.localScale.x+*/distant;
        distant = (distant-MainObject.transform.localScale.x/1.1f) / 360/NumberOfSpirali;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//��������� ������� �� ����� 
        {

        }    

        if (OnWayBetweenPlanet)//���������, ��������� �� ������ ������ �� ���� ����� ��������� �� ������
        {

        }
        if (R < MainObject.transform.localScale.x / 2 || OnWayBetweenPlanet)//��������� �, ���� ����������, ������������� �������� �� ������ 
        {
            isOnOrbit = false;
        }
        if (isOnOrbit)//���������� �������� �� ������
        {
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
