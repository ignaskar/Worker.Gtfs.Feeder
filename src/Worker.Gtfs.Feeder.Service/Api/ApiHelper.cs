using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Worker.Gtfs.Feeder.Library.Models;

namespace Worker.Gtfs.Feeder.Service.Api
{
    public class ApiHelper : IApiHelper
    {
        private readonly ILogger<ApiHelper> _logger;
        private HttpClient _apiClient;
        
        public ApiHelper(ILogger<ApiHelper> logger, HttpClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }
        
        public async Task<List<GtfsModel>> GetGtfsDataAsync(CancellationToken cancellationToken)
        {
            var response = await _apiClient.GetAsync("vilnius/gps_full.txt", cancellationToken);
            
            cancellationToken.ThrowIfCancellationRequested();
            
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Parsing retrieved GTFS data...");
                await using var s = await response.Content.ReadAsStreamAsync(cancellationToken);
                using var sr = new StreamReader(s);
                using var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<GtfsModel>();
                
                return records.ToList();
            }

            _logger.LogError($"Failed to get GTFS data... Reason: {response.StatusCode} - {response.ReasonPhrase}");
            return null;
        }
    }
}