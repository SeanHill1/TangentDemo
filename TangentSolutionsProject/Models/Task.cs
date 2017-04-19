using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TangentSolutionsProject.Models
{
    public class TaskModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime due_date { get; set; }
        public string estimated_hours { get; set; }
        public int project { get; set; }
        public ProjectModel[] project_data{ get; set; }
}

  
}