using DG.Tweening;
using UnityEngine;

public abstract class Case : MonoBehaviour
{
    public Case(int x, int y) {
        position = new Vector2Int(x, y);
    }
    [HideInInspector] public Vector2Int position;
    [SerializeField] private GameObject waterPrefab;
    [Range(1,5)] public int waterNested = 1; 
    [HideInInspector] public int waterGiven;
    [HideInInspector] public bool flooded;
    public bool Floodable => CheckWaterInNeighbors();

    private void CheckParkingInNeighbors() => LevelManager.instance.CheckParkingInNeighbors(position);
    public bool CheckWaterInNeighbors() => LevelManager.instance.CheckWaterInNeighbors(position);

    public GameObject widgetsInfos;
    public GameObject hoverPlane;

    public abstract void ApplyEffect();
    
    void Start() {
        transform.DOMoveY(transform.position.y + 1, 1f).SetEase(Ease.OutBack);
        hoverPlane.SetActive(false);
        widgetsInfos.SetActive(false);
        if (hoverPlane != null) {
            Renderer renderer = hoverPlane.GetComponent<Renderer>();
        }
    }
    protected bool Wet() {
        waterGiven++;
        if (waterGiven < waterNested) return false;
        Flood();
        Invoke(nameof(CheckParkingInNeighbors), 0.3f);
        return true;
    }
    
    protected void Flood() {
        flooded = true;
        Instantiate(waterPrefab, transform.position + Vector3.down, Quaternion.identity);
    }

    private void OnMouseEnter() {
        widgetsInfos.SetActive(true);
        if (CheckWaterInNeighbors()) {
            hoverPlane.SetActive(true);
            hoverPlane.GetComponent<Renderer>().material.color = Color.cyan;
        }
        else
        {
            hoverPlane.SetActive(true);
            hoverPlane.GetComponent<Renderer>().material.color = Color.red;
        }

        }

    private void OnMouseExit()
    {
        widgetsInfos.SetActive(false);
        hoverPlane.SetActive(false);
    }
}