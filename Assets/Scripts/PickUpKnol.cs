using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpKnol : MonoBehaviour
{
    [SerializeField] GameObject wortelHands;
    [SerializeField] GameObject radijsHands;
    [SerializeField] GameObject bosuiHands;
    [SerializeField] GameObject emptyHands;

    [SerializeField] GameObject playerModel;

    private PlayerController playerController;

    GameObject currentActiveHands;

    List<Collider> currentlyCollidedObjects = new List<Collider>();

    private bool isHoldingKnol = false;
    private bool isHandlingInput = false;
    KNOLTYPE currentKnolType = default;

    [SerializeField]
    private PlayerInput playerInput;

    private void Awake()
    {
        playerController = new PlayerController();
        playerController.Player.Enable();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!currentlyCollidedObjects.Contains(other))
        {
            currentlyCollidedObjects.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentlyCollidedObjects.Contains(other))
        {
            currentlyCollidedObjects.Remove(other);
        }
    }

    private void ResolveInput()
    {
        isHandlingInput = false;
    }

    public void PickUp()
    {
        if (isHandlingInput) return;

        //if(context.phase == InputActionPhase.Performed)
        //{
        //Debug.Log("PICKUP() CALLED");
        isHandlingInput = true;
        Invoke("ResolveInput", 0.3f);

        if (isHoldingKnol)
        {
            isHoldingKnol = false;
            Vector3 spawnPos = transform.position + playerModel.transform.forward * 1.2f;
            KnolSpawner.Instance.SpawnKnol(currentKnolType, spawnPos);
            ActivateHands(emptyHands);
        }
        else
        {
            if (currentlyCollidedObjects == null || currentlyCollidedObjects.Count <= 0) return;
            else
            {
                Collider pickupCol = currentlyCollidedObjects[0];
                currentlyCollidedObjects.RemoveAt(0);
                switch (pickupCol.tag)
                {
                    case "Radijsje":
                        isHoldingKnol = true;
                        ActivateHands(radijsHands);
                        currentKnolType = KNOLTYPE.radijsje;
                        Destroy(pickupCol.gameObject);
                        break;
                    case "Wortel":
                        isHoldingKnol = true;
                        ActivateHands(wortelHands);
                        currentKnolType = KNOLTYPE.wortel;
                        Destroy(pickupCol.gameObject);
                        break;
                    case "Bosui":
                        isHoldingKnol = true;
                        ActivateHands(bosuiHands);
                        currentKnolType = KNOLTYPE.bosui;
                        Destroy(pickupCol.gameObject);
                        break;
                    default:
                        break;
                }
            }
        }
        //}
    }

    public void DropKnol()
    {
        if (isHoldingKnol)
        {
            isHoldingKnol = false;
            Vector3 spawnPos = transform.position + playerModel.transform.forward * 1.2f;
            KnolSpawner.Instance.SpawnKnol(currentKnolType, spawnPos, true);
            ActivateHands(emptyHands);
        }
    }

    private void ActivateHands(GameObject newHands)
    {
        currentActiveHands?.SetActive(false);
        newHands.SetActive(true);
        currentActiveHands = newHands;
    }
}
