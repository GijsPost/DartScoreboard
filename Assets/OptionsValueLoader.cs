using UnityEngine;
using UnityEngine.UI;

public class OptionsValueLoader: MonoBehaviour {
    
    public InputField StartingValueOptionField;

    void Start() {
        StartingValueOptionField.text = Options.beginningPoints.ToString();
    }
}