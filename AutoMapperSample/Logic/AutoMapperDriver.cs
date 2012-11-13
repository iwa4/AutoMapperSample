using AutoMapper;
using AutoMapperSample.Models;
using AutoMapperSample.Profiles;
using AutoMapperSample.ViewModel;

namespace AutoMapperSample.Logic
{
    public class AutoMapperDriver
    {
        public PersonViewModel MapSimple(Person person, bool validate = false)
        {
            Mapper.CreateMap<Person, PersonViewModel>();
            if (validate)
                Mapper.AssertConfigurationIsValid();

            //方法1
            var _viewModel = new PersonViewModel();
            Mapper.Map(person, _viewModel);
            return _viewModel;

            //方法2
            //return Mapper.Map<PersonViewModel>(person);

        }

        public PersonViewModel MapWithFullName(Person person)
        {
            Mapper.CreateMap<Person, PersonViewModel>()
                .ForMember(v => v.FullName,
                        opt => opt.MapFrom(m => string.Format("{0} {1}", m.FirstName, m.LastName)));
            Mapper.AssertConfigurationIsValid();
            var _viewModel = new PersonViewModel();
            Mapper.Map(person, _viewModel);
            return _viewModel;
            //return Mapper.Map<PersonViewModel>(person);
        }

        public PersonViewModel MapWithIgnore(Person person)
        {
            Mapper.CreateMap<Person, PersonViewModel>()
                .ForMember(v => v.FullName, opt => opt.Ignore());
            Mapper.AssertConfigurationIsValid();
            return Mapper.Map<PersonViewModel>(person);
        }

        public PersonViewModel MapWithProfile(Person person)
        {
            Mapper.AddProfile<PersonProfile>();
            Mapper.AssertConfigurationIsValid();
            return Mapper.Map<PersonViewModel>(person);
        }
    }
}