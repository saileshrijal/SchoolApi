using SchoolApi.Dtos;

namespace SchoolApi.Services.Interface
{
    public interface IParentService
    {
        Task Create(ParentDto parentDto);
    }
}
