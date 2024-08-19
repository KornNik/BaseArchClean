using System;
using UnityEngine;
using Behaviours;
using Controllers;
using Data;

namespace Helpers
{
    sealed class Services
    {
        private static readonly Lazy<Services> _instance = new Lazy<Services>();

        public static Services Instance => _instance.Value;
        public Service<Camera> CameraService { get; private set; }
        public Service<LevelBahaviour> LevelService { get; private set; }
        public Service<AudioController> AudioController { get; private set; }
        public Service<SettingsController> SettingsController { get; private set; }
        public Service<TimeController> TimeController { get; private set; }
        public Service<DatasBundle> DatasBundle { get; private set; }
        public Service<LevelController> LevelController { get; private set; }
        public Service<GameStateBehaviour> GameStateBehavior { get; private set; }

        public Services()
        {
            Initialize();
        }

        private void Initialize()
        {
            CameraService = new Service<Camera>();
            LevelService = new Service<LevelBahaviour>();
            AudioController = new Service<AudioController>();
            SettingsController = new Service<SettingsController>();
            TimeController = new Service<TimeController>();
            DatasBundle = new Service<DatasBundle>();
            LevelController = new Service<LevelController>();
            GameStateBehavior = new Service<GameStateBehaviour>();
        }

    }
}
