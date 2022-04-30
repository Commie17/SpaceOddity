using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuControler : MonoBehaviour
{
    public Text GreetingsText;
    [SerializeField] private InputField TextFromInputField;
    public string testVariable;
    public GameObject MainMenuha;
    public GameObject RenameMenu;
    public void PlayButtonPressed()// ����� ����
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SetNameButtonPressed()//������� � ���� ��������� ������ �����
    {
        MainMenuha.SetActive(false);
        RenameMenu.SetActive(true);
    }
    public void SetNewNameButtonPressed()//��� ��������� ������ �����
    {
        GreetingsText.text = "����� ����������, "+TextFromInputField.text;
        PlayerPrefs.SetString("PlayerName", TextFromInputField.text);
        TextFromInputField.text = "";
        RenameMenu.SetActive(false);
        MainMenuha.SetActive(true);
    }
    public void BackRenMenuButtonPressed()//��� �������� �� ���� �������������� ������� � ������� 
    {
        RenameMenu.SetActive(false);
        MainMenuha.SetActive(true);
    }
    public void ExitButtonPressed()//������ ������
    {
        Application.Quit();
    }
    public void Awake()
    {
        if (PlayerPrefs.GetString("PlayerName") == null)
            GreetingsText.text = "����� ����������, ����� �����!";
        else
        {
            testVariable = PlayerPrefs.GetString("PlayerName");
            GreetingsText.text = "����� ����������, "+PlayerPrefs.GetString("PlayerName");
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //testVariable = PlayerPrefs.GetString("PlayerName");
        //if (PlayerPrefs.GetString("PlayerName") == null)
        //    GreetingsText.text = "����� ����������, ����� �����!";
        //else
        //{
        //    testVariable = PlayerPrefs.GetString("PlayerName");
        //    GreetingsText.text = "������� ����������, " + testVariable;
        //}
    }
}
