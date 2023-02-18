using Application.Dto;
using Application.Interface;
using AutoMapper;
using Infrastructure.Interface;
using Infrastructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonServices : IPersonService
    {

        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;

        public PersonServices(IApiClient apiClient , IMapper mapper)
        {
            _apiClient = apiClient;
            this._mapper = mapper;
        }

        public List<PersonDto> GetPersonByBuilding(string building , string token)
        {

            var response = _apiClient.GetAsync2(building , token );
            var s = JsonConvert.DeserializeObject<List<PersonDto>>(JsonConvert.SerializeObject(response)).ToList();
            return s;
        }
        public List<PersonDto> GetPersonByInfo(PersonInfo person, string token)
        {
            //BodyInfo body = new BodyInfo()
            //{
            //    fullName = person.fullName,
            //    internalNumber = person.internalNumber,
            //    personelCode = person.personelCode
            //};

          var body =   _mapper.Map<BodyInfo>(person);
          var lst =  _mapper.Map<List<PersonDto>>(_apiClient.GetAsyn3(body ,  token));
            return lst;
    
        }


        public PersonDto AddPerson(PersonDto person)
        {
            //ApiRess body = new ApiRess()
            //{
            //    FullName = person.FullName,
            //    InternalNumber = person.InternalNumber,
            //    PersonelCode = person.PersonelCode,
            //    Building = person.Building,
            //    Floor = person.Floor,
            //    IsDeleted = false,
            //    Room = person.Room
            //};

            var body = _mapper.Map<ApiRess>(person);
            var personres= _mapper.Map<PersonDto>(_apiClient.AddAsync(body));
            return personres;
      
        }

        public PersonDto UpdatePerson(PersonDto person)
        {
            //ApiRess body = new ApiRess()
            //{
            //    FullName = person.FullName,
            //    InternalNumber = person.InternalNumber,
            //    PersonelCode = person.PersonelCode,
            //    Building = person.Building,
            //    Floor = person.Floor,
            //    IsDeleted = false,
            //    Room = person.Room,
            //    Id=person.Id
            //};
            var body = _mapper.Map<ApiRess>(person);
            var personres = _mapper.Map<PersonDto>(_apiClient.UpdatePerson(body));
            return personres;

        }

        public PersonDto DeletePerson(int personId)
        {
            var personres = _mapper.Map<PersonDto>(_apiClient.DeleteAsync(personId));
            return personres;

        }

    }
}
