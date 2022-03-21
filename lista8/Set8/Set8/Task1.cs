using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Set8
{
    public interface ICommand
    {
        void Execute();
    }

    public abstract class WebFileDownloaderCommand : ICommand
    {
        protected WebClient _client;
        protected Uri _address;
        protected string _fileName;

        public WebFileDownloaderCommand(Uri address, string filename)
        {
            _address = address;
            _fileName = filename;
            _client = new WebClient();
        }

        public abstract void Execute();

    }

    public class FtpFileDownloaderCommand : WebFileDownloaderCommand
    {
        public FtpFileDownloaderCommand(Uri address, string filename) : base(address, filename)
        {
        }

        public override void Execute()
        {
            _client.DownloadFile(_address, _fileName);
        }

    }

    public class HttpFileDownloaderCommand : WebFileDownloaderCommand
    {
        public HttpFileDownloaderCommand(Uri address, string filename) : base(address, filename)
        {
        }

        public override void Execute()
        {
            _client.DownloadFile(_address, _fileName);
        }
    }

    public class FileFillerCommand : ICommand
    {
        private string _fileName;
        public FileFillerCommand(string fileName)
        {
            _fileName = fileName;
        }
        public void Execute()
        {
            var receiver = new RandomStringFileFiller();
            receiver.FillFileWithRandomString(_fileName);
        }
    }

    public class RandomStringFileFiller
    {
        public void FillFileWithRandomString(string filename)
        {
            var fileStream = File.CreateText(filename);
            var randomStr = CreateRandomString();
            fileStream.Write(randomStr);
        }


        private string CreateRandomString()
        {
            int randomLength = new Random().Next(0, 101);
            string alphabeth = "abcdefghijklmnoprstuwvxyz";
            int alphabethLength = alphabeth.Length;
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < randomLength; i++)
            {
                sb.Append(alphabeth[random.Next(alphabethLength)]);
            }
            return sb.ToString();
        }
    }

    public class FileCopierCommand : ICommand
    {
        private string _source;
        private string _destination;

        public FileCopierCommand(string source, string destination)
        {
            _source = source;
            _destination = destination;
        }

        public void Execute()
        {
            File.Copy(_source, _destination);
        }
    }

    public class Invoker
    {
        private Queue<ICommand> _commands;
        private bool _threaded;

        public Invoker(bool threaded = false)
        {
            _threaded = threaded;
            if (_threaded)
            {
                var t1 = new Thread(KeepEcecutingCommandsInQueue);
                var t2 = new Thread(KeepEcecutingCommandsInQueue);

                t1.Start();
                t2.Start();
            }
        }

        private void KeepEcecutingCommandsInQueue()
        {
            while (true)
            {
                if (_commands.Count == 0)
                {
                    Thread.Sleep(50);
                }
                else
                {
                    lock (_commands)
                    {
                        if (_commands.Count > 0)
                        {
                            var command = _commands.Dequeue();
                            command.Execute();
                        }
                    }
                }
            }
        }

        public void Execute(ICommand command)
        {
            if (!_threaded)
            {
                command.Execute();
            }
            else
            {
                _commands.Enqueue(command);
            }
        }
    }
}
