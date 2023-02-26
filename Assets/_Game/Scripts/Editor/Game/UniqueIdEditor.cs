using System.Linq;
using Game.Scripts.Core;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Game.Scripts.Editor
{
    [CustomEditor(typeof(UniqueIdComponent))]
    public class UniqueIdEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            UniqueIdComponent uniqueIdComponent = (UniqueIdComponent) target;

            if (IsPrefab(uniqueIdComponent.gameObject))
            {
                return;
            }

            if (string.IsNullOrEmpty(uniqueIdComponent.UniqueId))
            {
                Generate(uniqueIdComponent);
            }
            else
            {
                var uniqueIds = FindObjectsOfType<UniqueIdComponent>();

                if (uniqueIds.Any(
                        other =>
                            (other != uniqueIdComponent) &&
                            (other.UniqueId == uniqueIdComponent.UniqueId)))
                {
                    Generate(uniqueIdComponent);
                }
            }
        }

        private bool IsPrefab(GameObject saveIdGameObject)
        {
            return saveIdGameObject.scene.rootCount == 0;
        }

        private void Generate(UniqueIdComponent uniqueIdComponent)
        {
            uniqueIdComponent.GenerateUniqueId();

            if (!Application.isPlaying)
            {
                EditorUtility.SetDirty(uniqueIdComponent);
                EditorSceneManager.MarkSceneDirty(uniqueIdComponent.gameObject.scene);
            }
        }
    }
}
