namespace Acme.Repository.Interfaces
{
    public interface IAcmeUnitOfWork
    {
        ISignupRepository Signups { get; }
    }
}
