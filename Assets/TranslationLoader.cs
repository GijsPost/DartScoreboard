using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class TranslationLoader
{
    public static string Copyright = "Gijs Post © 2018";
    public static string translationsPath = "translations";
    private static SystemLanguage DefaultLanguage = SystemLanguage.English;
    private static Dictionary<SystemLanguage, string> supportedLanguages = new Dictionary<SystemLanguage, string>();
    private TranslationObject translation;

    static TranslationLoader instance;
    public static TranslationLoader getInstance()
    {
        if (instance != null)
        {
            return instance;
        }
        instance = new TranslationLoader();
        return instance;
    }

    public TranslationLoader()
    {
        if (supportedLanguages.Count <= 0)
        {
            supportedLanguages.Add(SystemLanguage.English, "english.json");
            supportedLanguages.Add(SystemLanguage.Dutch, "dutch.json");
        }

        if (supportedLanguages.ContainsKey(Application.systemLanguage))
        {
            this.translation = this.getTranslationObjectFromFile(supportedLanguages[Application.systemLanguage]);
        }
        else
        {
            this.translation = this.getTranslationObjectFromFile(supportedLanguages[TranslationLoader.DefaultLanguage]);
        }

        Debug.Log("Loading translation for: " + this.translation.language);
    }

    private TranslationObject getTranslationObjectFromFile(string file)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, file);

        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }
            return JsonUtility.FromJson<TranslationObject>(reader.text);
        }
        else
        {
            return JsonUtility.FromJson<TranslationObject>(File.ReadAllText(filePath));
        }
    }

    public TranslationObject getTranslation()
    {
        return this.translation;
    }
}
