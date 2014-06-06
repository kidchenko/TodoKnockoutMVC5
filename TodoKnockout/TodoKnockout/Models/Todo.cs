using System;

namespace TodoKnockout.Models
{
    public class Todo
    {
        public string Id { get; set; }
        public bool Done { get; set; }
        public string Title { get; set; }
        public DateTime CreatedIn { get; set; }
    }
}