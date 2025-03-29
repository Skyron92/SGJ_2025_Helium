using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class JaugeGoutte : MonoBehaviour
{
    public Image image;
    public bool shouldDestroy;
    private Transform _canvasTransform;
    
    private void OnEnable() {
        _canvasTransform = transform.parent.parent;
        _canvasTransform.localScale = Vector3.zero;
        _canvasTransform.DOScale(Vector3.one, 0.35f).onComplete += () => ScaleAnimation();
    }

    private void ScaleAnimation() {
        _canvasTransform.DOScale(Vector3.one * 0.9f, 0.8f).onComplete += () => 
            _canvasTransform.DOScale(Vector3.one, .8f).onComplete += () => ScaleAnimation();
    }

    public void SetImage(float maxvalue, float value) { 
        StartCoroutine(FillSmoothly(value / maxvalue));
    }

    private IEnumerator FillSmoothly(float targetedValue) {
        var currentValue = image.fillAmount;
        while (currentValue < targetedValue) {
            currentValue += Time.deltaTime;
            image.fillAmount = Mathf.Clamp(currentValue, 0, targetedValue);
            yield return null;
        }
        if(shouldDestroy) Destroy(transform.parent.parent.gameObject);
    }
}
