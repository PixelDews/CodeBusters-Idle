using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FactoryObject", menuName = "ScriptableObjects/FactoryObject")]
public class FactoryObject : ScriptableObject
{
    public string objectType;
    public Transform prefab;
    public int width;
    public int height;

}
