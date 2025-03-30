using System.Collections;
using DG.Tweening;
using UnityEngine;

public class WaterDisplayer : MonoBehaviour
{
    [SerializeField] private Renderer renderer;
    private Material _waterMaterial;
    [SerializeField, Range(0,10)] private float _waterSpeed = 1;
    
    private void OnEnable() {
        _waterMaterial = renderer.material;
        StartCoroutine(RevealWater());
    }

    private IEnumerator RevealWater() {
        float dissolveLevel = 0f;
        while (dissolveLevel < 1f) {
            _waterMaterial.SetFloat("_DissolveLevel", dissolveLevel);
            dissolveLevel += Time.deltaTime * _waterSpeed;
            yield return null;
        }
    }
}
