using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class View : BasicStats
{
    [SerializeField] GameObject DeadImage;
    [SerializeField] GameObject ShieldUI;
    [SerializeField] GameObject TripleShootUI;
    [SerializeField] GameObject MultipleShootUI;
    [SerializeField] GameObject DoblePointsUI;
    [SerializeField] TMP_Text LifeTimerText;
    [SerializeField] TMP_Text _ScoreUI;
    private int Minutes, Seconds, Cents;
    public Image[] ships;
    public Sprite FullLife;
    public Sprite VoidLife;
    float _LifeTime;
    public static int ScoreAmount;
    public int MinGetLife;//le puse una cantidad minima para que consigas una vida mas
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LifePlayerUI()
    {
        foreach (Image imag in ships)
        {
            imag.sprite = VoidLife;
        }
        for (int i = 0; i < CurrentHealth; i++)
        {
            ships[i].sprite = FullLife;
        }
    }
    public void LifeTimeUI()
    {
        _LifeTime += Time.deltaTime;
        Minutes = (int)(_LifeTime / 60f);
        Seconds = (int)(_LifeTime - Minutes * 60f);
        Cents = (int)((_LifeTime - (int)_LifeTime) * 100);
        LifeTimerText.text = string.Format("{0:00}:{1:00}:{2:00}", Minutes, Seconds, Cents);
    }
    public void ScoreUI()
    {
        _ScoreUI.text = "" + ScoreAmount.ToString("0");
        if (CurrentHealth < MaxHealth && ScoreAmount >= MinGetLife)
        {
            ScoreAmount -= MinGetLife;
            CurrentHealth += 1;
        }
    }
}
