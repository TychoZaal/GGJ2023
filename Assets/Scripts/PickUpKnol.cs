using System.Collections.Generic;
using UnityEngine;

public class PickUpKnol : MonoBehaviour
{
    [SerializeField] GameObject wortelHands;
    [SerializeField] GameObject radijsHands;
    [SerializeField] GameObject bosuiHands;

    GameObject currentActiveHands;

    List<Collider> currentlyCollidedObjects = new List<Collider>();

    private bool isHoldingKnol = false;
    KNOLTYPE currentKnolType = default;

    private void OnTriggerEnter(Collider other)
    {
        currentlyCollidedObjects.Add(other);
        //switch (other.tag)
        //{
        //    case "Radijsje":
        //        ActivateHands(radijsHands);
        //        break;
        //    case "Wortel":
        //        ActivateHands(wortelHands);
        //        break;
        //    case "Bosui":
        //        ActivateHands(bosuiHands);
        //        break;
        //    default:
        //        break;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        currentlyCollidedObjects.Remove(other);
    }

    public void PickUp()
    {
        if (isHoldingKnol)
        {
            Vector3 spawnPos = transform.position + transform.forward * 4f;
            KnolSpawner.Instance.SpawnKnol(currentKnolType, spawnPos);
            isHoldingKnol = false;
        }
        else
        {
            if (currentlyCollidedObjects == null || currentlyCollidedObjects.Count == 0) return;
            else
            {
                Collider pickupCol = currentlyCollidedObjects[0];
                currentlyCollidedObjects.Remove(pickupCol);
                switch (pickupCol.tag)
                {
                    case "Radijsje":
                        ActivateHands(radijsHands);
                        currentKnolType = KNOLTYPE.radijsje;
                        Destroy(pickupCol.gameObject);
                        break;
                    case "Wortel":
                        ActivateHands(wortelHands);
                        currentKnolType = KNOLTYPE.wortel;
                        Destroy(pickupCol.gameObject);
                        break;
                    case "Bosui":
                        ActivateHands(bosuiHands);
                        currentKnolType = KNOLTYPE.bosui;
                        Destroy(pickupCol.gameObject);
                        break;
                    default:
                        break;
                }
            } 
        }
    }

    private void ActivateHands(GameObject newHands)
    {
        currentActiveHands?.SetActive(false);
        newHands.SetActive(true);
        currentActiveHands = newHands;
        isHoldingKnol = true;
    }
}
