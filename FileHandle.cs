using System;
namespace addmup
{
	public class FileHandle
	{

		private string _inputFile;
		private string _outputFile;
		public FileHandle(string[] args)
		{
			if (args.Length == 0) throw new ArgumentException("No input was provided");

			_inputFile = "abc.txt";
			_outputFile = "xyz.txt";

			for(var i = 0; i < args.Length; i++)
			{
				if (args[i]=="--in")
				{
					_inputFile = args[i + 1];
				}
				if (args[i]=="--out")
				{
					_outputFile = args[i + 1];
				}
			}
		}

		public string[] ReadInputFile()
		{
			if(!File.Exists(_inputFile))
			{
				throw new Exception("Input File Not found!");
			};

			return File.ReadAllLines(_inputFile);
        }

		public void WriteOutFile(string outPut)
		{
			File.WriteAllText(_outputFile, outPut);
		}
	}
}

