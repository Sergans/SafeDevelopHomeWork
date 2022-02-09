namespace SafeDevelopHomeWork_1.Services
{
    public interface IOperationService<T> where T: class
    {
        void Create(T model);
        List<T> GetAll();
        bool Delete(int id);
        void UpDate();
        //T GetById();
    }
}
