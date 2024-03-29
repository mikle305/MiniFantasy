using System;
using System.Linq;
using Editor.Extensions;
using GamePlay.Additional;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(UniqueId))]
    public class UniqueIdEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            var uniqueId = (UniqueId)target;

            if (uniqueId.IsPrefab())
                return;
            
            if (string.IsNullOrEmpty(uniqueId.Id))
            {
                Generate(uniqueId);
            }
            else
            {
                UniqueId[] idsOnScene = FindObjectsOfType<UniqueId>();

                if (idsOnScene.Any(idOnScene => idOnScene != uniqueId && idOnScene.Id == uniqueId.Id))
                    Generate(uniqueId);
            }
        }

        private void Generate(UniqueId uniqueId)
        {
            uniqueId.Id = $"{uniqueId.gameObject.scene.name}_{Guid.NewGuid().ToString()}";
            if (Application.isPlaying)
                return;

            EditorUtility.SetDirty(uniqueId);
            EditorSceneManager.MarkSceneDirty(uniqueId.gameObject.scene);
        }
    }
}