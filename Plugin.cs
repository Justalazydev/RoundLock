using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace RoundLockPlugin
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "RoundLockPlugin";
        public override string Author => "MyNameHAHAHAHA";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        private EventHandlers eventHandlers;

        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            Exiled.Events.Handlers.Server.RoundStarted += eventHandlers.OnRoundStarted;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= eventHandlers.OnRoundStarted;
            eventHandlers = null;
            base.OnDisabled();
        }
    }

    public class EventHandlers
    {
        private readonly Plugin plugin;

        public EventHandlers(Plugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnRoundStarted()
        {
            Map.Broadcast(10, "ROUND AND WARHEAD LOCK WOMP WOMP"); // Отправляем сообщение всем игрокам на сервере

            // Поставить roundlock
            Exiled.API.Features.Warhead.IsLocked = true;
            Exiled.API.Features.Warhead.Start();
            Exiled.API.Features.Round.IsLocked = true;

            Log.Info("Round lock has been set.");
        }
    }
}
