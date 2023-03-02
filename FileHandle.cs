using System;
namespace addmup
{
	public class FileHandle
	{
		private string[] _args;
		public FileHandle(string[] args)
		{
			if (args.Length == 0) throw new ArgumentException("No input was provided");
			_args = args;
			
		}

		public void ShowArguments()
		{
			for(var i = 0; i < _args.Length; i++) {
				Console.WriteLine(_args[i]);
			}
		}

		public string[] ReadInputFile()
		{
			var filePath = _args[1];
			if(!File.Exists(filePath))
			{
				throw new Exception("Input File Not found!");
			};

			return File.ReadAllLines(filePath);
        }
	}
}

