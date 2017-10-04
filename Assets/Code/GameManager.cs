using UnityEngine;
using Assets.Code.Infrastructure.Unity;
using Assets.Code.Infrastructure.Input;
using Assets.Code.Infrastructure.Sound;
using Zenject;
using Assets.Code.Components.Controller;
using Assets.Code.Components.Containers;
using Assets.Code.Configuration;

namespace Assets.Code
{
    public enum GameState { Loading = 0, Running = 1, Pause = 2 };

    public class GameManager : MonoBehaviourExtension
    {
        private IInputManager inputManager;
        private ISoundManager soundManager;
        private Factory<Character> characterFactory;

        [SerializeField]
        private CoreInstaller.Settings GameSettings;

        [Inject]
        private void Inject(IInputManager inputManager, ISoundManager soundManager, Factory<Character> characterFactory)
        {
            this.inputManager = inputManager;
            this.soundManager = soundManager;
            this.characterFactory = characterFactory;
        }

        private void Awake()
        {
            Character[] characters = new Character[4];
            characters[0] = characterFactory.Create();
            characters[0].transform.position = new Vector3(0, 0, 0);
            characters[0].transform.rotation = Quaternion.identity;
            characters[0].GetComponent<IEntityController>().Initialize(inputManager.GetGameInput(PlayerInputNumber.Player1));
        }

        private void Start()
        {
        }

        private void Update()
        {
            inputManager.ProcessGameInputs();
        }
    }
}