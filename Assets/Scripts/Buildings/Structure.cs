<<<<<<< Updated upstream:Assets/Script/Buildings/Structure.cs
using System;
=======
>>>>>>> Stashed changes:Assets/Scripts/Buildings/Structure.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream:Assets/Script/Buildings/Structure.cs
[System.Serializable] public struct StructureCost
=======
[System.Serializable]
public struct StructureCost
>>>>>>> Stashed changes:Assets/Scripts/Buildings/Structure.cs
{
    public int food;
    public int wood;
    public int gold;
    public int stone;
}

public abstract class Structure : MonoBehaviour
{
    [SerializeField]
    protected string structureName;
    public string StructureName { get { return structureName; } }
    
    [SerializeField] protected Sprite structurePic;
    public Sprite StructurePic { get { return structurePic; } }
    
    [SerializeField]
    protected int curHP;
    public int CurHP { get { return curHP; } set { curHP = value; } }
    
    [SerializeField]
    protected int maxHP;
    public int MaxHP { get { return maxHP; } set {  maxHP = value; } }
<<<<<<< Updated upstream:Assets/Script/Buildings/Structure.cs

    [SerializeField]
    protected Faction faction; 
    public Faction Faction { get { return faction; } set { faction = value; } }


=======
    
    [SerializeField]
    protected Faction faction;
    public Faction Faction { get { return faction; } set { faction = value; } }
    
>>>>>>> Stashed changes:Assets/Scripts/Buildings/Structure.cs
    [SerializeField]
    protected GameObject selectionVisual;
    public GameObject SelectionVisual { get { return selectionVisual; } }
    
    [SerializeField] 
    private StructureCost structureCost;
    public StructureCost StructureCost { get { return structureCost; } set { structureCost = value; } }

<<<<<<< Updated upstream:Assets/Script/Buildings/Structure.cs
    [SerializeField] 
    private StructureCost structureCost; 
    public StructureCost StructureCost { get { return structureCost; } set { structureCost = value; } }
}
=======
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void Die()
    {
        InfoManager.instance.ClearAllInfo();
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if (curHP <= 0)
            Die();
    }
}
>>>>>>> Stashed changes:Assets/Scripts/Buildings/Structure.cs
