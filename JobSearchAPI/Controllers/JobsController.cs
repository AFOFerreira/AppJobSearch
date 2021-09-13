using JobSearch.domain.Models;
using JobSearchAPI.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : Controller
    {
        private int numberOfRegistryByPage = 5;

        private JobSearchContext _data;
        public JobsController(JobSearchContext data)
        {
            _data = data;
        }

        [HttpGet]
        public IEnumerable<Job> GetJobs(string word, string cityState, int numberOfPage = 1)
        {
            //TO-DO: Tratar situação em que os parametros são nulos. (null)
            if (word == null)
                word = "";
            if (cityState == null)
                cityState = "";



            //TO-DO: Limitar pesquisa por periodo.
            return _data.Jobs.Where(a =>
            a.PublicationDate > DateTime.Now.AddDays(-15) &&
            a.CityState.ToLower().Contains(cityState) &&
            (
                a.JobTitle.ToLower().Contains(word.ToLower()) ||
                a.TecnologyTools.ToLower().Contains(word.ToLower()) ||
                a.Company.ToLower().Contains(word)
            )
            //TO-DO: Add Paginação
            ).Skip(numberOfRegistryByPage * (numberOfPage - 1))
                .Take(numberOfRegistryByPage)
                .ToList<Job>();
        }

        [HttpGet("{id}")]
        public IActionResult GetJob(int id)
        {
            Job jobDb = _data.Jobs.Find(id);
            if (jobDb == null)
            {
                return NotFound();
            }

            return new JsonResult(jobDb);
        }

        [HttpPost]
        public IActionResult AddJob(Job job)
        {
            //TO-DO: Add validação (infinity scroll).
            job.PublicationDate = DateTime.Now;
            _data.Jobs.Add(job);
            _data.SaveChanges();

            return CreatedAtAction("GetJob", new { id = job.Id }, job);

        }
    }
}
