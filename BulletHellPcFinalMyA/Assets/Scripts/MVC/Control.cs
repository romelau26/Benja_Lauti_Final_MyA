using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : IArtUpd
{
    PlayerModel pl;
    View vista;
    float _horizontalAxi, _verticalAxi;
    public Control(PlayerModel _pl,View _Vista)
    {
        pl = _pl;
        vista = _Vista;
    }
    public void ArtificialUpdate()
    {
        _horizontalAxi = Input.GetAxis("Horizontal");
        _verticalAxi = Input.GetAxis("Vertical");
        pl.LogicMovement(_horizontalAxi, _verticalAxi);
        vista.ScoreUI();
        vista.LifePlayerUI();
        pl.LogicMovement(_horizontalAxi, _verticalAxi);
        if (vista.CurrentHealth>=1)
        {
            vista.LifeTimeUI();
            if (Input.GetMouseButton(0))
            {
                if (vista.NormalShoot)
                {
                    vista.StartNormalShoot();
                }
                if (vista.TripleShoot)
                {
                    vista.StartTripleShoot();
                }
                if (vista.MultipleShoot)
                {
                    vista.StartMultipleShoot();
                }
            }
        }
        if(vista.CurrentHealth<=0)
        {
            vista.Dead();
        }
        if (vista.Shield)
        {
            vista.ActiveShield();
        }
        if (vista.TripleShoot)
        {
            vista.TimerTripleShoot();
        }
        if (vista.MultipleShoot)
        {
            vista.TimerMultiplehoot();
        }
        if (vista.DoblePoints)
        {
            vista.DoblePointsTime();
        }//hasta aca
    }

    public void OnFixedUpader()
    {
        
    }
}
