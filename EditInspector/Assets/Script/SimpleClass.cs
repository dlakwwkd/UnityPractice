using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum HEROTYPE
{
    KNIGHT = 0,
    FIGHTER,
    MONK,
};

public class SimpleClass : MonoBehaviour
{
    [Header("Value Settings")]
    public bool showButton = true;
    public int level = 1;
    public float weight = 52.3f;
    public string nickName = "Kevin";
    public HEROTYPE heroType = HEROTYPE.KNIGHT;

    [Space(10)]
    [Space(10)]
    [Space(10)]

    [Tooltip("This is mainCameraObject.")]
    public GameObject mainCameraObject;

    [Tooltip("This is my gameObject.")]
    public Transform myTransform;

    [Space(10)]
    public List<int> myList;
    public float[] arrayFloat;
    public Vector3[] arrayVector3;

}
