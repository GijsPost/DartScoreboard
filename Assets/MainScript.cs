using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript : MonoBehaviour {

    public Scene Game;

    public static string P1NAME;
    public static string P2NAME;

    public InputField player_one_name_field;
    public InputField player_two_name_field;

	public Text P1NameTooLong;
	public Text P2NameTooLong;

    public Toggle ToggleP1;
    public Toggle ToggleP2;
	public InputField StartingValueOptionField;

    // Use this for initialization
    void Start() {
    }

    public void newGame()
    {
        SceneManager.LoadScene("newGameScene");
		Debug.Log("AAAAAAA");
    }

    public void beginGame()
    {
		if (player_one_name_field.text.Length >= 1 && player_one_name_field.text.Length <= 10 && player_two_name_field.text.Length >= 1 && player_two_name_field.text.Length <= 10)
		{
			P1NAME = player_one_name_field.text;
			P2NAME = player_two_name_field.text;

			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetString("P1NAME", P1NAME);
			PlayerPrefs.SetString("P2NAME", P2NAME);

			if (ToggleP1.isOn)
			{
				PlayerPrefs.SetInt("turn", 1);
			}
			else
			{
				PlayerPrefs.SetInt("turn", 2);
			}

			int beginningValueInput = int.Parse(StartingValueOptionField.text);
			if (beginningValueInput <= 0) {
				return;
			}
			Options.beginningPoints = beginningValueInput;
			SceneManager.LoadScene("Game");

		}
	}

	public void NameVerify(int player)
	{
		if (player == 1)
		{
			if (player_one_name_field.text.Length > 10)
			{
				P1NameTooLong.enabled = true;
			}
			else
			{
				P1NameTooLong.enabled = false;
			}
		}
		else
		{
			if (player_two_name_field.text.Length > 10)
			{
				P2NameTooLong.enabled = true;
			}
			else
			{
				P2NameTooLong.enabled = false;
			}
		}
	}

    // Update is called once per frame
    void Update() {

    }

    public void exitApp()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void seeRecords()
    {
        SceneManager.LoadScene("Records");
    }
}
