using System.Text.Json.Serialization;

namespace DTOs
{
    public class CreateTaskDTO
    {
        [JsonConstructorAttribute]
        public CreateTaskDTO(string Title)
        {
            this.Title = Title;

        }
        public string Title { get; set; }

    }
}