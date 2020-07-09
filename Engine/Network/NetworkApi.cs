using Engine.Engine.models;
using Engine.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Network
{
    public class NetworkApi:IDataSender,IMoveDefiner
    {
        protected void Init(Stream stream)
        {
            StreamReader = new StreamReader(stream);
            StreamWriter = new StreamWriter(stream);
        }
        public StreamReader StreamReader { get; private set; }
        public StreamWriter StreamWriter { get; private set; }

        public (int RelX, int RelY) BreakBlock()
        {
            var data = StreamReader.ReadLine();
            var split1 = data.Split(':');
            var split2 = split1[1].Split(',');
            return (Convert.ToInt32(split2[0]), Convert.ToInt32(split2[1]));
        }

        public void BreakBlock(int RelX, int RelY)
        {
            StreamWriter.WriteLine($"{command.Break}:{RelX},{RelY}");
        }

        public (int RelX, int RelY, BlockType type) PlaceBlock()
        {
            var data = StreamReader.ReadLine();
            var split1 = data.Split(':');
            var split2 = split1[1].Split(',');
            return (Convert.ToInt32(split2[0]), Convert.ToInt32(split2[1]), (BlockType)Convert.ToInt32(split2[2]));
        }

        public void PlaceBlock(int RelX, int RelY, BlockType type)
        {
            StreamWriter.WriteLine($"{command.Break}:{RelX},{RelY},{type}");
        }

        public void SendMove(command command)
        {
            StreamWriter.Write($"{command}:");
        }

        public bool key(command command)
        {
            var data = StreamReader.ReadToEnd();
            var split1 = data.Split(':')[0];
            var comand = (command)Convert.ToInt32(split1);
            return comand == command;
        }
    }
}
