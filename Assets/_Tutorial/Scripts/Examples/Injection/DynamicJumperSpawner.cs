using System.Collections;
using UnityEngine;
using Zenject;

namespace Tutorial.Scripts.Utils
{
    public class DynamicJumperSpawner: MonoBehaviour
    {
        [SerializeReference]
        private GameObject _jumperTextTemplate = default;

        private DiContainer _container;

        [Inject]
        void Construct(DiContainer container)
        {
            _container = container;
        }

        void Awake()
        {
            StartCoroutine(SpawnJumperText());
        }


        private IEnumerator SpawnJumperText()
        {
            yield return new WaitForSeconds(1.5f);

            _container.InstantiatePrefab(_jumperTextTemplate, transform);
        }
    }
}
