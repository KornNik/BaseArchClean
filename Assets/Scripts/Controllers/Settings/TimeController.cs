using Behaviours;
using Data;
using Helpers;
using UnityEngine;
using Zenject;

namespace Controllers
{
    class TimeController : ITimeController
    {
        private DefaultTimeData _timeData;

        public TimeController()
        {

        }
        [Inject]
        private void Construct(DatasBundle datasBundle)
        {
            _timeData = datasBundle.GetData<DefaultTimeData>();
        }

        public void PauseTime()
        {
            Time.timeScale = _timeData.PauseTime;
        }
        public void ResumeTime()
        {
            Time.timeScale = _timeData.NormalTime;
        }
    }
}
