using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera camController;

    public Camera CamController { get { return camController; } }

    [Header("Move")] [SerializeField] private float moveSpeed;
    [SerializeField] private float xInput; //Horizontal keyboard Input
    [SerializeField] private float zInput; //Vertically keyboard Input

    [SerializeField] private Transform corner1;
    [SerializeField] private Transform corner2;

    public static CameraController instance;
    
    [Header("Zoom")]
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float zoomModifier;

    [SerializeField] private float minZoomDist;
    [SerializeField] private float maxZoomDist;

    [SerializeField] private float dist; //between camera base and camera

    [Header("Rotate")] 
    [SerializeField] private float rotationAmount;
    [SerializeField] private Quaternion newRotation;


    private void Awake()
    {
        instance = this;
        camController = Camera.main;

        newRotation = transform.rotation;
        rotationAmount = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 50;

        zoomSpeed = 25;
        minZoomDist = 15;
        maxZoomDist = 50;
    }

    // Update is called once per frame
    void Update()
    {
        MoveByKeyboard();
        Zoom();
        Rotate();
    }

    private void MoveByKeyboard()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        Vector3 dir = (transform.forward * zInput) + (transform.right * xInput);

        transform.position += dir * moveSpeed * Time.deltaTime;
        transform.position = Clamp(corner1.position, corner2.position);
    }

    private Vector3 Clamp(Vector3 lowerLeft, Vector3 Topright)
    {
        Vector3 pos = new Vector3(Mathf.Clamp(transform.position.x, lowerLeft.x, Topright.x)
        ,transform.position.y, Mathf.Clamp(transform.position.z, lowerLeft.z, Topright.z));

        return pos;
    }
    
    private void Zoom()
    {
        zoomModifier = Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetKey(KeyCode.Z))
            zoomModifier = 0.01f;
        if (Input.GetKey(KeyCode.X))
            zoomModifier = -0.01f;

        dist = Vector3.Distance(transform.position, CamController.transform.position);

        if (dist < minZoomDist && zoomModifier > 0f)
            return; //too close
        else if (dist > maxZoomDist && zoomModifier < 0f)
            return; //too far

        CamController.transform.position += CamController.transform.forward * zoomModifier * zoomSpeed;
    }
    void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);

        if (Input.GetKey(KeyCode.E))
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * moveSpeed);
    }


}
