using POFF.Kicker.View.Model;

namespace POFF.Kicker.Infrastructure
{
    public interface ITournamentStorage
    {
        Tournament Load();
        void Save(Tournament tournament);
    }
}