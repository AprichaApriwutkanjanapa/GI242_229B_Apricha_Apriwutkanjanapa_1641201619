using UnityEngine;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField] private GameObject selectionMarker;
    public GameObject SelectionMarker { get { return selectionMarker; } }

    [SerializeField] private TextMeshProUGUI unitCountText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI stoneText;
    
    [SerializeField] private RectTransform selectionBox;
    public RectTransform SelectionBox { get { return selectionBox; } }

    public static MainUI instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    
    public void UpdateAllResource(Fraction faction)
    {
        unitCountText.text = faction.AliveUnits.Count.ToString();
        foodText.text = faction.Food.ToString();
        woodText.text = faction.Wood.ToString();
        woodText.text = faction.Gold.ToString();
        woodText.text = faction.Stone.ToString();
        
    }
}
