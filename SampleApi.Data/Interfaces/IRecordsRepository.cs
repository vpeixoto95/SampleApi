using SampleApi.Data.Entities;

namespace SampleApi.Data.Interfaces;

public interface IRecordsRepository
{
    Task<IEnumerable<Record>> GetAll();
    Task<Record?> Get(int id);
    Task<int> Create(Record record);
    Task<Record?> Update(Record record);
    Task<bool> Delete(int id);
}
