namespace WebApplication1.Service.Interface
{
    public interface IDataConvertService<TInput, TOutput>
    {
        TOutput Convert(TInput input);
    }
}
