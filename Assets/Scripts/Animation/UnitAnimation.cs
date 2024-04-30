using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    private Animator anim;
    private Unit unit;
    
    //Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        unit = GetComponent<Unit>();
    }

<<<<<<< Updated upstream:Assets/Script/Units/Unit Animation.cs
    private void ChooseAnimation(Unit u)
    {
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsMove", false);
        anim.SetBool("IsAttack", false);

        switch (u.State)
        {
            case UnitState.Idle:
                anim.SetBool("IsIdle", true);
                break;
            case UnitState.Move:
                anim.SetBool("IsMove", true);
                break;
            case UnitState.Attack:
                anim.SetBool("IsAttack", true);
                break;
        }
    }



    //Update is called once per frame
    
=======
    // Update is called once per frame
>>>>>>> Stashed changes:Assets/Scripts/Animation/UnitAnimation.cs
    void Update()
    {
        ChooseAnimation(unit);
    }

    private void ChooseAnimation(Unit u)
    {
        anim.SetBool("isIdle", false);
        anim.SetBool("isMove", false);
        anim.SetBool("isAttack", false);
        anim.SetBool("isChopping", false);
        anim.SetBool("isBuilding", false);
        anim.SetBool("isDie", false);

        switch (u.State)
        {
            case UnitState.Idle:
                anim.SetBool("isIdle", true);
                break;
            case UnitState.Move:
                anim.SetBool("isMove", true);
                break;
            case UnitState.AttackUnit:
                anim.SetBool("isAttack", true);
                break;
            case UnitState.Gather:
                anim.SetBool("isChopping", true);
                break;
            case UnitState.BuildProgress:
                anim.SetBool("isBuilding", true);
                break;
            case UnitState.Die:
                anim.SetBool("isDie", true);
                break;
            case UnitState.DeliverToHQ:
                anim.SetBool("isMove", true);
                break;
            case UnitState.MoveToResource:
                anim.SetBool("isMove", true);
                break;
            case UnitState.StoreAtHQ:
                anim.SetBool("isMove", true);
                break;
            case UnitState.MoveToEnemy:
                anim.SetBool("isMove", true);
                break;
            case UnitState.MoveToBuild:
                anim.SetBool("isMove", true);
                break;
            case UnitState.MoveToEnemyBuilding:
                anim.SetBool("isMove", true);
                break;
            case UnitState.AttackBuilding:
                anim.SetBool("isAttack", true);
                break;
        }
    }
}
