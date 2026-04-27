
public interface IQueryHandler<TResult>
{
    Task<TResult> Handle();
}
