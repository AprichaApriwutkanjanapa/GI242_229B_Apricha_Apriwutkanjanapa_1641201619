using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/Script/TestScene.cs
    [SerializeField]
    private Unit[] units;


=======
    [SerializeField] private Unit[] units;
    
>>>>>>> Stashed changes:Assets/Scripts/TestScene.cs
    public void SetIdle()
    {
        for (int i = 0; i < units.Length; i++)
        {
            units[i].State = UnitState.Idle;
        }
    }

    public void SetMove()
    {
        for (int i = 0; i < units.Length; i++)
        {
            units[i].State = UnitState.Move;
        }
    }

    public void SetAttack()
    {
        for (int i = 0; i < units.Length; i++)
        {
<<<<<<< Updated upstream:Assets/Script/TestScene.cs
            units[i].State = UnitState.Attack;
=======
            units[i].State = UnitState.AttackUnit;
        }
    }
    public void SetChopping()
    {
        for (int i = 0; i < units.Length; i++)
        {
            units[i].State = UnitState.Gather;
        }
    }
    public void SetBuilding()
    {
        for (int i = 0; i < units.Length; i++)
        {
            units[i].State = UnitState.BuildProgress;
>>>>>>> Stashed changes:Assets/Scripts/TestScene.cs
        }
    }
    public void SetDie()
    {
        for (int i = 0; i < units.Length; i++)
        {
            units[i].State = UnitState.Die;
        }
    }
}
