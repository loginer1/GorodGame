using Assets.Farm;

namespace Assets.Persons
{
    public class TaskPersonFactory
    {
        public ITaskPerson CreateTask(IPlaceTask placeTask)
        {
            var Task = new TaskBot(placeTask.Position, placeTask);
            return Task;
        }
    }
}
