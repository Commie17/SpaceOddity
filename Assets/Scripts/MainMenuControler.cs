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
    public void PlayButtonPressed()// запук игры
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SetNameButtonPressed()//переход в меню установки нового имени
    {
        MainMenuha.SetActive(false);
        RenameMenu.SetActive(true);
    }
    public void SetNewNameButtonPressed()//дл€ установки нового имени
    {
        GreetingsText.text = "ƒобро пожаловать, "+TextFromInputField.text;
        PlayerPrefs.SetString("PlayerName", TextFromInputField.text);
        TextFromInputField.text = "";
        RenameMenu.SetActive(false);
        MainMenuha.SetActive(true);
    }
    public void BackRenMenuButtonPressed()//дл€ перехода из меню переименовани€ обратно в главное 
    {
        RenameMenu.SetActive(false);
        MainMenuha.SetActive(true);
    }
    public void ExitButtonPressed()//кнопка выхода
    {
        Application.Quit();
    }
    public void Awake()
    {
        if (PlayerPrefs.GetString("PlayerName") == null)
            GreetingsText.text = "ƒобро пожаловать, новый игрок!";
        else
        {
            testVariable = PlayerPrefs.GetString("PlayerName");
            GreetingsText.text = "ƒобро пожаловать, "+PlayerPrefs.GetString("PlayerName");
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
        //    GreetingsText.text = "ƒобро пожаловать, новый игрок!";
        //else
        //{
        //    testVariable = PlayerPrefs.GetString("PlayerName");
        //    GreetingsText.text = "ƒобрыть пожаловать, " + testVariable;
        //}
    }
}
