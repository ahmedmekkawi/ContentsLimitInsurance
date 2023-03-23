namespace ContentsLimitInsurance.Interfaces
{
    public interface ISvc
    {
    }

    public interface ISvc<T> : ISvc where T : class
    {
    }
}
