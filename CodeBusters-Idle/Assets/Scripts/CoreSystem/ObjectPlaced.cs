using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlaced : MonoBehaviour
{

    public static ObjectPlaced Create(FactoryObject factoryObject, Vector3 worldPosition)
    {
        Transform objectTransform = Instantiate(factoryObject.prefab, worldPosition, Quaternion.identity);

        ObjectPlaced objectPlaced = objectTransform.GetComponent<ObjectPlaced>();

        objectPlaced.factoryObject = factoryObject;

        return objectPlaced;
    }

    private FactoryObject factoryObject;

}
