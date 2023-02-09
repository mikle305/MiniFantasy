using Domain.Character;
using Infrastructure.Services;
using Infrastructure.Services.Factory;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class EnemySpawnButton : MonoBehaviour
{
    private Button _button;
    private Camera _camera;
    private IEnemyFactory _enemyFactory;

    private bool _isActive;
    private Transform _character;


    private void Awake()
    {
        ServiceProvider services = ServiceProvider.Container;
        _enemyFactory = services.Resolve<IEnemyFactory>();
        _button = GetComponent<Button>();
        _camera = Camera.main;
        
        _button.onClick.AddListener(() => _isActive = !_isActive);
    }

    private void Start()
    {
        _character = FindObjectOfType<CharacterMovement>().transform;
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

    private void CreateEnemy(Vector3 position)
    {
        GameObject enemy = _enemyFactory.CreateNinja(position);
        enemy.GetComponent<AgentFollow>().Target = _character;
    }
}
