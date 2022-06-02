using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    public class WorkTaskViewModel :BaseViewModel
    {
        public bool IsSelected { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public DateTime CreationDate { get; set; }

        public string Status { get; set; }
    }
}
