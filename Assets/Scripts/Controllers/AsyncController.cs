using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Controllers
{
    class AsyncController
    {
        private const int DEFAULT_LIST_VALUE = 6;

        private List<TaskCustom> _tasks;

        private AsyncController()
        {
            _tasks = new List<TaskCustom>(DEFAULT_LIST_VALUE);
        }
        
        public void StartTask(TaskCustom task)
        {
            if (!_tasks.Contains(task))
            {
                var cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = cancellationTokenSource.Token;

                _tasks.Add(task);
                task.Start();
            }
        }
        public void RemoveCoroutine(TaskCustom task)
        {
            if (_tasks.Contains(task))
            {
                ////StopTask
                _tasks.Remove(task);
            }
        }
        public void RemoveAllCoroutines()
        {
            ////StopTasks
            _tasks.Clear();
        }
    }
}
