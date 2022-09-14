using System.Text.Json.Serialization;

namespace DTOs
{
    public class UpdateTitleTaskDTO
    {
        [JsonConstructorAttribute]
        public UpdateTitleTaskDTO(string id, string title)
        {
            this.Id = id;
            this.Title = title;

        }
        public string Id { get; set; }
        public string Title { get; set; }

    }
}