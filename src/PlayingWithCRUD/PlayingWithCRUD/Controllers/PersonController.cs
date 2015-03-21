using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlayingWithCRUD.Models;

namespace PlayingWithCRUD.Controllers
{
    public class PersonController : ApiController
    {
        public List<Person> personList = new List<Person>()
        {
            new Person{
                PersonId =0,
                PersonName ="abc",
                PersonPhoneNumber ="123",
                PersonAge =20   
            },
            new Person{
                PersonId =1,
                PersonName ="def",
                PersonPhoneNumber ="456",
                PersonAge =20   
            },
            new Person{
                PersonId =2,
                PersonName ="ghi",
                PersonPhoneNumber ="789",
                PersonAge =21   
            }
        };
        // GET: api/Person
        public List<Person> Get()
        {
            return personList;
        }

        
        // GET: api/Person/5
        public Person GetPerson(int age,string name)
        {
            for(int i=0;i<personList.Count;i++)
                if (personList[i].PersonAge == age &&
                    personList[i].PersonName.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return personList[i];
                }
            return null;
        }


        // POST: api/Person
        public bool Post(Person person)
        {
            personList.Add(person);
            return true;
        }

        // PUT: api/Person/5
        public bool Put(int id, Person person)
        {
            personList[id] = person;
            return true;
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
