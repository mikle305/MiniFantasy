using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using StaticData;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using WeaponComponentData = StaticData.WeaponComponentData;

namespace Editor
{
    [CustomEditor(typeof(WeaponData))]
    public class WeaponDataEditor : UnityEditor.Editor
    {
        private static Type[] _allComponentsTypes;
        private bool _addComponentsTab;
        private WeaponData _weaponData;
        private List<WeaponComponentData> _weaponComponents;


        private void OnEnable()
        {
            _weaponData = target as WeaponData;
            _weaponComponents = typeof(WeaponData)
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .First(f => f.Name == "_components")
                    .GetValue(_weaponData) as List<WeaponComponentData>;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            ShowAddComponentsTab();
            ShowUpdateComponentsNamesButton();
        }

        private void ShowUpdateComponentsNamesButton()
        {
            if (GUILayout.Button("Update components names"))
            {
                foreach (WeaponComponentData weaponComponent in _weaponComponents)
                    UpdateComponentDisplayName(weaponComponent);
            }
        }

        private void ShowAddComponentsTab()
        {
            _addComponentsTab = EditorGUILayout.Foldout(_addComponentsTab, "Add Components");
            if (_addComponentsTab)
            {
                foreach (Type componentType in _allComponentsTypes)
                {
                    if (GUILayout.Button(componentType.Name))
                        AddWeaponComponent(componentType);
                }
            }
        }

        private void AddWeaponComponent(Type componentType)
        {
            if (_weaponComponents.Exists(c => c.GetType() == componentType))
            {
                Debug.LogWarning($"Component already added {componentType.Name}");
                return;
            }
            
            if (Activator.CreateInstance(componentType) is not WeaponComponentData newComponent)
                throw new InvalidCastException();

            _weaponComponents.Add(newComponent);
            UpdateComponentDisplayName(newComponent);
            EditorUtility.SetDirty(_weaponData);
        }

        private void UpdateComponentDisplayName(WeaponComponentData weaponComponent)
        {
            typeof(WeaponComponentData)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "_name")
                .SetValue(weaponComponent, weaponComponent.GetType().Name);
        }

        [DidReloadScripts]
        private static void OnRecompile()
        {
            _allComponentsTypes = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => 
                    t.IsSubclassOf(typeof(WeaponComponentData)) && 
                    t.ContainsGenericParameters == false && 
                    t.IsClass)
                .ToArray();
        }
    }
}