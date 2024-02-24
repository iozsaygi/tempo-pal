using UnityEngine;

namespace AAA.Source.Service.Runtime
{
    [DisallowMultipleComponent]
    public class ServiceController : MonoBehaviour
    {
        [SerializeField] private ApplicationService[] runtimeApplicationServices;
        [SerializeField] private ApplicationService[] applicationServicePrefabs;

        private void OnEnable()
        {
            InstantiateApplicationServices();
            InitializeApplicationServices();
        }

        private void OnDisable()
        {
            ShutdownApplicationServices();
            DestroyApplicationServices();
        }

        public T GetRuntimeApplicationServiceByType<T>() where T : ApplicationService
        {
            for (byte i = 0; i < runtimeApplicationServices.Length; i++)
            {
                if (runtimeApplicationServices[i] is T)
                {
                    return runtimeApplicationServices[i] as T;
                }
            }

            return null;
        }

        private void InstantiateApplicationServices()
        {
            runtimeApplicationServices = new ApplicationService[applicationServicePrefabs.Length];
            for (byte i = 0; i < applicationServicePrefabs.Length; i++)
            {
                var applicationServiceInstance =
                    Instantiate(applicationServicePrefabs[i], Vector3.zero, Quaternion.identity);

                runtimeApplicationServices[i] = applicationServiceInstance;
                runtimeApplicationServices[i].transform.SetParent(transform, true);
            }
        }

        private void InitializeApplicationServices()
        {
            for (byte i = 0; i < runtimeApplicationServices.Length; i++)
                runtimeApplicationServices[i].OnInitialize(this);
        }

        private void ShutdownApplicationServices()
        {
            for (byte i = 0; i < runtimeApplicationServices.Length; i++)
                runtimeApplicationServices[i].OnShutdown();
        }

        private void DestroyApplicationServices()
        {
            for (byte i = 0; i < runtimeApplicationServices.Length; i++)
                Destroy(runtimeApplicationServices[i].gameObject);

            runtimeApplicationServices = null;
        }
    }
}