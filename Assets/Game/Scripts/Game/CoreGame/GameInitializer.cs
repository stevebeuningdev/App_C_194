using Game.Scripts.Game.ShopLogic;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private ShopElementContextData _shopElementContextData;
        [SerializeField] private GameContext _gameContext;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _gameContext.Initialize(_shopElementContextData.GetCurrentElement().GameIcon);
        }
    }
}