namespace WinTools {
    class Program {
        static int Main(string[] args) {
            var runner = new CommandRunner();
            if (args.Length < 1) {
                Console.WriteLine("WinTools [cmd] [arg0] [arg1]");
                Console.WriteLine(runner.Usage);
                return -1;
            }

            var cmdName = args[0];
            if (runner.GetCommand(cmdName, out var cmd)) {
                if (cmd != null && cmd.Run(args)) {
                    return 0;
                } else {
                    Console.WriteLine($"Run {cmdName} failed, Usage: {cmd?.Usage}");
                    return -1;
                }
            } else {
                return -1;
            }
        }
    }
}