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
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public Boolean is_billable { get; set; }
        public Boolean is_active { get; set; }
        public TaskModel[] task_set { get; set; }
        public Object[] resource_set { get; set; }

    }
}