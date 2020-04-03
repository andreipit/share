using System;
using UnityEditor;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class MyEditor : Editor
{
    protected Type InspectedType { get; set; }
    protected object InspectedObject { get; set; }
    protected List<PropertyInfo> Properties { get; set; }
    //protected List<FieldInfo> Fields { get; set; }

    protected virtual void OnEnable()
    {
        InspectedObject = serializedObject.targetObject;
        InspectedType = InspectedObject.GetType();

        Properties = InspectedType
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(property => property.DeclaringType == InspectedType)
            .Where(property => (property.SetMethod?.IsPublic).GetValueOrDefault())
            .ToList();

        //Fields = InspectedType
        //    .GetFields(BindingFlags.Public | BindingFlags.Instance)
        //    .Concat(InspectedType
        //            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        //            .Where(field => field.GetCustomAttribute<SerializeField>() != null)
        //           )
        //    .Where(field => field.IsInitOnly == false)
        //    .ToList();
    }

    protected virtual object MakeFieldForType(Type type, string label, object value)
    {
        T F<T>(Func<string, T, GUILayoutOption[], T> fn)
        {
            return fn(label, (T)value, null);
        }

        if (type == typeof(bool))
            return F<bool>(EditorGUILayout.Toggle);
        if (type == typeof(int))
            return F<int>(EditorGUILayout.IntField);
        if (type == typeof(long))
            return F<long>(EditorGUILayout.LongField);
        if (type == typeof(float))
            return F<float>(EditorGUILayout.FloatField);
        if (type == typeof(double))
            return F<double>(EditorGUILayout.DoubleField);
        if (type == typeof(string))
            return F<string>(EditorGUILayout.TextField);

        throw new ArgumentException(nameof(type));
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Properties");
        foreach (PropertyInfo property in Properties)
        {
            string label = property.Name;
            object value = property.GetValue(InspectedObject);
            property.SetValue(InspectedObject, MakeFieldForType(property.PropertyType, label, value));
        }

        EditorGUILayout.Separator();

        //EditorGUILayout.LabelField("Fields");
        //foreach (FieldInfo field in Fields)
        //{
        //    string label = field.Name;
        //    object value = field.GetValue(InspectedObject);
        //    field.SetValue(InspectedObject, MakeFieldForType(field.FieldType, label, value));
        //}
    }
}