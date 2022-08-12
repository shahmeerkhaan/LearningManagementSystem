using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Multiclass
    {
        
            public Student Student { get; set; }
            public registraton Registraton { get; set; }
            public Teacher Teacher { get; set; }

            public cours Courses { get; set; }

            public department Department { get; set; }

        
    }
}