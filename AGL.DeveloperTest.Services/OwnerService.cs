
using System.Threading.Tasks;
using System.Collections.Generic;

using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Core;
using AGL.DeveloperTest.Business;
using System;
using System.Linq;

namespace AGL.DeveloperTest.Services
{
    public interface IOwnerService
    {
        Task<IList<IGrouping<string, Owner>>> GetAll();
        Task<IList<Owner>> GetByGender(string gender, bool sortByName = false);
    }

    public class OwnerService : IOwnerService
    {
        #region Properties

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
            _urlHelper = new URLHelper(@"http://agl-developer-test.azurewebsites.net");
            _httpClient = new HttpHelper();
            _deserializerOwner = new DeserializerJson<Owner>();

            _repositoryOwner = new OwnerRepository<Owner>(_urlHelper,
                                                           _httpClient,
                                                           _deserializerOwner);
            _sortOwner = new LinqSorterOwner();
        }

        public OwnerService(IURLHelper urlHelper,
                            IHttpClient httpClient,
                            IDeserializer<Owner> deserializer,
                            IOwnerRepository<Owner> repositoryOwner,
                            ILinqSorterOwner linqSorter)
        {
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

                    IList<IGrouping<string, Owner>> sortedListOwnerByGender = _sortOwner.SortGroupByGender(_listOwnerByGender);


                    return sortedListOwnerByGender;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                new LoggerAGL().Log(LoggingEventType.Error, ex.Message);
                throw ex;
            }
        }


        public async Task<IList<Owner>> GetByGender(string gender, bool sortByName=false)
        {
            try
            {
                IList<Owner> _listOwnerByGender = await _repositoryOwner.GetByGender(gender);

                if (sortByName && 
                    _listOwnerByGender.Any()) {

                    IList<IGrouping<string, Owner>> sortedListOwnerByGender = _sortOwner.SortGroupByGender(_listOwnerByGender);

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
                new LoggerAGL().Log(LoggingEventType.Error, ex.Message);
                throw ex;
            }
        }
    }
}
