using Assets.Farm;

namespace Assets.Persons
{
    public class TaskPersonFactory
    {
        public ITaskPerson CreateGrowTask(IPlaceTask placeTask)
        {
            var growTask = new GrowTask(placeTask.Position, placeTask);
            return growTask;
        }

        public ITaskPerson CreateCollectTask(IPlaceTask placeTask)
        {
            var growTask = new CollectTask(placeTask.Position, placeTask);
            return growTask;
        }
    }
}
