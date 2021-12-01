namespace WinTools {
    public abstract class Command {
        public abstract string Name { get; }
        public abstract string Usage { get; }
        public abstract bool Run(string[] args);
    }

    public class CommandRunner {
        Dictionary<string, Command> commandMap = new Dictionary<string, Command>();
        List<Command> commands = new List<Command>();

        public string Usage {
            get {
                var l = commands.Select(e => e.Usage).ToArray();
                return string.Join("\r\n", l);
            }
        }

        public CommandRunner() {
            RegisterCommand(new KillCommand());
            RegisterCommand(new ListProcessCommand());
        }

        public void RegisterCommand(Command cmd) {
            commands.Add(cmd);
            commandMap.Add(cmd.Name, cmd);
        }

        public bool GetCommand(string name, out Command? cmd) {
            return commandMap.TryGetValue(name, out cmd);
        }
    }
}