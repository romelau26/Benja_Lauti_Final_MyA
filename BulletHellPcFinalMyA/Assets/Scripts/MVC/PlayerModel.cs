using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerModel : MonoBehaviour
{
    Vector3 _movedirection;
    IArtUpd _myController;
    public View _vista;
    private void Start()
    {
        _myController = new Control(this, _vista);
    }
    private void Update()
    {
        LimitsFronts();
        _myController.ArtificialUpdate();
    }
    //esto va en control
    public void LogicMovement(float hori,float verti)
    {
        _movedirection = new Vector3(hori, 0, verti);
        transform.position += _vista._movementSpeed * Time.deltaTime * _movedirection;
    }
    public void LimitsFronts()
    {
        transform.position = GameManager.Instance.transportPosition(transform.position);
    }

}
