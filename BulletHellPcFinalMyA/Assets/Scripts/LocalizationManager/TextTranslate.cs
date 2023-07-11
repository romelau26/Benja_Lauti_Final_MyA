using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTranslate : MonoBehaviour
{
    [SerializeField] string _ID;
    [SerializeField] LangManager _langManager;
    [SerializeField] Text _myView;

    private void Awake()
    {
        _langManager.onUpdate += ChangeLanguage;
    }

    private void OnEnable()
    {
        ChangeLanguage();
    }

    void ChangeLanguage()
    {
        _myView.text = _langManager.GetTranslate(_ID);
    }
}
