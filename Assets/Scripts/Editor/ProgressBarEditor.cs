using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Reflection;
using System.Collections.Generic;
using System;
using System.Linq;
using System.ComponentModel;

namespace Assets.Scripts
{
    [CustomEditor(typeof(ProgressBar))]
    public class ProgressBarEditor : Editor
    {
        private SerializedProperty progressValue;
        private SerializedProperty followTransform;
        private SerializedProperty dataContext;
        private SerializedProperty propertyName;

        [SerializeField]
        private List<PropertyInfo> properties;

        protected void OnEnable()
        {
            progressValue = serializedObject.FindProperty("progressValue");
            followTransform = serializedObject.FindProperty("followTransform");
            dataContext = serializedObject.FindProperty("dataContext");
            propertyName = serializedObject.FindProperty("propertyName");
            properties = GetDataContextProperties();
        }

        private List<PropertyInfo> GetDataContextProperties()
        {
            var target = serializedObject.targetObject;
            var targetType = target.GetType();
            var targetFields = targetType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var dataContextField = targetFields.FirstOrDefault(f => f.Name == dataContext.propertyPath);
            var dataContextObject = dataContextField.GetValue(serializedObject.targetObject);
            
            if (dataContextObject == null)
            {
                return new List<PropertyInfo>();
            }

            var dataContextObjectType = dataContextObject.GetType();

            return dataContextObjectType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.PropertyType == typeof(float))
                    .ToList();      
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.Slider(progressValue, 0, 1);
            EditorGUILayout.PropertyField(followTransform);

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(dataContext);
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                properties = GetDataContextProperties();
            }

            DrawPropertiesPopup();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawPropertiesPopup()
        {
            if (properties != null && properties.Any())
            {
                var index = properties.IndexOf(properties.FirstOrDefault(f => f.Name == propertyName.stringValue));

                index = EditorGUILayout.Popup(index, properties.Select(s => s.Name).ToArray());

                propertyName.stringValue = properties[index].Name;
            }
        }
    }
}
