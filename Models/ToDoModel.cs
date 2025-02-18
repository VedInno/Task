using System.ComponentModel.DataAnnotations;
namespace Login.Models
{
    public class ToDoModel
    {

        public string Task { get; set; }
        public bool IsCompleted { get; set; }
    }
}
