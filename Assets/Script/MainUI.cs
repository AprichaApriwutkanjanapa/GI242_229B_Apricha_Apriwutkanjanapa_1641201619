using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private GameObject selectionMarker;
    public GameObject SelectionMarker { get { return selectionMarker; } }

    public static MainUI instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
