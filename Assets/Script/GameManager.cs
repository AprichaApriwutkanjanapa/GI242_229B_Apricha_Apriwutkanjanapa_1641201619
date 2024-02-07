using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Fraction myFaction;
    public Fraction MyFaction { get { return myFaction; } }

    [SerializeField] private Fraction enemyFaction;
    public Fraction EnemyFaction { get { return enemyFaction; } }

    //All factions in this game (2 factions for now)
    [SerializeField] private Fraction[] factions;

    public static GameManager instance;

    
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        MainUI.instance.UpdateAllResource(myFaction);
    }

}
