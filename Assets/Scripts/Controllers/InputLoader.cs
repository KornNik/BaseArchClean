using UnityEngine.InputSystem;
using Helpers;
using Helpers.Extensions;
using Data;
using System;
using UnityEngine;
using Zenject;


namespace Controllers
{
    sealed class InputLoader
    {
        private InputActionAsset _playerActionsAsset;
        private InputActionMap _playerActionMap;
        private InputActions _inputActions;

        public InputLoader()
        {

        }
        [Inject]
        private void Construct(DatasBundle datasBundle)
        {
            _playerActionsAsset = datasBundle.GetData<InputData>().InputActionAsset;
            InitializeInputs();
        }

        private void InitializeInputs()
        {
            try
            {
                _playerActionMap = _playerActionsAsset.FindActionMap(InputActionManagerPlayer.PLAYER_ACTIONS_MAP);
                UnityEngine.Debug.Log("InputsLoaded");
                _inputActions = new InputActions(_playerActionMap);
                Services.Instance.Inputs.SetObject(_inputActions);
            }
            catch (NullReferenceException exc)
            {
                Debug.LogError(exc.ToString());
            }
        }
    }
}
