using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] woodTreePrefab;

    [SerializeField]
    private Transform woodTreeParent;

    [SerializeField]
    private ResourceSource[] resources;
<<<<<<<< Updated upstream:Assets/Scripts/Resource/ResourceManager.cs

========
    public ResourceSource[] Resources { get { return resources; } }
>>>>>>>> Stashed changes:Assets/Scripts/Resources/ResourceManager.cs
    public static ResourceManager instance;

    void Awake()
    {
        instance = this;
    }

<<<<<<<< Updated upstream:Assets/Scripts/Resource/ResourceManager.cs
========
    // Start is called before the first frame update
    void Start()
    {
        FindAllResource();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
>>>>>>>> Stashed changes:Assets/Scripts/Resources/ResourceManager.cs
    private void FindAllResource()
    {
        resources = FindObjectsOfType<ResourceSource>();
    }
<<<<<<<< Updated upstream:Assets/Scripts/Resource/ResourceManager.cs
    
    void Start()
    {
        FindAllResource();
    }

========
>>>>>>>> Stashed changes:Assets/Scripts/Resources/ResourceManager.cs

}
