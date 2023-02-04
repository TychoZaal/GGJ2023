using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnolType : MonoBehaviour
{
    [SerializeField] KNOLTYPE knolType = default;
}

public enum KNOLTYPE
{
    radijsje,
    bosui,
    wortel
}
