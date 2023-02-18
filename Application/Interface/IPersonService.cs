using Application.Dto;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPersonService
    {
        List<PersonDto> GetPersonByBuilding(string building , string token);
        List<PersonDto> GetPersonByInfo(PersonInfo person , string token);
        PersonDto AddPerson(PersonDto person);
        PersonDto UpdatePerson(PersonDto person);
        PersonDto DeletePerson(int personId);
    }
}
