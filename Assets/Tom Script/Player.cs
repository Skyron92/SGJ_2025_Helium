using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public void OnClic(InputAction.CallbackContext context)
    {

        if (context.started)
        {

            Debug.Log(Camera.current.transform.forward);
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                var hitCase = hit.transform.gameObject.GetComponent<CaseManager>();
                hitCase.ApplyEffect();
                Debug.Log("hello");
            }
        }
    }
}
