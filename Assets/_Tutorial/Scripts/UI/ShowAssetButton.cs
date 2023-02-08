using Game.Scripts.Core;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial.Scripts.Utils
{
    public class ShowAssetButton : TickerComponent
    {
#if UNITY_EDITOR

        public enum AssetLocation
        {
            None,
            InSceneHierarchy,
            InAssetsFolder,
        }

        [SerializeField]
        private AssetLocation _location = AssetLocation.InSceneHierarchy;

        [SerializeField]
        [ShowIf("_shouldShowTargetGameObject")]
        private GameObject _targetGameObject = default;

        [SerializeField]
        [ShowIf("_shouldShowPathToAsset")]
        private string _pathToAsset = default;

        private Button _button = default;

        private bool _shouldShowTargetGameObject = false;
        private bool _shouldShowPathToAsset = false;

        void OnValidate()
        {
            _shouldShowTargetGameObject = _location == AssetLocation.InSceneHierarchy;
            _shouldShowPathToAsset = _location == AssetLocation.InAssetsFolder;
        }

        public override void Init()
        {
            base.Init();

            _button = GetComponent<Button>();

            _button.onClick.AddListener(OnButtonClick);
        }

        public override void Dispose()
        {
            base.Dispose();

            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            switch (_location)
            {
                case AssetLocation.None:
                    return;

                case AssetLocation.InSceneHierarchy:
                    Selection.activeObject = _targetGameObject;
                    EditorGUIUtility.PingObject(Selection.activeObject);
                    break;

                case AssetLocation.InAssetsFolder:
                    Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(_pathToAsset);
                    EditorGUIUtility.PingObject(Selection.activeObject);
                    break;
            }
        }
    }
#endif
}
