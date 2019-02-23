
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
        Task<IList<Owner>> GetByGender(string gender, bool sortByName = false);
    }

    public class OwnerService : IOwnerService
    {
        #region Properties

        // Core
        IURLHelper _urlHelper = null;
        IHttpClient _httpClient = null;

        IDeserializer<Owner> _deserializerOwner = null;
        ILinqSorterOwner<Owner> _sortOwner = null;

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
            _deserializerOwner = new JsonDeserializer<Owner>();

            _repositoryOwner = new OwnerRepository(_urlHelper,
                                                   _httpClient,
                                                   _deserializerOwner);
            _sortOwner = new LinqSorterOwner<Owner>();
        }

        public OwnerService(IURLHelper urlHelper,
                            IHttpClient httpClient,
                            IDeserializer<Owner> deserializer,
                            ILinqSorterOwner<Owner> linqSorter,
                            IOwnerRepository<Owner> repositoryOwner)
        {
            _urlHelper = urlHelper;
            _httpClient = httpClient;
            _deserializerOwner = deserializer;
            _sortOwner = linqSorter;

            _repositoryOwner = new OwnerRepository(_urlHelper,
                                                   _httpClient,
                                                   _deserializerOwner);
        } 

        #endregion

        public async Task<IList<Owner>> GetByGender(string gender, bool sortByName=false)
        {
            try
            {
                IList<Owner> _listOwnerByGender = await _repositoryOwner.GetByGender(gender);

                if (sortByName && 
                    _listOwnerByGender.Any()) {

                    IList<IGrouping<string, Owner>> sortedListOwnerByGender = _sortOwner.SortGroupBy(_listOwnerByGender);


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
                new Logger().Log(LoggingEventType.Error, ex.Message);
                throw ex;
            }
        }
    }
}
