using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    
    private Animator anim;
    private Unit unit;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        unit = GetComponent<Unit>();
    }

    private void ChooseAnimation(Unit u)
    {
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsMove", false);
        anim.SetBool("IsAttack", false);
        anim.SetBool("IsBuilding", false);
        anim.SetBool("IsMoveToPrecess", false);

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
            
            case UnitState.MoveToBuild:
                anim.SetBool("IsMoveToProcess", true);
                break;
            
            case UnitState.BuildProgress:
                anim.SetBool("IsBuilding", true);
                break;
        }
    }



    // Update is called once per frame
    
    void Update()
    {
        ChooseAnimation(unit);
    }


}
