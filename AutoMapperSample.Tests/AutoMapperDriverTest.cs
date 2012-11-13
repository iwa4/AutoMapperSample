using AutoMapper;
using AutoMapperSample.Logic;
using AutoMapperSample.Models;
using AutoMapperSample.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoMapperSample.Tests
{
    [TestClass]
    public class AutoMapperDriverTest
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Mapper.Reset();
        }

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

        [TestMethod]
        public void 検証なしで単純にマッピングした場合はFullNameはセットされない()
        {
            AutoMapperDriver driver = new AutoMapperDriver();
            Person _Person = CreatePerson();
            PersonViewModel _PersonViewModel = driver.MapSimple(_Person);

            Assert.AreEqual(_PersonViewModel.FirstName, _Person.FirstName);
            Assert.AreEqual(_PersonViewModel.LastName, _Person.LastName);
            Assert.AreEqual(_PersonViewModel.FullName, null);
            Assert.AreEqual(_PersonViewModel.Birthday, _Person.Birthday.Value.ToString());
            Assert.AreEqual(_PersonViewModel.CompanyName, _Person.Company.Name);
        }

        [TestMethod()]
        public void FullNameを明示的にマッピングさせて値が一致する()
        {
            AutoMapperDriver driver = new AutoMapperDriver();
            Person _Person = CreatePerson();
            PersonViewModel _PersonViewModel = driver.MapWithFullName(_Person);

            Assert.AreEqual(_PersonViewModel.FirstName, _Person.FirstName);
            Assert.AreEqual(_PersonViewModel.LastName, _Person.LastName);
            Assert.AreEqual(_PersonViewModel.FullName, "kaede momiji");
            Assert.AreEqual(_PersonViewModel.Birthday, _Person.Birthday.Value.ToString());
            Assert.AreEqual(_PersonViewModel.CompanyName, _Person.Company.Name);
        }

        [TestMethod()]
        public void FullNameを明示的にignoreさせて値が一致する()
        {
            AutoMapperDriver driver = new AutoMapperDriver();
            Person _Person = CreatePerson();
            PersonViewModel _PersonViewModel = driver.MapWithIgnore(_Person);

            Assert.AreEqual(_PersonViewModel.FirstName, _Person.FirstName);
            Assert.AreEqual(_PersonViewModel.LastName, _Person.LastName);
            Assert.AreEqual(_PersonViewModel.FullName, null);
            Assert.AreEqual(_PersonViewModel.Birthday, _Person.Birthday.Value.ToString());
            Assert.AreEqual(_PersonViewModel.CompanyName, _Person.Company.Name);
        }

        [TestMethod()]
        public void プロファイルを使用してマッピングした場合値が一致する()
        {
            AutoMapperDriver driver = new AutoMapperDriver();
            Person _Person = CreatePerson();
            PersonViewModel _PersonViewModel = driver.MapWithProfile(_Person);

            Assert.AreEqual(_PersonViewModel.FirstName, _Person.FirstName);
            Assert.AreEqual(_PersonViewModel.LastName, _Person.LastName);
            Assert.AreEqual(_PersonViewModel.FullName, "kaede momiji");
            Assert.AreEqual(_PersonViewModel.Birthday, "2000年10月10日生まれ");
            Assert.AreEqual(_PersonViewModel.CompanyName, _Person.Company.Name);
        }
    }
}
