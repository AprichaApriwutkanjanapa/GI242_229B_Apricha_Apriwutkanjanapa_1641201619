using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UnitSelect : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    [SerializeField]
    private Unit curUnit; //current selected single unit
    public Unit CurUnit { get { return curUnit; } }

    private Camera cam;
    private Fraction faction;

    public static UnitSelect instance;
    
    [SerializeField]
    private Building curBuilding; //current selected single building
    public Building CurBuilding { get { return curBuilding; } }


    void Awake()
    {
        faction = GetComponent<Fraction>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        layerMask = LayerMask.GetMask("Unit", "Building", "Resource", "Ground");

        instance = this;
    }

    private void SelectUnit(RaycastHit hit)  //Check if select unit is selected then toggle VFX
    {
        curUnit = hit.collider.GetComponent<Unit>();

        curUnit.ToggleSelectionVisual(true);

        //Debug.Log("Selected Unit");

        if (GameManager.instance.MyFaction.IsMyUnit(curUnit))
        {
            ShowUnit(curUnit);
            Debug.Log("ShowUnitonSelectUnit");
        }
    }
    
    private void BuildingSelect(RaycastHit hit)
    {
        curBuilding = hit.collider.GetComponent<Building>();
        curBuilding.ToggleSelectionVisual(true);

        if (GameManager.instance.MyFaction.IsMyBuilding(curBuilding))
        {
            //Debug.Log("my building");
            ShowBuilding(curBuilding);//Show building info
        }
    }


    private void TrySelect(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit hit;

        //if we left-click something
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            switch (hit.collider.tag)
            {
                case "Unit":
                    SelectUnit(hit);
                    break;
                case "Building":
                    BuildingSelect(hit);
                    break;
            }
        }
    }

    private void ClearAllSelectionVisual()  //Clear Flag under cur unit if cur unit is null
    {
        if (curUnit != null)
            curUnit.ToggleSelectionVisual(false);
        if (curBuilding != null)
            curBuilding.ToggleSelectionVisual(false);
    }

    private void ClearEverything()
    {
        ClearAllSelectionVisual();
        curUnit = null;
        curBuilding = null;
        
        //Clear UI
        InfoManager.instance.ClearAllInfo();
        ActionManager.instance.ClearAllInfo();
    }

    private void ShowUnit(Unit u)
    {
        InfoManager.instance.ShowAllInfo(u);
        
        if(u.IsBuilder)
            ActionManager.instance.ShowBuilderMode(u);
    }
    
    private void ShowBuilding(Building b)
    {
        InfoManager.instance.ShowAllInfo(b);
        ActionManager.instance.ShowCreateUnitMode(b);
    }

    // Update is called once per frame
    void Update()
    {
        //mouse down
        if (Input.GetMouseButtonDown(0))
        {
            //if click UI don't clear
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            
            ClearEverything();
        }

        // mouse up
        if (Input.GetMouseButtonUp(0))
        {
            TrySelect(Input.mousePosition);
        }
    }
}
