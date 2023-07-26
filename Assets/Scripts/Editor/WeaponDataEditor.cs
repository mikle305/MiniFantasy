using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Additional.Extensions;
using StaticData;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using WeaponComponentData = StaticData.WeaponComponentData;

namespace Editor
{
    [CustomEditor(typeof(WeaponData))]
    public class WeaponDataEditor : LootDataEditor
    {
        private static Type[] _allComponentsTypes;
        private bool _addComponentsPanel;
        private WeaponData _weaponData;
        private List<WeaponComponentData> _weaponComponents;


        protected override void OnEnable()
        {
            base.OnEnable();
            InitWeaponData();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CreateAddComponentsPanel();
            EditorGUILayout.Space(20);
            CreateUpdateComponentsButton();
        }

        [DidReloadScripts]
        private static void OnRecompile()
        {
            _allComponentsTypes = TypeCache
                .GetTypesDerivedFrom<WeaponComponentData>()
                .ToArray();
        }

        private void InitWeaponData()
        {
            _weaponData = target as WeaponData;
            _weaponComponents = typeof(WeaponData)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "_components")
                .GetValue(_weaponData) as List<WeaponComponentData>;
        }

        private void CreateUpdateComponentsButton()
        {
            if (GUILayout.Button("Update components names"))
            {
                foreach (WeaponComponentData weaponComponent in _weaponComponents)
                {
                    string displayName = FormatDisplayComponentName(weaponComponent.GetType());
                    UpdateComponentDisplayName(weaponComponent, displayName);
                }
            }
        }

        private void CreateAddComponentsPanel()
        {
            _addComponentsPanel = EditorGUILayout.Foldout(_addComponentsPanel, "Add Components");
            if (_addComponentsPanel)
            {
                foreach (Type componentType in _allComponentsTypes)
                {
                    string componentName = FormatDisplayComponentName(componentType);
                    if (GUILayout.Button(componentName))
                        AddWeaponComponent(componentType, componentName);
                }
            }
        }

        private void AddWeaponComponent(Type componentType, string displayName)
        {
            if (_weaponComponents.Exists(c => c.GetType() == componentType))
            {
                Debug.LogWarning($"Component already added {componentType.Name}");
                return;
            }
            
            if (Activator.CreateInstance(componentType) is not WeaponComponentData newComponent)
                throw new InvalidCastException();

            _weaponComponents.Add(newComponent);
            UpdateComponentDisplayName(newComponent, displayName);
            EditorUtility.SetDirty(_weaponData);
        }

        private static void UpdateComponentDisplayName(WeaponComponentData weaponComponent, string displayName)
        {
            typeof(WeaponComponentData)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "_name")
                .SetValue(weaponComponent, displayName);
        }

        private static string FormatDisplayComponentName(Type componentType)
        {
            string componentName = componentType
                .Name
                .SplitByCapital()
                .Except(new[] { "Component", "Data" })
                .ConvertToString(" ");
            
            return componentName;
        }
    }
}