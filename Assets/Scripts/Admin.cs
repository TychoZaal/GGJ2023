using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Admin : MonoBehaviour
{

    private AdminInputController aic;

    private void OnEnable()
    {
        aic = new AdminInputController();
        aic.Admin.Skip.performed += Skip_performed;
    }

    private void Skip_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Skip performed");
        foreach(Transform t in GameEnvironment.Instance.knollenParent.transform)
        {
            Destroy(t.gameObject);
        }
        WaveManager.Instance.amountOfKnollenLeft = 0;
        WaveManager.Instance.GoToNextWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
