using AutoMapper;
using AutoMapperSample.Models;
using AutoMapperSample.ViewModel;
using System;

namespace AutoMapperSample.Profiles
{
    public class PersonProfile : Profile
    {
        public override string ProfileName { get { return "PersonProfile"; } }

        protected override void Configure()
        {
            Mapper.ForSourceType<DateTime>().AddFormatter<DateStringFormatterJP>();
            Mapper.CreateMap<Person, PersonViewModel>()
                .ForMember(v => v.FullName,
                        opt => opt.MapFrom(m => string.Format("{0} {1}", m.FirstName, m.LastName)));
        }
    }
}