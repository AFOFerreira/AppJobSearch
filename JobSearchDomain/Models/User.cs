using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobSearch.domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Name", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        [Required(ErrorMessageResourceType =typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName ="MSG_001")]
        [MinLength(10, ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_003")]
        public string Name { get; set; }

        [Display(Name = "Email", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        [Required(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_001")]
        [EmailAddress(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_002")]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        [Required(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_001")]
        [MinLength(6, ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_003")]
        public string Password { get; set; }
    }
}
