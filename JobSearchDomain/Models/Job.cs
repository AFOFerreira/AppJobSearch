using JobSearchDomain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JobSearch.domain.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Company", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        [Required(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_001")]
        public string Company { get; set; }

        [Display(Name = "JobTitle", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        [Required(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_001")]
        public string JobTitle { get; set; }

        [Display(Name = "CityState", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        [Required(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_001")]
        public string CityState { get; set; }

        [Display(Name = "InitialSalary", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        [Required(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_001")]
        public double InitialSalary{ get; set; }

        [Display(Name = "FinalSalary", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        [Required(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_001")]
        public double FinalSalary { get; set; }

        [Display(Name = "ContractType", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        [Required(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_001")]
        public string ContractType { get; set; }

        [Display(Name = "TecnologyTools", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        [Required(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_001")]
        public string TecnologyTools { get; set; }

        [Display(Name = "CompanyDescription", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        public string CompanyDescription { get; set; }

        [Display(Name = "JoobDescription", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        [Required(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_001")]
        public string JoobDescription { get; set; }

        [Display(Name = "Benefits", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        public string Benefits { get; set; }

        [Display(Name = "EmailToSend", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        [Required(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_001")]
        [EmailAddress(ErrorMessageResourceType = typeof(JobSearchDomain.Models.Utility.Language.Messages), ErrorMessageResourceName = "MSG_002")]
        public string EmailToSend { get; set; }

        [Display(Name = "PublicationDate", ResourceType = typeof(JobSearchDomain.Models.Utility.Language.Fields))]
        public DateTime PublicationDate { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
