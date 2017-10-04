using Assets.Code.Components.Controller;
using Assets.Code.Components.Movement;
using Assets.Code.Infrastructure.Input;
using Assets.Code.Infrastructure.Sound;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Code.Configuration
{
    public class CoreInstaller : MonoInstaller  
    {
        [Inject]
        Settings settings = null;

        public override void InstallBindings()
        {
            // General

            Container.Bind<GameManager>().AsSingle();
            Container.Bind<IInputManager>().To<InputManager>().AsSingle();
            Container.Bind<IGameInput>().To<XboxGameInput>().AsTransient();
            Container.Bind<ISoundManager>().To<SoundManager2D>().AsSingle();

            // Components

            Container.Bind<IEntityController>().FromComponentSibling();
            Container.Bind<IMovable>().FromComponentSibling();
            Container.Bind<Rigidbody>().FromComponentSibling();
            Container.Bind<Animator>().FromComponentSibling();
            Container.Bind<SpriteRenderer>().FromComponentSibling();
        }

        [Serializable]
        public class Settings
        {
        }
    }
}
