<<<<<<< Updated upstream:Assets/Script/Command/UnitSelect.cs
=======
using System.Collections;
using System.Collections.Generic;
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitSelect.cs
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSelect : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/Script/Command/UnitSelect.cs
    [SerializeField] private LayerMask layerMask;

    [SerializeField]
    private Unit curUnit; //current selected single unit
    public Unit CurUnit { get { return curUnit; } }

    private Camera cam;
    private Faction faction;

    public static UnitSelect instance;

    [SerializeField] private Building curBuilding; //current selected single building
    public Building CurBuilding
    {
        get { return curBuilding; }
    }
=======
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private List<Unit> curUnits = new List<Unit>(); //current selected single unit
    public List<Unit> CurUnits { get { return curUnits; } }
    
    [SerializeField]
    private Building curBuilding; //current selected single building
    public Building CurBuilding { get { return curBuilding; } }

    private Camera cam;
    private Faction faction;

    public static UnitSelect instance;
    
    [SerializeField]
    private ResourceSource curResource; //current selected resource
    
    [SerializeField]
    private RectTransform selectionBox;
    private Vector2 oldAnchoredPos;//Box old anchored position
    private Vector2 startPos;//point where mouse is down

    private float timer = 0f;
    private float timeLimit = 0.5f;
    
    [SerializeField]
    private Unit curEnemy;
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitSelect.cs

    void Awake()
    {
        faction = GetComponent<Faction>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        layerMask = LayerMask.GetMask("Unit", "Building", "Resource", "Ground");

<<<<<<< Updated upstream:Assets/Script/Command/UnitSelect.cs
=======
        selectionBox = MainUi.instance.SelectionBox;

>>>>>>> Stashed changes:Assets/Scripts/Command/UnitSelect.cs
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //mouse down
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            
            ClearEverything();
        }
        
        //mouse held down
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Mouse held down");
            UpdateSelectionBox(Input.mousePosition);
        }
        //mouse up
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseSelectionBox(Input.mousePosition);
            
            if (IsPointerOverUIObject())
                return;
            
            TrySelect(Input.mousePosition);
        }

        timer += Time.deltaTime;
        if (timer >= timeLimit)
        {
            timer = 0f;
            UpdateUI();
        }
    }
    
    private void SelectUnit(RaycastHit hit)
    {
<<<<<<< Updated upstream:Assets/Script/Command/UnitSelect.cs
        curUnit = hit.collider.GetComponent<Unit>();

        curUnit.ToggleSelectionVisual(true);
=======
        Unit unit = hit.collider.GetComponent<Unit>();

        Debug.Log("Selected Unit");
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitSelect.cs

        Debug.Log("Selected Unit");

        if (GameManager.instance.MyFaction.IsMyUnit(curUnit))
        {
            ShowUnit(curUnit);
        }
    }
<<<<<<< Updated upstream:Assets/Script/Command/UnitSelect.cs

=======
    
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitSelect.cs
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
    private void ClearAllSelectionVisual()
    {
<<<<<<< Updated upstream:Assets/Script/Command/UnitSelect.cs
        if (curUnit != null)
            curUnit.ToggleSelectionVisual(false);
=======
        foreach (Unit u in curUnits)
        {
            u.ToggleSelectionVisual(false);
        }
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitSelect.cs
        if (curBuilding != null)
            curBuilding.ToggleSelectionVisual(false);
    }
<<<<<<< Updated upstream:Assets/Script/Command/UnitSelect.cs

    private void ClearEverything() //clear everything UI screen. Unselect if press on cancel
=======
    private void ClearEverything()
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitSelect.cs
    {
        ClearAllSelectionVisual();
        curUnit = null;
        curBuilding = null;
        curResource = null;
        curEnemy = null;
        
        //Clear UI
        InfoManager.instance.ClearAllInfo();
    }
<<<<<<< Updated upstream:Assets/Script/Command/UnitSelect.cs

    // Update is called once per frame
    void Update()
    {
        //mouse down
        if (Input.GetMouseButtonDown(0))
        {
            //if click UI, don't clear
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
    
    private void ShowUnit(Unit u)
=======
    private void ShowUnit(Unit u)
    {
        InfoManager.instance.ShowAllInfo(u);
        if (u.IsBuilder)
        {
            ActionManager.instance.ShowBuilderMode(u);
        }
    }
    private void ShowBuilding(Building b)
    {
        InfoManager.instance.ShowAllInfo(b);
        ActionManager.instance.ShowCreateUnitMode(b);
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
        else
        {
            ShowEnemyBuilding(curBuilding);
        }
    }
    private void ShowResource()
    {
        InfoManager.instance.ShowAllInfo(curResource);//Show resource info in Info Panel

    }
    private void ResourceSelect(RaycastHit hit)
    {
        curResource = hit.collider.GetComponent<ResourceSource>();
        if (curResource == null)
            return;

        curResource.ToggleSelectionVisual(true);
        ShowResource();//Show resource info
    }
    private void UpdateSelectionBox(Vector3 mousePos)
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitSelect.cs
    {
        InfoManager.instance.ShowAllInfo(u);

        if (u.IsBuilder)
        {
            ActionManager.instance.ShowBuilderMode(u);
        }
    }
<<<<<<< Updated upstream:Assets/Script/Command/UnitSelect.cs

    private void ShowBuilding(Building b)
=======
    private void ReleaseSelectionBox(Vector2 mousePos)
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitSelect.cs
    {
        InfoManager.instance.ShowAllInfo(b);
        ActionManager.instance.ShowCreateUnitMode(b);
    }

    private void BuildingSelect(RaycastHit hit)
    {
        curBuilding = hit.collider.GetComponent<Building>();
        curBuilding.ToggleSelectionVisual(true);

        if (GameManager.instance.MyFaction.IsMyBuilding(curBuilding))
        {
            //Debug.Log("my building");
            ShowBuilding(curBuilding);
        }
<<<<<<< Updated upstream:Assets/Script/Command/UnitSelect.cs
    }

   

=======
        selectionBox.sizeDelta = new Vector2(0, 0); //clear Selection Box's size;
    }
    private void ShowEnemyUnit(Unit u)
    {
        InfoManager.instance.ShowEnemyAllInfo(u);
    }
    private void ShowEnemyBuilding(Building b)
    {
        InfoManager.instance.ShowEnemyAllInfo(b);
    }
    private void UpdateUI()
    {
        if (curUnits.Count == 1)
            ShowUnit(curUnits[0]);
        else if (curEnemy != null)
            ShowEnemyUnit(curEnemy);
        else if (curResource != null)
            ShowResource();
        else if (curBuilding != null)
        {
            if (GameManager.instance.MyFaction.IsMyBuilding(curBuilding))
                ShowBuilding(curBuilding);//Show building info
            else
                ShowEnemyBuilding(curBuilding);
        }
    }
    //When Touching UI
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitSelect.cs
}
