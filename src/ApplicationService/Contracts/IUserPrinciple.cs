namespace ApplicationService.Interfaces;

public interface IUserPrinciple
{
    bool IsTemporary { get; }
    Guid GetUserId();
}
