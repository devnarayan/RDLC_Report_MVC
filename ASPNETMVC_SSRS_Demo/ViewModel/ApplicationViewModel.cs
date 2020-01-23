using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETMVC_SSRS_Demo.ViewModel
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }
        public string AppName { get; set; }
        public string DisplayName { get; set; }
        public Nullable<int> SourceId { get; set; }
    }
}