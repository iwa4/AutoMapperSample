using AutoMapper;
using AutoMapperSample.Logic;
using AutoMapperSample.Models;
using AutoMapperSample.ViewModel;
using NUnit.Framework;
using System;

namespace AutoMapperSampleTest
{
    [TestFixture]
    public class AutoMapperDriverTest
    {
        private Person CreatePerson()
        {
            return new Person
            {
                FirstName = "kaede",
                LastName = "momiji",
                Birthday = new DateTime(2000, 10, 10),
                Company = new Company { Name = "iwa4 corporation" },
            };
        }

        [SetUp]
        public void Setup()
        {
            Mapper.Reset();
        }

        [Test]
        public void 検証なしで単純にマッピングした場合はFullNameはセットされない()
        {
            AutoMapperDriver driver = new AutoMapperDriver();
            Person _Person = CreatePerson();
            PersonViewModel _PersonViewModel = driver.MapSimple(_Person);

            _PersonViewModel.FirstName.Is(_Person.FirstName);
            _PersonViewModel.LastName.Is(_Person.LastName);
            _PersonViewModel.FullName.IsNull();
            _PersonViewModel.Birthday.Is(_Person.Birthday.Value.ToString());
            _PersonViewModel.CompanyName.Is(_Person.Company.Name);
        }

        [Test()]
        public void FullNameを明示的にマッピングさせて値が一致する()
        {
            AutoMapperDriver driver = new AutoMapperDriver();
            Person _Person = CreatePerson();
            PersonViewModel _PersonViewModel = driver.MapWithFullName(_Person);

            _PersonViewModel.FirstName.Is(_Person.FirstName);
            _PersonViewModel.LastName.Is(_Person.LastName);
            _PersonViewModel.FullName.Is("kaede momiji");
            _PersonViewModel.Birthday.Is(_Person.Birthday.Value.ToString());
            _PersonViewModel.CompanyName.Is(_Person.Company.Name);
        }

        [Test()]
        public void FullNameを明示的にignoreさせて値が一致する()
        {
            AutoMapperDriver driver = new AutoMapperDriver();
            Person _Person = CreatePerson();
            PersonViewModel _PersonViewModel = driver.MapWithIgnore(_Person);

            _PersonViewModel.FirstName.Is(_Person.FirstName);
            _PersonViewModel.LastName.Is(_Person.LastName);
            _PersonViewModel.FullName.IsNull();
            _PersonViewModel.Birthday.Is(_Person.Birthday.Value.ToString());
            _PersonViewModel.CompanyName.Is(_Person.Company.Name);
        }

        [Test()]
        public void プロファイルを使用してマッピングした場合値が一致する()
        {
            AutoMapperDriver driver = new AutoMapperDriver();
            Person _Person = CreatePerson();
            PersonViewModel _PersonViewModel = driver.MapWithProfile(_Person);

            _PersonViewModel.FirstName.Is(_Person.FirstName);
            _PersonViewModel.LastName.Is(_Person.LastName);
            _PersonViewModel.FullName.Is("kaede momiji");
            _PersonViewModel.Birthday.Is("2000年10月10日生まれ");
            _PersonViewModel.CompanyName.Is(_Person.Company.Name);
        }
    }
}
