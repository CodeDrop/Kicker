using POFF.Meet.Domain.PlayModes;
using POFF.Meet.View.Model;
using System;
using System.Linq;
using System.Reflection;

namespace POFF.Meet.Infrastructure.Files;

public abstract class MeetFileBase
{
    public abstract Tournament ToTournament();

    protected PlayMode GetPlayMode(string playModeTypeName)
    {
        var playModeType = Assembly.GetExecutingAssembly().GetTypes()
              .FirstOrDefault(t => t.Name == playModeTypeName
                  && typeof(PlayMode).IsAssignableFrom(t)
                  && !t.IsAbstract
                  && !t.IsInterface
                  && t.GetConstructor(Type.EmptyTypes) != null
              );

        if (playModeType == null) return PlayMode.Empty;

        return Activator.CreateInstance(playModeType) as PlayMode;
    }
}