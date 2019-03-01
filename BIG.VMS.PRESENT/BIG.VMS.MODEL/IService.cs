namespace BIG.VMS.MODEL
{
    public interface IService<T>
    {

        T Retrieve(T obj);

        T GetItem(T obj);

        T Create(T obj);

        T Update(T obj);

        T Delete(T obj);
    }
}
