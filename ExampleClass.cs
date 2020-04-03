using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{

    [HideInInspector] [SerializeField] int someint = 25;

    //public int SomeintProp { get { return someint; } private set { someint = value; } }
    //public int SomeintProp2 { get { return 2; } private set { ; } }


    public float Prop { get; set; }
    public int SomeintProp { get { Debug.Log("get event"); return someint;  } set { someint = value; Debug.Log("set event"); } }
    //public float Prop2 { get { return someint; } set { someint = value; } }
    //public float PropPrivateSet { get; private set; }
    //public float PropReadOnly { get; }
    //public float PropComputed => field * 2;

    //public float field;
    //public readonly float readonlyField = 5;
    //[SerializeField]
    //private float privateField;
}

[CustomEditor(typeof(ExampleClass))]
public class ExampleClassEditor : MyEditor { }