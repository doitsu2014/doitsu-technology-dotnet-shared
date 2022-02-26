using System.Reflection;
using System.Runtime.Serialization;
using AutoMapper;
using DoitsuTechnology.Shared.Application.Mappings;
using Xunit;

namespace DoitsuTechnology.Shared.Application.UnitTests.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper                _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config =>
        {
            var profile = new MappingProfile(Assembly.GetExecutingAssembly());
            config.AddProfile(profile);
        });
        _mapper = _configuration.CreateMapper();
    }

    [Fact]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Theory]
    [InlineData(typeof(ExampleClass), typeof(ExampleClassDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);
        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;
        // Type without parameterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }

    public class ExampleClass
    {
        public Guid   Id   { get; set; }
        public string Name { get; set; }
    }

    public class ExampleClassDto : IMapFrom<ExampleClass>
    {
        public DateTime DateOccured { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExampleClass, ExampleClassDto>()
                .ForMember(x => x.DateOccured, opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}