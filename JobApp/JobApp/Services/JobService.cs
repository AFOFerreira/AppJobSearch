using JobApp.Models;
using JobSearch.domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobApp.Services
{
    public class JobService : Service
    {
        public async Task<ResponseService<List<Job>>> GetJobs(string word, string cityState, int numberOfPage = 1)
        {
            HttpResponseMessage response = await _client.GetAsync($"{BaseApiUrl}/api/Jobs?word={word}&cityState={cityState}&numberOfPage={numberOfPage}");

            ResponseService<List<Job>> responseService = new ResponseService<List<Job>>();

            responseService.IsSuccess = response.IsSuccessStatusCode;
            responseService.StatusCode = (int)response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                responseService.Data = await response.Content.ReadAsAsync<List<Job>>();
            }
            else
            {
                var problemResponse = await response.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<ResponseService<List<Job>>>(problemResponse);
                responseService.Errors = errors.Errors;
            }
            return responseService;
        }

        public async Task<ResponseService<Job>> GetJob(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"{BaseApiUrl}/api/Jobs/{id}");

            ResponseService<Job> responseService = new ResponseService<Job>();

            responseService.IsSuccess = response.IsSuccessStatusCode;
            responseService.StatusCode = (int)response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                responseService.Data = await response.Content.ReadAsAsync<Job>();
            }
            else
            {
                var problemResponse = await response.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<ResponseService<Job>>(problemResponse);
                responseService.Errors = errors.Errors;
            }
            return responseService;
        }

        public async Task<ResponseService<Job>> AddJob(Job job)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync($"{BaseApiUrl}/api/Jobs", job);
            ResponseService<Job> responseService = new ResponseService<Job>();

            responseService.IsSuccess = response.IsSuccessStatusCode;
            responseService.StatusCode = (int)response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                responseService.Data = await response.Content.ReadAsAsync<Job>();
            }
            else
            {
                var problemResponse = await response.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<ResponseService<Job>>(problemResponse);
                responseService.Errors = errors.Errors;
            }
            return responseService;

        }
    }
}
