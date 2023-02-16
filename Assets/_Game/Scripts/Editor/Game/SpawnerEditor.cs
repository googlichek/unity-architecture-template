using Game.Scripts.Core;
using UnityEditor;
using UnityEngine;

namespace Game.Scripts.Editor
{
    [CustomEditor(typeof(ISpawner))]
    public class SpawnerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(ISpawner spawner, GizmoType gizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawner.Transform.position, 0.5f);
        }
    }
}