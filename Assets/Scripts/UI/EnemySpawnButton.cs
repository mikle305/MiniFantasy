using Infrastructure.Services;
using Infrastructure.Services.Factory;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class EnemySpawnButton : MonoBehaviour
    {
        private Button _button;
        private Camera _camera;
        private IEnemyFactory _enemyFactory;

        private bool _isActive;


        private void Awake()
        {
            ServiceProvider services = ServiceProvider.Container;
            _enemyFactory = services.Resolve<IEnemyFactory>();
            _button = GetComponent<Button>();
            _camera = Camera.main;

            _button.onClick.AddListener(() => _isActive = !_isActive);
        }

        private void Update()
        {
            CreateEnemyOnClick();
        }

        private void CreateEnemyOnClick()
        {
            if (!_isActive)
                return;

            if (!Input.GetMouseButtonDown(0))
                return;

            if (!Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit))
                return;

            CreateEnemy(raycastHit.point);
            _isActive = false;
        }

        private void CreateEnemy(Vector3 position) =>
            _enemyFactory.CreateNinja(position);
    }
}