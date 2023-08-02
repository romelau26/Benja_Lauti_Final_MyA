using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : IArtUpd
{
    PlayerModel pl;
    View vista;
    public Control(PlayerModel _pl,View _Vista)
    {
        pl = _pl;
        vista = _Vista;
    }
    public void ArtificialUpdate()
    {
        
    }

}
