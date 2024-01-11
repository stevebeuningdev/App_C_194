using CodeHub.OtherUtilities;
using Game.Scripts.Game.ShopLogic;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerDatabase _playerDatabase;
        [SerializeField] private ShopElementContextData _shopElementContextData;
        [SerializeField] private GameContext _gameContext;
        [SerializeField] private GameTutorialContext _gameTutorialContext;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _playerDatabase.OnPlayerBalanceChange = null;
            _gameContext.Initialize(_shopElementContextData.GetCurrentElement().GameIcon);
            _gameTutorialContext.Initialize();
        }
    }
}