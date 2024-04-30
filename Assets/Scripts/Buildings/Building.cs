<<<<<<< Updated upstream:Assets/Script/Buildings/Building.cs
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
=======
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
>>>>>>> Stashed changes:Assets/Scripts/Buildings/Building.cs
using UnityEngine;

public class Building : Structure
{
    [SerializeField] private Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } }
    [SerializeField] private Transform rallyPoint;
    public Transform RallyPoint { get { return rallyPoint; } }
<<<<<<< Updated upstream:Assets/Script/Buildings/Building.cs
    
    [SerializeField] private GameObject[] unitPrefabs;
    public GameObject[] UnitPrefabs { get { return unitPrefabs; } }
    
    
=======

    [SerializeField] private GameObject[] unitPrefabs;
    public GameObject[] UnitPrefabs
    {
        get { return unitPrefabs; }
    }

>>>>>>> Stashed changes:Assets/Scripts/Buildings/Building.cs
    [SerializeField] private List<Unit> recruitList = new List<Unit>();

    [SerializeField] private float unitTimer = 0f;
    [SerializeField] private int curUnitProgress = 0;

    [SerializeField] private float curUnitWaitTime = 0f;

    [SerializeField] private bool isFunctional;
    public bool InFunctional {get{ return isFunctional; } set { isFunctional = value; } }

    [SerializeField] private bool isHQ;
    public bool IsHQ { get { return isHQ; } }
<<<<<<< Updated upstream:Assets/Script/Buildings/Building.cs
    
    //How deep into the ground the building is at the construction site
=======
    [SerializeField] private bool isHousing;
    public bool IsHousing { get { return isHousing; } }
    [SerializeField] private bool isBarrack;
    public bool IsBarrack { get { return isBarrack; } }

>>>>>>> Stashed changes:Assets/Scripts/Buildings/Building.cs
    [SerializeField] private float intoTheGround = 5f;
    public float IntoTheGround { get { return intoTheGround; } }
    
    private float timer = 0f; //Constructing timer
    public float Timer { get { return timer; } set { timer = value; } }
    private float waitTime = 0.5f; //How fast it will be construct, higher is longer
    public float WaitTime { get { return waitTime; } set { waitTime = value; } }

<<<<<<< Updated upstream:Assets/Script/Buildings/Building.cs


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToCreateUnit(int i)
    {
        Debug.Log(structureName + " creates " + i + ":" + unitPrefabs.Length);
        if (unitPrefabs.Length == 0)
            return;

        if (unitPrefabs[i] == null)
            return;

        Unit unit = unitPrefabs[i].GetComponent<Unit>();

        if (unit == null)
            return;

        if (!faction.CheckUnitCost(unit)) //not enough resources
            return;

        //Deduct Resource
        faction.DeductUnitCost(unit);

        //If it's me, update UI
        if (faction == GameManager.instance.MyFaction)
            MainUI.instance.UpdateAllResource(faction);

        //Add unit into faction's recruit list
        recruitList.Add(unit);

        Debug.Log("Adding" + i + "to Recruit List");
    }

    public void CreateUnitCompleted()
    {
        int id = recruitList[0].ID;

        if (unitPrefabs[id] == null)
            return;

        GameObject unitObj = Instantiate(unitPrefabs[id], spawnPoint.position, Quaternion.Euler(0f, 180f, 0f));

        recruitList.RemoveAt(0);

        Unit unit = unitObj.GetComponent<Unit>();
        unit.Faction = faction;
        unit.MoveToPosition(rallyPoint.position); //Go to Rally Point

        //Add unit into faction's Army
        faction.AliveUnits.Add(unit);

        Debug.Log("Unit Recruited");
        //If it's me, update UI
        if (faction == GameManager.instance.MyFaction)
            MainUI.instance.UpdateAllResource(faction);
    }

    public void ToggleSelectionVisual(bool flag)
    {
        if (SelectionVisual != null)
            SelectionVisual.SetActive(flag);
    }
    

=======
>>>>>>> Stashed changes:Assets/Scripts/Buildings/Building.cs
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            ToCreateUnit(0);

        if ((recruitList.Count > 0) && (recruitList[0] != null))
        {
            unitTimer += Time.deltaTime;
            curUnitWaitTime = recruitList[0].UnitWaitTime;

            if (unitTimer >= curUnitWaitTime)
            {
                curUnitProgress++;
                unitTimer = 0f;

                if (curUnitProgress >= 100 && (faction.AliveUnits.Count < faction.UnitLimit))
                {
                    curUnitProgress = 0;
                    curUnitWaitTime = 0f;
                    CreateUnitCompleted();
                }
            }
        }
    }
<<<<<<< Updated upstream:Assets/Script/Buildings/Building.cs

=======
    public void ToCreateUnit(int i)
    {
        Debug.Log(structureName + " creates " + i + ":" + unitPrefabs.Length);
        if (unitPrefabs.Length == 0)
            return;

        if (unitPrefabs[i] == null)
            return;

        Unit unit = unitPrefabs[i].GetComponent<Unit>();

        if (unit == null) 
            return;

        if (!faction.CheckUnitCost(unit)) //not enough resources
            return;

        //Deduct Resource
        faction.DeductUnitCost(unit);

        //If it's me, update UI
        if (faction == GameManager.instance.MyFaction)
            MainUi.instance.UpdateAllResource(faction);

        //Add unit into faction's recruit list
        recruitList.Add(unit);

        Debug.Log("Adding" + i + "to Recruit List");
    }
    public void CreateUnitCompleted()
    {
        int id = recruitList[0].ID;

        if (faction.UnitPrefabs[id] == null)
            return;

        GameObject unitObj = Instantiate(faction.UnitPrefabs[id], spawnPoint.position, Quaternion.Euler(0f, 180f, 0f),faction.UnitsParent);

        recruitList.RemoveAt(0);

        Unit unit = unitObj.GetComponent<Unit>();
        unit.Faction = faction;
        unit.MoveToPosition(rallyPoint.position); //Go to Rally Point

        //Add unit into faction's Army
        faction.AliveUnits.Add(unit);

        Debug.Log("Unit Recruited");
        //If it's me, update UI
        if (faction == GameManager.instance.MyFaction)
            MainUi.instance.UpdateAllResource(faction);
        
    }
    public void ToggleSelectionVisual(bool flag)
    {
        if (SelectionVisual != null)
            SelectionVisual.SetActive(flag);
    }
    public int CheckNumInRecruitList(int id)
    {
        int num = 0;

        foreach (Unit u in recruitList)
        {
            if (id == u.ID)
                num++;
        }
        return num;
    }
    protected override void Die()
    {
        if (faction != null)
            faction.AliveBuildings.Remove(this);

        if (IsHousing)
            faction.UpdateHousingLimit();

        base.Die();

        //Check Victory Condition
    }
>>>>>>> Stashed changes:Assets/Scripts/Buildings/Building.cs
}
