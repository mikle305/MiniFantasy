using System.Linq;
using System.Reflection;
using StaticData;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(LootStaticData), true)]
    public class LootDataEditor : UnityEditor.Editor
    {
        private LootStaticData _lootData;
        private FieldInfo _nameField;


        protected virtual void OnEnable()
        {
            InitLootData();
        }

        protected virtual void OnDisable()
        {
            SetNameIfEmpty();
        }

        private void InitLootData()
        {
            _lootData = target as LootStaticData;
            _nameField = typeof(LootStaticData)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "_name");
        }

        private void SetNameIfEmpty()
        {
            if (!string.IsNullOrWhiteSpace(_nameField.GetValue(_lootData) as string)) 
                return;
            
            _nameField.SetValue(_lootData, _lootData.name);
            EditorUtility.SetDirty(_lootData);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}