using POFF.Meet.View.Model;

namespace POFF.Meet.Infrastructure;

public interface ITournamentStorage
{
    Tournament Load();
    void Save(Tournament tournament);
}