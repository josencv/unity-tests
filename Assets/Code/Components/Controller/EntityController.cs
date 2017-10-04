using Assets.Code.Components.Movement;
using Assets.Code.Infrastructure.Input;
using Assets.Code.Infrastructure.Unity;
using UnityEngine;
using Zenject;

namespace Assets.Code.Components.Controller
{
    public class EntityController : MonoBehaviourExtension, IEntityController
    {
        private IMovable movement;
        private Animator animator;

        [Inject]
        private void Inject(IMovable movement, Animator animator)
        {
            this.movement = movement;
            this.animator = animator;
        }

        public void Initialize(IGameInput gameInput)
        {
            gameInput.PlayerMoveSignal += movement.Move;
        }
    }
}
