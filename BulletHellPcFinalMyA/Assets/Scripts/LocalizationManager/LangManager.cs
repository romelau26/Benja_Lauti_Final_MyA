using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public enum Languages
{
    eng,
    spa
}

public class LangManager : MonoBehaviour
{
    [SerializeField] Languages _selectedLanguage;
    [SerializeField] string _externalURL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTKu2VNrqS-qn6rF7kui14H6SpshNrjWyHBgK-UpO9dSZsdXiyQm9q7SLABNbd8nksBDDTN_gMmnbdK/pub?output=csv";

    Dictionary<Languages, Dictionary<string, string>> _languageManager;

    public event Action onUpdate = delegate { };

    private void Start()
    {
        StartCoroutine(DownloadCSV(_externalURL));
    }

    public string GetTranslate(string id)
    {
        if (_languageManager == null) return "";
        if (!_languageManager[_selectedLanguage].ContainsKey(id)) return "Error 404, not found";
        else return _languageManager[_selectedLanguage][id];
    }

    IEnumerator DownloadCSV(string url)
    {
        var www = new UnityWebRequest(url);
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        _languageManager = LanguageSplit.LoadCodeFromString("www", www.downloadHandler.text);
        
        onUpdate();
    }

    public void ChangeToEng()
    {
        _selectedLanguage = Languages.eng;
        onUpdate();
    }

    public void ChangeToSpa()
    {
        _selectedLanguage = Languages.spa;
        onUpdate();
    }
}
