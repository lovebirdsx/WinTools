using System.Diagnostics;

namespace WinTools {
    public class KillCommand : Command {
        public override string Name => "Kill";

        public override string Usage => "Kill Unity";

        public override bool Run(string[] args) {
            if (args.Length < 2) {
                return false;
            }

            var name = args[1];
            var processes = Process.GetProcessesByName(name);
            foreach (var p in processes) {
                p.Kill();
            }

            Console.WriteLine($"Kill {processes.Length} process which named {name}");

            return true;
        }
    }

    public class ListProcessCommand : Command {
        public override string Name => "ListProcess";

        public override string Usage => "ListProcess Unity";

        public override bool Run(string[] args) {
            var processes = Process.GetProcesses();
            if (args.Length < 2) {
                foreach (var p in processes) {
                    Console.WriteLine($"[{p.Id}] {p.ProcessName}");
                }
            } else {
                foreach (var p in processes) {
                    if (p.ProcessName.Contains(args[1])) {
                        Console.WriteLine($"[{p.Id}] {p.ProcessName}");
                    }
                }
            }
            return true;
        }
    }
}