using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    public class CaesarStream : Stream
    {
        private Stream _stream;
        private int _offset;
        public CaesarStream(Stream stream, int offset)
        {
            _stream = stream;
            _offset = offset;
        }

        public override bool CanRead => _stream.CanRead;

        public override bool CanSeek => _stream.CanSeek;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position { get => _stream.Position; set => _stream.Position = value; }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            byte[] auxBuffer = new byte[count];
            int bytesRead = _stream.Read(auxBuffer, 0, count); //while--?
            string temp = Encoding.ASCII.GetString(auxBuffer);
            string result = "";
            
            for (int j = 0; j < bytesRead; j++)
            {
                if (char.IsLetter(temp[j]))
                {
                    char d = char.IsUpper(temp[j]) ? 'A' : 'a';
                    result += (char)(Modulo(((temp[j] + _offset) - d), 26) + d);
                }
                else
                {
                    result += temp[j];
                }
            }
            auxBuffer = Encoding.ASCII.GetBytes(result);

            for (int j = 0; j < bytesRead; j++)
            {
                buffer[offset + j] = auxBuffer[j];
            }

            return bytesRead;
        }

        private int Modulo(int first, int second)
        {
            int remainder = first % second;
            return remainder < 0 ? remainder + second : remainder;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            string temp = Encoding.ASCII.GetString(buffer);
            string output = "";
            for (int j = 0; j < count; j++)
            {
                if (char.IsLetter(temp[j]))
                {
                    char d = char.IsUpper(temp[j]) ? 'A' : 'a';
                    output += (char)(Modulo(((temp[j] + _offset) - d), 26) + d);
                }
                else
                {
                    output += temp[j];
                }
            }
            _stream.Write(Encoding.ASCII.GetBytes(output), 0, count);
        }
    }
}
