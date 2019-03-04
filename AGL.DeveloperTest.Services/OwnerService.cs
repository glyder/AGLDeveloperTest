using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Core;
using AGL.DeveloperTest.Business;



namespace AGL.DeveloperTest.Services
{
    public class OwnerService : IOwnerService
    {
        #region Properties

        private readonly ILogger<OwnerService> _logger;

        // Core
        IURLHelper _urlHelper = null;
        IHttpClient _httpClient = null;

        IDeserializer<Owner> _deserializerOwner = null;
        ILinqSorterOwner _sortOwner;

        // Business
        IOwnerRepository<Owner> _repositoryOwner = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor used by Testing
        /// </summary>
        public OwnerService()
        {
            _logger = new Logger<OwnerService>(new LoggerFactory());
            _urlHelper = new URLHelper(@"http://agl-developer-test.azurewebsites.net");
            _httpClient = new HttpClientHelper();
            _deserializerOwner = new DeserializerJson<Owner>();
            _repositoryOwner = new OwnerRepository<Owner>(_urlHelper,
                                                           _httpClient,
                                                           _deserializerOwner);
            _sortOwner = new LinqSorterOwner();
        }

        public OwnerService(ILogger<OwnerService> logger,
                            IURLHelper urlHelper,
                            IHttpClient httpClient,
                            IDeserializer<Owner> deserializer,
                            IOwnerRepository<Owner> repositoryOwner,
                            ILinqSorterOwner linqSorter)
        {
            _logger = logger;
            _urlHelper = urlHelper;
            _httpClient = httpClient;
            _deserializerOwner = deserializer;
            _repositoryOwner = new OwnerRepository<Owner>(_urlHelper,
                                                           _httpClient,
                                                           _deserializerOwner);
            _sortOwner = linqSorter;
        }

        #endregion

        public async Task<IList<IGrouping<string, Owner>>> GetAll()
        {
            try
            {
                IList<Owner> _listOwnerByGender = await _repositoryOwner.GetAll();

                if (_listOwnerByGender.Any())
                {

                    IList<IGrouping<string, Owner>> sortedListOwnerByGender = _sortOwner.SortGroupByGender(_listOwnerByGender).ToList();


                    return sortedListOwnerByGender;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw ex;
            }
        }


        public async Task<IList<Owner>> GetByGender(string gender, bool sortByName=false)
        {
            try
            {
                Func<Owner, bool> whereClause = o => o.Gender == gender;
                IList<Owner> _listOwnerByGender = await _repositoryOwner.GetByGender(whereClause);

                if (sortByName && 
                    _listOwnerByGender.Any()) {

                    IList<IGrouping<string, Owner>> sortedListOwnerByGender = _sortOwner.SortGroupByGender(_listOwnerByGender).ToList();

                    _listOwnerByGender = sortedListOwnerByGender[0].GroupBy(x => x.Gender)
                                                                   .SelectMany(y => y.Select(x => x))
                                                                   .ToList();

                    return _listOwnerByGender;
                }
                else
                {
                    return _listOwnerByGender;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
