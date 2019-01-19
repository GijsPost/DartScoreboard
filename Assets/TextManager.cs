
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    TranslationLoader loader;
    void Start()
    {
        this.loader = TranslationLoader.getInstance();
        this.loadTextFields();
    }

    // Main

    public Text TitleText;
    public Text NewGameButtonText;
    public Text SeePreviousMatchesButtonText;
    public Text ExitText;
    public Text CopyrightText;

    // New Game

    public Text P1PlaceholderText;
    public Text P2PlaceholderText;
    public Text P1NameTooLongText;
    public Text P2NameTooLongText;
    public Text BeginsTextP1;
    public Text BeginsTextP2;
    public Text StartingScoreText;
    public Text StartGameText;

    // Game

    public Text StartNewLegText;
    public Text ReturnToMainText;

    // Records
    public Text PreviousMatchesText;
    public Text ClearSaveFileText;

    // General

    public Text BackToMenuButtonText;

    public void loadTextFields()
    {
        string scene = SceneManager.GetActiveScene().name;
        TranslationObject translation = this.loader.getTranslation();

        if (scene == "Main")
        {
            this.TitleText.text = translation.scenes.Main.Title;
            this.NewGameButtonText.text = translation.scenes.Main.StartNewGame;
            this.SeePreviousMatchesButtonText.text = translation.scenes.Main.SeePreviousMatches;
            this.ExitText.text = translation.scenes.Main.Exit;
            this.CopyrightText.text = translation.scenes.Main.MadeBy + " " + TranslationLoader.Copyright;
        }
        if (scene == "newGameScene")
        {
            this.P1PlaceholderText.text = translation.scenes.newGameScene.EnterPlayerOneName;
            this.P2PlaceholderText.text = translation.scenes.newGameScene.EnterPlayerTwoName;
            this.P1NameTooLongText.text = translation.scenes.newGameScene.NameTooLong;
            this.P2NameTooLongText.text = translation.scenes.newGameScene.NameTooLong;
            this.BeginsTextP1.text = translation.scenes.newGameScene.Begins;
            this.BeginsTextP2.text = translation.scenes.newGameScene.Begins;
            this.StartingScoreText.text = translation.scenes.newGameScene.StartingScore + ":";
            this.StartGameText.text = translation.scenes.newGameScene.StartGame;
        }
        if (scene == "Game") {
            this.StartNewLegText.text = translation.scenes.Game.StartNewLeg;
            this.ReturnToMainText.text = translation.scenes.general.backToMenu;
        }
        if (scene == "Records") {
            this.PreviousMatchesText.text = translation.scenes.Records.PreviousMatches;
            this.ClearSaveFileText.text = translation.scenes.Records.ClearSaveFile;
        }
        // Re-used
        if (this.BackToMenuButtonText != null) {
            this.BackToMenuButtonText.text = translation.scenes.general.backToMenu;
        }
    }
}