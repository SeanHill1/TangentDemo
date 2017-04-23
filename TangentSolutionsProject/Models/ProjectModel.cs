using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TangentSolutionsProject.Models
{
    public class ProjectModel
    {
        public int pk { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public bool is_billable { get; set; }
        public bool is_active { get; set; }
        public List<TaskModel> task_set { get; set; }
        public List<object> resource_set { get; set; }

    }

    public class ProjectCreateModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public bool is_billable { get; set; }
        public bool is_active { get; set; }

    }
}