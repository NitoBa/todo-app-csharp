namespace Entities
{
    public class TaskEntity
    {
        public TaskEntity(string id, string title, bool isCompleted)
        {
            this.Id = id;
            this.isCompleted = isCompleted;
            this.Title = title;

        }
        public string Id { get; set; }
        public string Title { get; set; }
        public bool isCompleted { get; set; }

    }
}