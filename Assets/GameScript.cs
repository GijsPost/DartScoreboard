using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

    public MainScript ms;

    public string P1NAME;
    public string P2NAME;

    public int P1score;
    public int P2score;

    public bool p1turn;
    public bool p1won;
    private int round;

    public Canvas WinGame;
    public Text P1NAMELABELWON;
    public Text P1LegsLabel;
    public Text P2LegsLabel;
    public Text P1NameLabel;
    public Text P2NameLabel;
    public Text P1CheckoutLabel;
    public Text P2CheckoutLabel;
    public Text TurnText;
    public Text P1ScoreField;
    public Text P2ScoreField;
    public InputField ScoreField;

	public Animator P1CheckoutLabelAnimator;
	public Animator P2CheckoutLabelAnimator;

    private TranslationObject translation;

    // Use this for initialization
    void Start () {

        translation = TranslationLoader.getInstance().getTranslation();

        P1NAME = PlayerPrefs.GetString("P1NAME");
        P2NAME = PlayerPrefs.GetString("P2NAME");

        P1NameLabel.text = P1NAME;
        P2NameLabel.text = P2NAME;
        P1score = Options.beginningPoints;
        P2score = Options.beginningPoints;

        P1ScoreField.text = P1score.ToString();
        P2ScoreField.text = P2score.ToString();

        distributeScores();
        round = 0;

        if (PlayerPrefs.GetInt("turn") == 1)
        {
            p1turn = true;
            TurnText.text = (P1NAME + this.translation.scenes.Game.Turn);
        }
        else
        {
            p1turn = false;
            TurnText.text = (P2NAME + this.translation.scenes.Game.Turn);
        }

    }

    private void distributeScores()
    {
        int p1legswon = PlayerPrefs.GetInt("p1legswon");
        int p2legswon = PlayerPrefs.GetInt("p2legswon");
        int p1setswon = PlayerPrefs.GetInt("p1setswon");
        int p2setswon = PlayerPrefs.GetInt("p2setswon");

        P1LegsLabel.text = p1legswon + " Legs, "+p1setswon+" Sets";

        P2LegsLabel.text = p2legswon + " Legs, " + p2setswon + " Sets";
    }

	// Update is called once per frame
	void Update() {

	}

    public void turn()
    {
        if (p1turn)
        {                                                         //PLAYER ONE TURN
            if (ScoreField.text != null)
            {
                int hit = 0;
                try
                {
                    hit = int.Parse(ScoreField.text);
                }
                catch
                {
                    return;
                }
                if (hit <= 180 && hit >= 0 && hit <= P1score)
                {
                    markRound();
                    P1score = P1score - hit;
                    if (P1score <= 0)
                    {
                        Debug.Log(P1NAME + " won the leg");
                        P1score = 0;
                        winLeg(true);

                        P1ScoreField.text = P1ScoreField.text + System.Environment.NewLine + "             " + hit + System.Environment.NewLine + P1score;
                        p1turn = false;

                        ScoreField.text = null;
                        TurnText.text = (P2NAME + this.translation.scenes.Game.Turn);
                        return;
                    }
					P1ScoreField.text = P1ScoreField.text + System.Environment.NewLine + "             " + hit + System.Environment.NewLine + P1score;
                    p1turn = false;

                    ScoreField.text = null;
                    TurnText.text = (P2NAME + this.translation.scenes.Game.Turn);

					if (findCheckout(P1score) != null)
					{
						P1CheckoutLabelAnimator.enabled = true;
					}
                    P1CheckoutLabel.text = findCheckout(P1score);
					ScoreField.ActivateInputField();
				}
                
            }
        }
        else
        {                                                         //PLAYER TWO TURN
            if (ScoreField.text != null)
            {
                int hit = 0;
                try
                {
                    hit = int.Parse(ScoreField.text);
                }
                catch
                {
                    return;
                }
                
                if (hit <= 180 && hit >= 0 && hit <= P2score)
                {
                    markRound();
                    P2score = P2score - hit;
                    if (P2score <= 0)
                    {
                        P2score = 0;
                        winLeg(false);

                        P1ScoreField.text = P2ScoreField.text + System.Environment.NewLine + "             " + hit + System.Environment.NewLine + P2score;
                        p1turn = true;

                        ScoreField.text = null;
						TurnText.text = (P1NAME + this.translation.scenes.Game.Turn);
                        return;
                    }
					P2ScoreField.text = P2ScoreField.text + System.Environment.NewLine + "             " + hit + System.Environment.NewLine + P2score;
                    p1turn = true;
                    ScoreField.text = null;
					TurnText.text = (P1NAME + this.translation.scenes.Game.Turn);

					if (findCheckout(P2score) != null)
					{
						P2CheckoutLabelAnimator.enabled = true;
					}
					P2CheckoutLabel.text = findCheckout(P2score);
					ScoreField.ActivateInputField();
				}               
            }
        }
    }

  

    private void markRound()
    {
        round++;
    }

    private void winLeg(bool p1won)
    {
        ScoreField.DeactivateInputField();
        WinGame.gameObject.SetActive(true);
        if (p1won)
        {
            P1NAMELABELWON.text = P1NAME + System.Environment.NewLine + this.translation.scenes.Game.Won + "!";
            this.p1won = true;
            if (PlayerPrefs.GetInt("p1legswon") > 1)
            {
                PlayerPrefs.SetInt("p1setswon", PlayerPrefs.GetInt("p1setswon")+1);
                PlayerPrefs.SetInt("p1legswon", 0);
            }
            else
            {
                PlayerPrefs.SetInt("p1legswon", PlayerPrefs.GetInt("p1legswon")+1);
            }
        }
        else
        {
            P1NAMELABELWON.text = P2NAME + System.Environment.NewLine + this.translation.scenes.Game.Won + "!";
            this.p1won = false;
            if (PlayerPrefs.GetInt("p2legswon") > 1)
            {
                PlayerPrefs.SetInt("p2setswon", (PlayerPrefs.GetInt("p2setswon") + 1));
                PlayerPrefs.SetInt("p2legswon", 0);
            }
            else
            {
                PlayerPrefs.SetInt("p2legswon", PlayerPrefs.GetInt("p2legswon")+1);
            }
            
        }

    }

    public void newLeg()
    {
        // Switch turns and restart
        PlayerPrefs.SetInt("turn", PlayerPrefs.GetInt("turn") == 1 ? 0 : 1);
        SceneManager.LoadScene("Game");
    }

    public void backToMenu()
    {
        Match match = new Match(P1NAME, P2NAME, PlayerPrefs.GetInt("p1legswon"), PlayerPrefs.GetInt("p1setswon"), PlayerPrefs.GetInt("p2legswon"), PlayerPrefs.GetInt("p2setswon"));
        List<Match> list = new List<Match>();
       
        Saver sv = new Saver();
        list = sv.load();
        list.Add(match);
        sv.save(list);

        SceneManager.LoadScene("Main");
    }

    public void OnApplicationQuit()
    {
        Match match = new Match(P1NAME, P2NAME, PlayerPrefs.GetInt("p1legswon"), PlayerPrefs.GetInt("p1setswon"), PlayerPrefs.GetInt("p2legswon"), PlayerPrefs.GetInt("p2setswon"));
        List<Match> list = new List<Match>();

        Saver sv = new Saver();
        list = sv.load();
        list.Add(match);
        sv.save(list);
    }

    private string findCheckout(int score)
    {
        // return CheckoutCalculator.Calculate(61);
        return CheckoutCalculator.Calculate(score);
    }
}
