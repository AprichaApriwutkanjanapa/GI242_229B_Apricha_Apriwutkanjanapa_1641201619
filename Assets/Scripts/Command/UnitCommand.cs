using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCommand : MonoBehaviour
{
    public LayerMask layerMask;
    private UnitSelect unitSelect;

    private Camera cam;
    
    void Awake()
    {
        unitSelect = GetComponent<UnitSelect>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("No camera found in the scene.");
            return;
        }

        layerMask = LayerMask.GetMask("Unit", "Building", "Resource", "Ground");
    }

<<<<<<< Updated upstream:Assets/Script/Command/UnitCommand.cs
    private void UnitMoveToPosition(Vector3 dest, Unit unit)
=======
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            TryCommand(Input.mousePosition);
        }
    }
    private void UnitsMoveToPosition(Vector3 dest, List<Unit> units)
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitCommand.cs
    {
        if (unit != null)
        {
            unit.MoveToPosition(dest);
        }
    }
<<<<<<< Updated upstream:Assets/Script/Command/UnitCommand.cs

    private void CommandToGround(RaycastHit hit, Unit unit)
    {
        UnitMoveToPosition(hit.point, unit);
        CreateVFXMarker(hit.point, MainUI.instance.SelectionMarker);
    }

=======
    private void CommandToGround(RaycastHit hit, List<Unit> units)
    {
        UnitsMoveToPosition(hit.point, units);
        CreateVFXMarker(hit.point, MainUi.instance.SelectionMarker);
    }
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitCommand.cs
    private void TryCommand(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit hit;

        //if we left-click something
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            switch (hit.collider.tag)
            {
                case "Ground":
<<<<<<< Updated upstream:Assets/Script/Command/UnitCommand.cs
                    CommandToGround(hit, unitSelect.CurUnit);
=======
                    CommandToGround(hit, unitSelect.CurUnits);
                    break;
                case "Resource":
                    ResourceCommand(hit, unitSelect.CurUnits);
                    break;
                case "Unit":
                    CommandToUnit(hit,unitSelect.CurUnits);
                    break;
                case "Building":
                    BuildingCommand(hit,unitSelect.CurUnits);
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitCommand.cs
                    break;
            }
        }
    }
    private void CreateVFXMarker(Vector3 pos, GameObject vfxPrefab)
    {
        if (vfxPrefab ==  null)
            return;

        Instantiate(vfxPrefab, new Vector3(pos.x, 0.1f, pos.z), Quaternion.identity);
    }
    // called when we command units to gather a resource
    private void UnitsToGatherResource(ResourceSource resource, List<Unit> units)
    {
        foreach (Unit u in units)
        {
            if (u.IsWorker)
                u.Worker.ToGatherResource(resource, resource.transform.position);
            else
                u.MoveToPosition(resource.transform.position);
        }
    }
<<<<<<< Updated upstream:Assets/Script/Command/UnitCommand.cs
=======
    private void ResourceCommand(RaycastHit hit, List<Unit> units)
    {
        UnitsToGatherResource(hit.collider.GetComponent<ResourceSource>(), units);
        CreateVFXMarker(hit.transform.position, MainUi.instance.SelectionMarker);
    }
    private void UnitAttackEnemy(Unit enemy, List<Unit> units)
    {
        foreach (Unit u in units)
        {
            u.ToAttackUnit(enemy);
        }
    }
    private void CommandToUnit(RaycastHit hit, List<Unit> units)
    {
        Unit target = hit.collider.gameObject.GetComponent<Unit>();

        if (target == null)
            return;

        if (target.Faction == GameManager.instance.EnemyFaction)// if it is our enemy
            UnitAttackEnemy(target, units);
    }
    private void UnitAttackEnemyBuilding(Building enemyBuilding, List<Unit> units)
    {
        foreach (Unit u in units)
        {
            u.ToAttackBuilding(enemyBuilding);
        }
    }
    private void BuildingCommand(RaycastHit hit, List<Unit> units)
    {
        Building building = hit.collider.gameObject.GetComponent<Building>();

        if (building == null)
            return;

        // if it is an enemy's building
        if (building.Faction == GameManager.instance.EnemyFaction)
            UnitAttackEnemyBuilding(building, units);
        else // it is my building
        {
            if (building.CurHP < building.MaxHP)
            {
                HelpFixBuilding(hit.collider.gameObject,units);
                StartCoroutine(Formula.BlinkSelection(building.SelectionVisual));
            }
        }
    }
    private void HelpFixBuilding(GameObject target, List<Unit> units)
    {
        foreach (Unit u in units)
        {
            if (u.IsBuilder)
                u.Builder.BuilderStartFixBuilding(target);
        }
    }
>>>>>>> Stashed changes:Assets/Scripts/Command/UnitCommand.cs
}
