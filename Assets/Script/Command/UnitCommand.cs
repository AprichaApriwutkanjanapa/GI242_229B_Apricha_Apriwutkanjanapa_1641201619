using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCommand : MonoBehaviour
{
    public LayerMask layerMask;
    private UnitSelect unitSelect;

    private Camera cam;

    private void Awake()
    {
        unitSelect = GetComponent<UnitSelect>();
    }

    private void Start()
    {
        cam = Camera.main;

        layerMask = LayerMask.GetMask("Unit", "Building", "Resource", "Ground");
    }

    private void UnitMoveToPosition(Vector3 dest, Unit unit)
    {
        if (unit != null)
        {
            unit.MovetoPosition(dest);
        }
    }

    private void CommandToGround(RaycastHit hit, Unit unit)
    {
        UnitMoveToPosition(hit.point, unit);
        CreateVFXMarker(hit.point, MainUI.instance.SelectionMarker);
    }

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
                    CommandToGround(hit, unitSelect.CurUnit);
                    break;
            }
        }
    }

    private void CreateVFXMarker(Vector3 pos, GameObject vfxPrefab)
    {
        if (vfxPrefab == null)
        {
           return; 
        }

        Instantiate(vfxPrefab, new Vector3(pos.x, 0.1f, pos.z), Quaternion.identity);
    }

    void Update()
    {
        //mouse up
        if (Input.GetMouseButtonUp(1))
        {
            TryCommand(Input.mousePosition);
        }
    }
}
