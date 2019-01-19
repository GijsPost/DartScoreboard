using System;

[Serializable]
public class General
{
    public string backToMenu;
}
[Serializable]
public class Main
{
    public string Title;
    public string StartNewGame;
    public string SeePreviousMatches;
    public string Exit;
    public string MadeBy;
}
[Serializable]
public class NewGameScene
{
    public string EnterPlayerOneName;
    public string EnterPlayerTwoName;
    public string NameTooLong;
    public string Begins;
    public string StartingScore;
    public string StartGame;
}
[Serializable]
public class Game
{
    public string Turn;
    public string EnterScore;
    public string Won;
    public string StartNewLeg;
}
[Serializable]
public class Records
{
    public string PreviousMatches;
    public string ClearSaveFile;
}
[Serializable]
public class Scenes
{
    public General general;
    public Main Main;
    public NewGameScene newGameScene;
    public Game Game;
    public Records Records;
}
[Serializable]
public class TranslationObject
{
    public string language;
    public Scenes scenes;
}