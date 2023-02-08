using Infrastructure.Services;
using Infrastructure.Services.Factory;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class EnemySpawnButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        ServiceProvider services = ServiceProvider.Container;
        var enemyFactory = services.Resolve<IEnemyFactory>();
        
        _button.onClick.AddListener(() => 
            enemyFactory.CreateNinja(new Vector3(3, 1, 3)));
    }
}
