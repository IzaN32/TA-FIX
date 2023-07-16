using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace VNCreator
{
#if UNITY_EDITOR // Hanya terlihat dan dijalankan di Unity Editor
    [CustomPropertyDrawer(typeof(SceneAttribute))] // Menerapkan PropertyDrawer khusus untuk atribut SceneAttribute
    public class ScenePropertyDrawer : PropertyDrawer
    {
        // Fungsi ini dipanggil saat menggambar properti di inspector
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Memuat SceneAsset berdasarkan path yang disimpan dalam properti
            SceneAsset sceneObject = AssetDatabase.LoadAssetAtPath<SceneAsset>(property.stringValue);

            // Menampilkan field untuk memilih objek scene dengan tipe SceneAsset
            // dan menyimpan objek scene yang dipilih ke dalam variabel scene
            SceneAsset scene = (SceneAsset)EditorGUI.ObjectField(position, label, sceneObject, typeof(SceneAsset), true);

            // Mengupdate nilai path scene yang baru dipilih ke dalam properti
            property.stringValue = AssetDatabase.GetAssetPath(scene);
        }
    }
#endif
}
