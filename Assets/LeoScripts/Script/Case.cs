using UnityEngine;

public abstract class Case : MonoBehaviour
{
    public Case(int x, int y) {
        position = new Vector2Int(x, y);
    }
    [HideInInspector] public Vector2Int position;
    [SerializeField] private GameObject waterPrefab;
    [SerializeField, Range(1,5)] protected int waterNested = 1;
    protected int WaterGiven;
    [HideInInspector] public bool flooded;
    public bool Floodable => CheckWaterInNeighbors();

    private void CheckParkingInNeighbors() => LevelManager.instance.CheckParkingInNeighbors(position);
    public bool CheckWaterInNeighbors() => LevelManager.instance.CheckWaterInNeighbors(position);

    public GameObject widgetsInfos;
    public GameObject hoverPlane;

    public abstract void ApplyEffect();
    
    void Start()
    {
        hoverPlane.SetActive(false);
        if (hoverPlane != null)
        {
            Renderer renderer = hoverPlane.GetComponent<Renderer>();
        }

    }
    protected bool Wet() {
        WaterGiven++;
        if (WaterGiven < waterNested) return false;
        Flood();
        Invoke("CheckParkingInNeighbors", 0.3f);
        return true;
    }
    
    protected void Flood() {
        flooded = true;
        Instantiate(waterPrefab, transform.position + Vector3.down, Quaternion.identity);
    }

    private void OnMouseEnter()
    {
        Debug.Log("Hover");
        if (CheckWaterInNeighbors())
        {
            hoverPlane.SetActive(true);
            GetComponent<Renderer>().material.color = Color.green;
        }
        
    }

    private void OnMouseExit()
    {
        hoverPlane.SetActive(false);
    }
}