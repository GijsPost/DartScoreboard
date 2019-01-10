using Assets;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecordsScript : MonoBehaviour {

    public Text RecordsText;

	// Use this for initialization
	void Start () {
        Saver sv = new Saver();
        List<Match> records = sv.load();

        for (int i = 0; i < records.Count; i++)
        {
            RecordsText.text = RecordsText.text + System.Environment.NewLine + records[i].toString();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void backToMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void clearSaveFile()
    {
        Saver sv = new Saver();
        sv.save(new List<Match>());

        SceneManager.LoadScene("Records");
    }
}
